using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMedoidsClustering
{
   [Serializable]
   public class KMedoid< T > where T : new( )
   {
      private readonly Func< T, T, double > voDistance;  /**< Distance Function Delegate */
      private double[ , ]                   vdDistances; /**< Distance Matrix */
      public  int[ ]                        VdMedoids;   /**< Medoid indeces */

      public List< int > VoClusters{ get; set; }

      public KMedoid( Func< T, T, double > aoDistance )
      {
         this.voDistance = aoDistance;
      }

      public void MCompute( int aiK, List< T > aoInputs )
      {
         bool      kbChanged = true;
         double    kdLastTotalCost;
         int       kiCountIterations = 0;
         int       kiFactorDivider = 1;      // TODO: Is this correct?
         Stopwatch koSW = new Stopwatch( );

         this.VoClusters = new List< int >( );
         this.vdDistances = new double[ aoInputs.Count, aoInputs.Count ];

         for( int i = 0; i < aoInputs.Count - 1; i++ )
         {
            for( int j = i + 1; j < aoInputs.Count; j++ )
            {
               this.vdDistances[ i, j ] = this.voDistance( aoInputs[ i ], aoInputs[ j ] );
               this.vdDistances[ j, i ] = this.vdDistances[ i, j ];
            }
         }

         this.VdMedoids = Enumerable.Range( 1, aiK ).Select( kiX => -1 ).ToArray( );

         this.mInitializeMedoids( aoInputs, aiK );

         kdLastTotalCost = this.mTotalCost( this.VdMedoids, aoInputs );
         koSW.Start( );

         while( kbChanged )
         {
            // For each medoid, try replacing it with a non-medoid
            // If the total score improves, keep the change
            this.VdMedoids = mGetNewMedoids( aiK, ref aoInputs, ref kdLastTotalCost, out kbChanged, kiFactorDivider );
            Console.WriteLine( "Total cost = " + kdLastTotalCost.ToString( ) + " iter=" + kiCountIterations.ToString( ) );
            kiCountIterations++;
            if( ( koSW.ElapsedMilliseconds > 300000 ) || ( kbChanged == false ) )
            {
               break;
            }
         }

         mUpdateClusters( aoInputs );
      }

      private void mInitializeMedoids( List< T > aoInputs, int aiK )
      {
         double[ ]   kdDistanceSums = new double[ aoInputs.Count ];
         double[ , ] kdP = new double[ aoInputs.Count, aoInputs.Count ];
         double[ ]   kdPSum = new double[ aoInputs.Count ];
         double[ ]   kdMedoidDistanceSums;
         double      kdPO;
         int         kiQ;

         for( int i = 0; i < aoInputs.Count; i++ )
         {
            for( int j = 0; j < aoInputs.Count; j++ )
            {
               kdDistanceSums[ i ] += this.vdDistances[ i, j ];
            }
         }

         for( int i = 0; i < aoInputs.Count; i++ )
         {
            for( int j = 0; j < aoInputs.Count; j++ )
            {
               kdP[ i, j ] += this.vdDistances[ i, j ] / kdDistanceSums[ i ];
            }
         }

         for( int i = 0; i < aoInputs.Count; i++ )
         {
            for( int j = 0; j < aoInputs.Count; j++ )
            {
               kdPSum [ i ] = kdP[ j, i ];
            }
         }

         this.VdMedoids[ 0 ] = Array.IndexOf( kdPSum, kdPSum.Min( ) );

         for( int i = 1; i < aiK; i++ )
         {
            kdMedoidDistanceSums = new double[ aoInputs.Count ];
            for( int j = 0; j < i; j++ )
            {
               for( int l = 0; l < aoInputs.Count; l++ )
               {
                  kdMedoidDistanceSums[ l ] += this.vdDistances[ l, this.VdMedoids[ j ] ];
               }
            }
            if( this.VdMedoids.Contains( Array.IndexOf( kdMedoidDistanceSums, kdMedoidDistanceSums.Max( ) ) ) == true )
            {
               kiQ = 0;
               while( kiQ >= 0 )
               {
                  kdPO = Array.IndexOf( kdMedoidDistanceSums, kdMedoidDistanceSums.OrderByDescending( a => a ).Distinct( ).Skip( kiQ ).First( ) );
                  if( this.VdMedoids.Contains( Array.IndexOf( kdMedoidDistanceSums, kdMedoidDistanceSums.OrderByDescending( a => a ).Distinct( ).Skip( kiQ ).First( ) ) ) == false )
                  {
                     this.VdMedoids[ i ] = Array.IndexOf( kdMedoidDistanceSums, kdMedoidDistanceSums.OrderByDescending( a => a ).Distinct( ).Skip( kiQ ).First( ) );
                     kiQ = -5;
                  }
                  kiQ++;
               }               
            }
            else
            {
               this.VdMedoids[ i ] = Array.IndexOf( kdMedoidDistanceSums, kdMedoidDistanceSums.Max( ) );
            }
         }
      }

      private void mUpdateClusters( List< T > aoInputs )
      {
         for( int i = 0; i < aoInputs.Count; i++ )
         {
            var kdMedoidDistances = this.VdMedoids.Select( x => this.vdDistances[ x, i ] ).ToList( );
            int kiMinIndex = 0;
            double kdMinDistance = double.MaxValue;

            for( int j = 0; j < kdMedoidDistances.Count; j++ )
            {
               if( kdMedoidDistances[ j ] < kdMinDistance )
               {
                  kdMinDistance = kdMedoidDistances[ j ];
                  kiMinIndex = j;
               }
            }

            this.VoClusters.Add( kiMinIndex );
         }
      }
   
      private int[ ] mGetNewMedoids( int aiK, ref List< T > aoInputs, ref double adLastTotalCost, out bool abChanged, int aiFactorDivider )
      {
         var kdNewMedoids = new int[ aiK ];
         for( int i = 0; i < this.VdMedoids.Length; i++ )
         {
            kdNewMedoids[ i ] = this.VdMedoids[ i ];
         }

         for( int i = 0; i < aiK; i++ )
         {
            var kdNonMedoids = Enumerable.Range( 0, aoInputs.Count ).Where( x => !this.VdMedoids.Contains( x ) ).ToList( );
            foreach( int kiT in kdNonMedoids )
            {
               kdNewMedoids[ i ] = kiT;
               var kdCost = this.mTotalCost( kdNewMedoids, aoInputs );
               if( kdCost < adLastTotalCost )
               {
                  abChanged = true;
                  adLastTotalCost = kdCost;
                  return( kdNewMedoids );
               }
            }
            kdNewMedoids[ i ] = this.VdMedoids[ i ];
         }

         abChanged = false;

         return( this.VdMedoids );
      }

      private double mTotalCost( int[ ] aiMedoids, List< T > aoInputs )
      {
         double kdTotalCost = 0;

         for( int i = 0; i < aoInputs.Count; i++ )
         {
            if( !aiMedoids.Contains( i ) )
            {
               kdTotalCost += aiMedoids.Select( x => this.vdDistances[ x, i ] ).Min( );
            }
         }

         return( kdTotalCost );
      }
   }
}
