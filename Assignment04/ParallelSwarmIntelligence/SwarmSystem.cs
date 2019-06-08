using System;
using System.Collections.Generic;

namespace ParallelSwarmIntelligence
{
   class SwarmSystem
   {
      public List< Particle > VoPList = new List< Particle >( );
      public double VdPx{ get; set; }
      public double VdPy{ get; set; }
      public double VdGx{ get; set; }
      public double VdGy{ get; set; }

      private int viNum;

      public SwarmSystem( int aiNum )
      {
         this.viNum = aiNum;
      }

      public int ViNum
      {
         get{ return( this.viNum ); }
      }

      public void MInitialize( )
      {
         Random   koRand = new Random( );
         Particle koP;
         double   kdNum;

         for( int kiI = 0; kiI < 50; kiI++ )
         {
            koP = new Particle( );
            koP.VdW  = 0.73;
            koP.VdC1 = 1.4;
            koP.VdC2 = 1.5;

            koP.VdXx = koRand.NextDouble( ) * 20;
            koP.VdXy = koRand.NextDouble( ) * 20;
            kdNum = koRand.NextDouble( );
            if( kdNum > 0.5 )
            {
               koP.VdXx = -1 * koP.VdXx;
               koP.VdXy = -1 * koP.VdXy;
            }

            koP.VdVx = koRand.NextDouble( ) * 5;
            koP.VdVy = koRand.NextDouble( ) * 5;
            kdNum = koRand.NextDouble( );
            if( kdNum > 0.5 )
            {
               koP.VdVx = -1 * koP.VdVx;
               koP.VdVy = -1 * koP.VdVy;
            }

            this.VoPList.Add( koP );
         }
      }

   }
}
