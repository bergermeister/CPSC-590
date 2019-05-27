using System.Threading;

namespace SemaphoreTest
{
   class TcLimoCar
   {
      private object    voLock;
      private int       viNumber;
      private int       viTravelTime;
      private int       viCustomers;
      private Semaphore voSemLim = null;

      public TcLimoCar( int aiNum, int aiTime )
      {
         this.viNumber     = aiNum;
         this.viTravelTime = aiTime;   // Specified in seconds
         this.voSemLim     = new Semaphore( 4, 4 );
         // Second parameter indicates max users that can access the resource
         // First parameter, if it is zero, denies access to the resource
         // each access reduces the value in the first parameter
      }

      public int ViNumber
      {
         get{ return( this.viNumber ); }
         set{ this.viNumber = value; }
      }

      public int ViTravelTime
      {
         get{ return( this.viTravelTime ); }
         set{ this.viTravelTime = value; }
      }

      public int ViCustomers
      {
         get{ lock( this.voLock ){ return( this.viCustomers ); } }
      }

      public void MUse( )
      {
         this.voSemLim.WaitOne( );  // Check if gate is open

      }
   }
}
