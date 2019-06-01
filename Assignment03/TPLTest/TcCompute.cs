using System.Threading;

namespace TPLTest
{
   class TcCompute
   {
      private object voLock = new object( );
      private double vdRes;
      private float  vfData1;
      private int    viData2;

      public double VdRes
      {
         get
         {
            double kdRes = 0.0;
            lock( this.voLock )
            {
               kdRes = vdRes;
            }
            return( kdRes );
         }
      }

      public float VfData1
      {
         get
         {
            float kfD1 = 0.0f;
            lock( this.voLock )
            {
               kfD1 = this.vfData1;
            }
            return( kfD1 );
         }

         set
         {
            lock( this.voLock )
            {
               this.vfData1 = value;
            }
         }
      }

      public int ViData2
      {
         get
         {
            int kiD2 = 0;
            lock( this.voLock )
            {
               kiD2 = this.viData2;
            }
            return( kiD2 );
         }
         
         set
         {
            lock( this.voLock )
            {
               this.viData2 = value;
            }
         }
      }

      public void MCompute3( )
      {
         double kdResult = 0.0;
         lock( this.voLock )
         {
            kdResult = this.vfData1 * this.viData2 - 23.33;
         }
         Thread.Sleep( 1000 );
         lock( this.voLock )
         {
            this.vdRes = kdResult;
         }
      }
   }
}
