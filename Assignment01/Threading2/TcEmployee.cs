namespace Threading2
{
   class TcEmployee
   {
      private object voLock1 = new object( );
      private object voLock2 = new object( );
      private int    viHoursWorked;
      private double vdPayRate;

      public int ViHoursWorked
      {
         get{ lock( this.voLock1 ) { return( this.viHoursWorked ); } }
         set{ lock( this.voLock1 ) { this.viHoursWorked = value; } }
      }

      public double VdPayRate
      {
         get{ lock( this.voLock2 ) { return( this.vdPayRate ); } }
         set{ lock( this.voLock2 ) { this.vdPayRate = value; } }
      }

      public double MComputePay( )
      {
         double kdHours = 0.0;
         double kdRate  = 0.0;

         lock( this.voLock1 )
         {
            kdHours = ( double )this.viHoursWorked;
         }

         lock( this.voLock2 )
         {
            kdRate = this.vdPayRate;
         }

         return( kdHours * kdRate );
      }
   }
}
