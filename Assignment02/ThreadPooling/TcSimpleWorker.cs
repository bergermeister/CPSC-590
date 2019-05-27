using System;
using System.Threading;

namespace ThreadPooling
{
   class TcSimpleWorker
   {
      private object           voLock = new object( );
      private int              viInputData;
      private double           vdResult;
      private ManualResetEvent voMRE = null;

      public TcSimpleWorker( int aiData, ManualResetEvent aoEvent )
      {
         this.viInputData = aiData;
         this.voMRE       = aoEvent;
      }

      public double VdResult
      {
         get{ lock( this.voLock ){ return( this.vdResult ); } }
      }

      public void MMainCompute( object aoContext )
      {
         double kdRes;

         // Witing to a console does not cause a cross threading error.
         // However, you can only see the Console output if you choose
         // Debug->Start debugging Use Console.Writeline for debugging
         // purposes
         if( aoContext is DateTime )
         {
            Console.WriteLine( ( ( DateTime )aoContext ).ToString( ) );
         }

         kdRes = this.mInternalCompute( );
         Thread.Sleep( 5000 );   // pretend it takes 5 seconds to compute
         lock( this.voLock )
         {
            this.vdResult = kdRes;
         }
         this.voMRE.Set( );
      }

      private double mInternalCompute( )
      {
         return( 45.7575 - ( this.viInputData / 3.097 ) + 45.97 );
      }
   }
}
