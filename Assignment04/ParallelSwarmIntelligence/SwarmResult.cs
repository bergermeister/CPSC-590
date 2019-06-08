using System;

namespace ParallelSwarmIntelligence
{
   class SwarmResult : IComparable< SwarmResult >
   {
      public int    ViID{ get; set; }
      public double VdX{ get; set; }
      public double VdY{ get; set; }
      public double VdValue{ get; set; }

      public override string ToString( )
      {
         return( String.Format( "Swarm ID:{0} X={1} Y={2} Function Value={3}", 
                                this.ViID.ToString( ), 
                                this.VdX.ToString( ), 
                                this.VdY.ToString( ), 
                                this.VdValue.ToString( ) ) );
      }

      public int CompareTo( SwarmResult aoOther )
      {
         return( this.VdValue.CompareTo( aoOther.VdValue ) );
      }
   }
}
