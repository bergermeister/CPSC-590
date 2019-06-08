using System;

namespace ParallelSwarmIntelligence
{
   class Particle
   {
      public double VdW{ get; set; }   /**< Inertia or Weight */
      public double VdC1{ get; set; }  /**< Cognitive social constant 1 */
      public double VdC2{ get; set; }  /**< Cognitive social constant 2  */
      public double VdXx{ get; set; }  /**< Position in X */
      public double VdXy{ get; set; }  /**< Position in Y */
      public double VdVx{ get; set; }  /**< Velocity in X */
      public double VdVy{ get; set; }  /**< Velocity in Y */

      private Random voRand = new Random( );

      public void MUpdateVelocity( double adPx, double adPy, double adGx, double adGy )
      {
         // P is the current best position of any particle in the current swarm
         // G is the global best position discovered for all swarms
         this.VdVx = ( this.VdW * this.VdVx ) + 
                     ( this.VdC1 * this.voRand.NextDouble( ) * ( adPx - this.VdXx ) ) +
                     ( this.VdC2 * this.voRand.NextDouble( ) * ( adGx - this.VdXx ) );

         if( this.VdVx >  5 ) this.VdVx =  5;
         if( this.VdVx < -5 ) this.VdVx = -5;

         this.VdVy = ( this.VdW * this.VdVy ) + 
                     ( this.VdC1 * this.voRand.NextDouble( ) * ( adPy - this.VdXy ) ) +
                     ( this.VdC2 * this.voRand.NextDouble( ) * ( adGy - this.VdXy ) );

         if( this.VdVy >  5 ) this.VdVy =  5;
         if( this.VdVy < -5 ) this.VdVy = -5;
      }

      public void MUpdatePosition( )
      {
         this.VdXx = this.VdXx + this.VdVx;

         if( this.VdXx >  20 ) this.VdXx =  20;
         if( this.VdVx < -20 ) this.VdVx = -20;
         if( this.VdVy >  20 ) this.VdVy =  20;
         if( this.VdVy < -20 ) this.VdVy = -20;
      }
   }
}
