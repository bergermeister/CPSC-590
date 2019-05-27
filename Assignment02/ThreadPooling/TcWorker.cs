using System;
using System.Threading;

namespace ThreadPooling
{
   class TcWorker
   {
      private ManualResetEvent voMR;
      private object           voLock = new object( );
      private int              viWorkerNum = -1;
      private int              viInputData;
      private double           vdResult;      

      public TcWorker( ManualResetEvent aoMR, int aiInputData )
      {
         this.voMR        = aoMR;
         this.viInputData = aiInputData;
      }

      public int ViWorkerNum
      {
         get{ lock( this.voLock ){ return( this.viWorkerNum ); } }
      }

      public double VdResult
      {
         get{ lock( this.voLock ){ return( this.vdResult ); } }
      }

      public void ThreadPoolCallback( object aoContext )
      {
         double kdRes;
         lock( this.voLock ){ this.viWorkerNum = ( int )aoContext; }
         kdRes = this.MDoWork( this.viInputData );
         lock( this.voLock ){ this.vdResult = kdRes; }
         this.voMR.Set( );
      }

      public double MDoWork( int aiData )
      {
         Thread.Sleep( 2000 );
         return( ( 5.2 * 3.8 ) - 25 + aiData );
      }
   }
}
