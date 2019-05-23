using System;
using System.Threading;

namespace Threading2
{
   class TcLongOperations
   {
      private object voLock = new object( );

      private bool   vbTerminate = false;
      private double vdStockPrice;
      private int    viTemperature;
      private int    viData;
      private double vdResult;

      public bool VbTerminate
      {
         set{ lock( this.voLock ) { this.vbTerminate = value; } }
      }

      public double VdStockPrice
      {
         get{ lock( this.voLock ){ return( this.vdStockPrice ); } }
      }

      public int ViTemperature
      {
         get{ lock( this.voLock ){ return( this.viTemperature ); } }
      }

      public int ViData
      {
         get{ lock( this.voLock ){ return( this.viData ); } }
         set{ lock( this.voLock ){ this.viData = value; } }
      }

      public double VdResult
      {
         get{ lock( this.voLock ){ return( this.vdResult ); } }
      }

      public void MCompute( )
      {
         double kdResult = 2.7575 + ( ( double )this.viData / 3.8686 ) - 5.66;
         Thread.Sleep( 5000 );   // Assume it takes 5 secs

         lock( this.voLock )
         {
            this.vdResult = kdResult;
         }
      }

      public void MGetWeather( )
      {
         Random koRN = new Random( ( int )DateTime.Now.Ticks );

         while( true )
         {
            // Suppose we are obtaining temeprature info from a web service and it takes 2 seconds
            // to get data from it
            Thread.Sleep( 2000 ); 

            lock( this.voLock )
            {
               this.viTemperature = 80 + koRN.Next( 2, 8 );
            }
         }
      }

      public void MGetStockPrice( )
      {
         Random koRN = new Random( ( int )DateTime.Now.Ticks );
         bool   kbTerm = false;

         lock( this.voLock )
         {
            kbTerm = this.vbTerminate;
         }

         while( kbTerm == false )
         {
            Thread.Sleep( 3000 );   // Pretend it takes 3 seconds to get the stock price

            lock( this.voLock )
            {
               this.vdStockPrice = 100.0 + ( koRN.NextDouble( ) * 10.0 );
            }

            Thread.Sleep( 10 );  // Pretend it takes 10ms to write to DB
            
            lock( this.voLock )
            {
               kbTerm = this.vbTerminate;
            }
         }
      }
   }
}
