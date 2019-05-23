using System;
using System.Threading;

namespace MultiThreading
{
   class Program
   {
      static void Main(string[] args)
      {
         TcTime koTime = new TcTime( );
         Thread koT1 = new Thread( new ThreadStart( koTime.MIncrementTime ) );
         Thread koT2 = new Thread( new ThreadStart( koTime.MReadTime ) );

         koT1.Start( );
         Thread.Sleep( 50 );
         koT2.Start( );

         Console.WriteLine( "Press any key to continue..." );
         Console.ReadKey( );
      }
   }
}
