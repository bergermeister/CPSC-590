using System;
using System.Threading;

namespace MultiThreading
{
   class TcTime
   {
      private int viHours = 3;
      private int viMins  = 59;
      private int viSecs  = 59;
      private object voLock = new object( );

      public void MIncrementTime( )
      {
         lock( this.voLock )
         {
            this.viSecs++;
            if( this.viSecs == 60 )
            {
               this.viSecs = 0;
               this.viMins++;
               if( this.viMins == 60 )
               {
                  this.viMins = 0;
                  Thread.Sleep( 100 ); // Preempt
                  this.viHours++;
               }
            }
         }
      }

      public void MReadTime( )
      {
         lock( this.voLock )
         {
            Console.WriteLine( this.viHours.ToString( ) + ":" +
                               this.viMins.ToString( ) + ":" +
                               this.viSecs.ToString( ) );
         }
      }
   }
}
