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

      public void MInitialize( double adMaxX, double adMaxY )
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

            koP.VdXx = koRand.NextDouble( ) * adMaxX; // 20;
            koP.VdXy = koRand.NextDouble( ) * adMaxY; // 20;
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

      public double MRosenbrock( double adX, double adY )
      {
         // Rosenbrock function
         double kdRes = ( ( 1 - adX ) * ( 1 - adX ) ) + 
                        ( 100 * ( adY - ( adX * adX ) ) * ( adY - ( adX * adX ) ) );

         return( kdRes );
      }

      public double MHimmelblau( double adX, double adY )
      {
         double kdA = ( ( adX * adX ) + adY - 11 );
         double kdB = ( adX + ( adY * adY ) - 7 );
         double kdRes = ( kdA * kdA ) + ( kdB * kdB );

         return( kdRes );
      }

      public SwarmResult MDoPS0( )
      {
         // Particle movement to achieve for particle swarm optimization
         int         kiI;
         SwarmResult koSR;

         this.VdGx = this.VoPList[ 0 ].VdXx;
         this.VdGy = this.VoPList[ 0 ].VdXy;

         for( kiI = 0; kiI < 1000; kiI++ )
         {
            this.VdPx = this.VoPList[ 0 ].VdXx;
            this.VdPy = this.VoPList[ 0 ].VdXy;

            foreach( Particle koPt in this.VoPList )
            {
               if( Math.Abs( this.MRosenbrock( koPt.VdXx, koPt.VdXy ) ) <
                   Math.Abs( this.MRosenbrock( this.VdPx, this.VdPy ) ) )
               {
                  this.VdPx = koPt.VdXx;
                  this.VdPy = koPt.VdXy;
               }
            }
            if( Math.Abs( this.MRosenbrock( this.VdPx, this.VdPy ) ) <
                Math.Abs( this.MRosenbrock( this.VdGx, this.VdGy ) ) )
            {
               this.VdGx = this.VdPx;
               this.VdGy = this.VdPy;
            }
            foreach( Particle koPt in this.VoPList )
            {
               koPt.MUpdateVelocity( this.VdPx, this.VdPy, this.VdGx, this.VdGy );
               koPt.MUpdatePosition( );
            }
         }

         koSR = new SwarmResult
         {
            ViID = this.viNum,
            VdX = this.VdGx,
            VdY = this.VdGy,
            VdValue = this.MRosenbrock( this.VdGx, this.VdGy )
         };

         return( koSR );
      }
   
   
      public SwarmResult MDoHimmelblau( )
      {
         int         kiI;
         SwarmResult koSR;

         this.VdGx = this.VoPList[ 0 ].VdXx;
         this.VdGy = this.VoPList[ 0 ].VdXy;

         for( kiI = 0; kiI < 2000; kiI++ )
         {
            this.VdPx = this.VoPList[ 0 ].VdXx;
            this.VdPy = this.VoPList[ 0 ].VdXy;

            foreach( Particle koPt in this.VoPList )
            {
               if( Math.Abs( this.MHimmelblau( koPt.VdXx, koPt.VdXy ) ) <
                   Math.Abs( this.MHimmelblau( this.VdPx, this.VdPy ) ) )
               {
                  this.VdPx = koPt.VdXx;
                  this.VdPy = koPt.VdXy;
               }
            }
            if( Math.Abs( this.MHimmelblau( this.VdPx, this.VdPy ) ) <
                Math.Abs( this.MHimmelblau( this.VdGx, this.VdGy ) ) )
            {
               this.VdGx = this.VdPx;
               this.VdGy = this.VdPy;
            }
            foreach( Particle koPt in this.VoPList )
            {
               koPt.MUpdateVelocity( this.VdPx, this.VdPy, this.VdGx, this.VdGy );
               koPt.MUpdatePosition( );
            }
         }

         koSR = new SwarmResult
         {
            ViID = this.viNum,
            VdX = this.VdGx,
            VdY = this.VdGy,
            VdValue = this.MHimmelblau( this.VdGx, this.VdGy )
         };

         return( koSR );
      }
   }
}
