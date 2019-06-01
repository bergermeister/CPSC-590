using System;
using System.Threading;

namespace ReaderWriterLockExample
{
   class Program
   {
      static void Main( string[] aoArgs )
      {
         int kiWorkers            = 10;
         int kiMaxWorkerThreads   = 0;
         int kiMaxCompletionPorts = 0;
         int kiIndex;

         TcWorker[ ]         koWorker;
         ManualResetEvent[ ] koMR;

         /// -# Parse the number of threads
         if( ( aoArgs.Length < 1 ) || ( Int32.TryParse( aoArgs[ 0 ], out kiWorkers ) == false ) )
         {
            kiWorkers = 10;
         }

         koWorker = new TcWorker[ kiWorkers ];
         koMR     = new ManualResetEvent[ kiWorkers ];
         
         /// -# Query the max number of threads
         ThreadPool.GetMaxThreads( out kiMaxWorkerThreads, out kiMaxCompletionPorts );
         Console.WriteLine( "Max threads: {0}", kiMaxWorkerThreads );

         /// -# Ensure workers are set to run
         TcWorker.VbRunning = true;
         for( kiIndex = 0; kiIndex < kiWorkers; kiIndex++ )
         {
            koMR[ kiIndex ] = new ManualResetEvent( false );
            koWorker[ kiIndex ] = new TcWorker( koMR[ kiIndex ] ); 
            ThreadPool.QueueUserWorkItem( koWorker[ kiIndex ].MHandle, kiIndex );
            if( kiIndex > 10 )
            {
               Thread.Sleep( 300 );
            }
         }

         Thread.Sleep( 2000 );

         /// -# Tell the workers to stop running
         TcWorker.VbRunning = false;
         WaitHandle.WaitAll( koMR );

         TcWorker.MResults( );
         Console.ReadLine( );
      }
   }
}
