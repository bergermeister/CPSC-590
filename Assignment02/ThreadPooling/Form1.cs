using System;
using System.Windows.Forms;
using System.Threading;

namespace ThreadPooling
{
   public partial class Form1 : Form
   {
      public Form1( )
      {
         InitializeComponent( );
      }

      private void voBtnStart_Click(object sender, System.EventArgs e)
      {
         ManualResetEvent koMR = new ManualResetEvent( false );         // Gate is closed
         TcSimpleWorker   koSW = new TcSimpleWorker( 25, koMR );
         WaitCallback     koWC = new WaitCallback( koSW.MMainCompute ); // WaitCallback is pointing to MainCompute

         // Create a launch ThreadPool thread
         int kiMaxWorkerThreads   = 0;
         int kiMaxCompletionPorts = 0;
         ThreadPool.GetMaxThreads( out kiMaxWorkerThreads, out kiMaxCompletionPorts );
         MessageBox.Show( kiMaxWorkerThreads.ToString( ) );
         ThreadPool.QueueUserWorkItem( koWC, DateTime.Now );
         // No start method in threadpool, above line starts the thread
         koMR.WaitOne( );  // Wait for thread to finish
         MessageBox.Show( "Result = " + koSW.VdResult.ToString( ) );
      }

      private void voBtnTPArray_Click(object sender, EventArgs e)
      {
         TcWorker[ ]         koWorkers = new TcWorker[ 10 ];
         ManualResetEvent[ ] koMR      = new ManualResetEvent[ 10 ];
         for( int kiI = 0; kiI < 10; kiI++ )
         {
            koMR[ kiI ] = new ManualResetEvent( false );
            koWorkers[ kiI ] = new TcWorker( koMR[ kiI ], kiI );
            ThreadPool.QueueUserWorkItem( koWorkers[ kiI ].ThreadPoolCallback, kiI );
         }
         WaitHandle.WaitAll( koMR );
         MessageBox.Show( "All threads done.." );
         string koOut1 = "";
         for( int kiI = 0; kiI < 10; kiI++ )
         {
            koOut1 += koWorkers[ kiI ].ViWorkerNum.ToString( ) + " " + koWorkers[ kiI ].VdResult.ToString( ) + "\n";
         }
         MessageBox.Show( koOut1 );
      }
   }
}
