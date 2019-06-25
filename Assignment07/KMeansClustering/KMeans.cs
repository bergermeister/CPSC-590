using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeansClustering
{
   class KMeans
   {
      public static int MDoKMeansWithMinVariance( int aiNumClusters, 
                                                  ref List< MyPoint > aoPList, 
                                                  ref List< ClusterCenterPoint > aoCL,             
                                                  double adMaxError, int aiMaxIterations, bool abMinVariance )
      {
         string koOut;
         double kdStdDev = 0;
         double kdStdDevCopy = 0;
         double kdVariance = 0;
         int    kiIter = 0;
         List< MyPoint > koPListBest = new List< MyPoint >( );             
         List< MyPoint > koPListCopy;
         List< ClusterCenterPoint > koCListBest = new List< ClusterCenterPoint >( );
         List< ClusterCenterPoint > koCListCopy;
         int[ ] kiCCount = new int[ aiNumClusters ];

         if( abMinVariance == true )
            kdStdDev = double.MaxValue;
         else
            kdStdDev = double.MinValue; 

         for( int m = 0; m < 20; m++ ) // pick best i.e., most balanced clustering
         {                             // of 20 attempts at custering 
            koPListCopy = new List<MyPoint>( );              
            foreach( MyPoint koMP in aoPList )
               koPListCopy.Add( ( MyPoint )koMP.Clone( ) );
            
            koCListCopy = null;
            kiIter += KMeans.MDoKMeans( aiNumClusters, ref koPListCopy, ref koCListCopy, 0.01, 100, true ); // true means do kmeansplusplus                 
            // ----compute variance of cluster memberships                 
            for( int i = 0; i < aiNumClusters; i++ )
               kiCCount[ i ] = 0;
            
            foreach( MyPoint koMP in koPListCopy )
               kiCCount[ koMP.ViClusterId ] += 1;
            
            kdVariance = 0;                 
            for( int i = 0; i < aiNumClusters; i++ )
               kdVariance += ( kiCCount[ i ] - ( koPListCopy.Count / ( double )aiNumClusters ) ) * 
                             ( kiCCount[ i ] - ( koPListCopy.Count / ( double )aiNumClusters ) );
            kdStdDevCopy = Math.Sqrt( kdVariance ); 
 
            koOut = "";
            for( int n = 0; n < kiCCount.Length; n++ )
               koOut += "Cluster " + n.ToString( ) + " count = " + kiCCount[ n ].ToString() + "\n";
            //MessageBox.Show( "StdDev = " + koStdDevCopy.ToString( ) + " " + koOut );
            if( abMinVariance == true )
            {
               if( kdStdDevCopy < kdStdDev ) // if it improves, copy data into best
               {
                  kdStdDev = kdStdDevCopy;
                  koPListBest.Clear( );
                  foreach( MyPoint koMP in koPListCopy )
                     koPListBest.Add( ( MyPoint )koMP.Clone( ) );
                  koCListBest.Clear( );
                  foreach( ClusterCenterPoint koCP in koCListCopy )
                     koCListBest.Add( ( ClusterCenterPoint )koCP.Clone( ) );
               }
            }    
            else
            {
               if( kdStdDevCopy > kdStdDev )   // if it improves, copy data into best
               {
                  kdStdDev = kdStdDevCopy;
                  koPListBest.Clear( );
                  foreach( MyPoint koMP in koPListCopy )
                     koPListBest.Add( ( MyPoint )koMP.Clone( ) );
                  koCListBest.Clear( );
                  foreach( ClusterCenterPoint koCP in koCListCopy )
                     koCListBest.Add( ( ClusterCenterPoint )koCP.Clone( ) );
               }
            }
         }

         aoCL = koCListBest;
         aoPList = koPListBest;
         
         return( kiIter );
      } 
 
      public static int MDoKMeans( int aiNumClusters, 
                                   ref List< MyPoint > aoPList, 
                                   ref List< ClusterCenterPoint > aoCL, 
                                   double adMaxError, int aiMaxIterations, bool abDoKmeansPlusPlus = false )
      {
         List< ClusterCenterPoint > koCList = null;
         List< ClusterCenterPoint > koCListNew = null;
         ClusterCenterPoint         koCPNew;
         double kdError = double.MaxValue;      
         double kdErr;
         double kdPrevDist;
         double kdDist;
         int    kiIteration = 0; 
         int    kiK;
         int    kiKnew;
         int    kiC0Count;
         int    kiC1Count;
         int    kiC2Count;
         int[ ] kiCCount;
         
         if( abDoKmeansPlusPlus == false )
            MInitializeCentersRandomlyFromGivenPoints( aoPList, ref koCList, aiNumClusters );
         else
            MInitializeCentersRandomlyFromKPP( aoPList, ref koCList, aiNumClusters ); 
 
         while( ( kiIteration < aiMaxIterations ) || ( kdError < adMaxError ) )
         {
            // determine which clusetr each point belongs to
            foreach( MyPoint koP in aoPList )
            {
               // determine which cluster it belongs to
               kiK = 0;
               kdPrevDist = double.MaxValue;
               foreach( ClusterCenterPoint koCP in koCList )
               {
                  kdDist = MFindDistance( koP.VdX, koP.VdY, koCP.VdCx, koCP.VdCy );
                  if( kdDist < kdPrevDist )
                  {
                     kdPrevDist = kdDist;
                     koP.ViClusterId = kiK;
                  }
                  kiK++;
               }
            } 
 
            kiC0Count = ( from koP in aoPList where koP.ViClusterId == 0 select koP ).ToList< MyPoint >( ).Count;
            kiC1Count = ( from koP in aoPList where koP.ViClusterId == 1 select koP ).ToList< MyPoint >( ).Count; 
            kiC2Count = ( from koP in aoPList where koP.ViClusterId == 2 select koP ).ToList< MyPoint >( ).Count; 

            // ---------------Recompute cluster centers-------------------
            koCListNew = new List<ClusterCenterPoint>();
            kiCCount = new int[ koCList.Count ]; 
            foreach( ClusterCenterPoint koCP in koCList )
            {                     
               koCPNew = new ClusterCenterPoint( );                     
               koCListNew.Add( koCPNew );                     
               koCPNew.VdCx = 0;                     
               koCPNew.VdCy = 0;                 
            }                 
            foreach( MyPoint koP in aoPList )                
            {                     
               koCListNew[ koP.ViClusterId ].VdCx += koP.VdX;                     
               koCListNew[ koP.ViClusterId ].VdCy += koP.VdY;                    
               kiCCount[ koP.ViClusterId ]++;                 
            }                 
            kiKnew = 0;                 
            foreach( ClusterCenterPoint koCP in koCListNew )                 
            {                     
               koCP.VdCx = koCP.VdCx / kiCCount[ kiKnew ];                     
               koCP.VdCy = koCP.VdCy / kiCCount[ kiKnew ];                     
               kiKnew++;                 
            }
            //------------------end recompute cluster centers----------------- 
 
            //---------------see if new centers are different from previous---                 
            kdErr = 0;                 
            for( int i = 0; i < koCList.Count; i++ )                     
               kdErr += ( ( koCListNew[ i ].VdCx - koCList[ i ].VdCx ) * ( koCListNew[ i ].VdCx - koCList[ i ].VdCx ) +
                          ( koCListNew[ i ].VdCy - koCList[ i ].VdCy ) * ( koCListNew[ i ].VdCy - koCList[ i ].VdCy ) );                 
            if( kdErr < adMaxError )
               break;              
            
            koCList.Clear( );                 
            koCList = koCListNew;                 
            kiIteration++;             
         }             
         aoCL = koCList;
         
         return( kiIteration );        
      } 
 
      public static void MInitializeCentersRandomlyBetweenMaxMinRanges( List< MyPoint > aoPList, ref List< ClusterCenterPoint > aoCList, int aiNumClusters )
      {             
         ClusterCenterPoint koCP;
         int                kiNum;

         // determine ranges             
         double kdMinX = ( from koP in aoPList select koP.VdX ).Min( );
         double kdMinY = ( from koP in aoPList select koP.VdY ).Min( );
         double kdMaxX = ( from koP in aoPList select koP.VdX ).Max( );
         double kdMaxY = ( from koP in aoPList select koP.VdX ).Max( );
         
         // initialize cluster centers randomly 
         Random koRand = new Random( ( int )DateTime.Now.Ticks );
         
         aoCList = new List< ClusterCenterPoint >( );
         for( int i = 0; i < aiNumClusters; i++ )
         {
            //ClusterCenterPoint cp = new ClusterCenterPoint { Cx = rand.NextDouble() * (maxX - minX), Cy = rand.NextDouble() * (maxY - minY) };                 
            kiNum = ( int )koRand.NextDouble( ) * aoPList.Count;
            koCP = new ClusterCenterPoint{ VdCx = aoPList[ kiNum ].VdX, VdCy = aoPList[ kiNum ].VdY };
            koCP.ViClusterID = i;
            aoCList.Add( koCP );
         }
      } 
 
      public static void MInitializeCentersRandomlyFromGivenPoints( List< MyPoint > aoPList, ref List< ClusterCenterPoint > aoCList, int aiNumClusters )
      {
         ClusterCenterPoint koCP;
         Random             koRand = new Random( ( int )DateTime.Now.Ticks );
         List< int >        koPListInt = new List< int >( ); 
         int                kiNum;
         
         aoCList = new List< ClusterCenterPoint >( );
         for( int i = 0; i < aoPList.Count; i++ )
            koPListInt.Add( i );
         
         for( int i = 0; i < aiNumClusters; i++ )
         {
            kiNum = koRand.Next( koPListInt.Count );
            koCP = new ClusterCenterPoint{ VdCx = aoPList[ kiNum ].VdX, VdCy = aoPList[ kiNum ].VdY };
            koCP.ViClusterID = i;                 
            koPListInt.RemoveAt( kiNum ); // remove the number that has been selected so that it does not get selected again                
            aoCList.Add( koCP );
         }
         
         if( aoCList.Count < aiNumClusters )
            throw new Exception( "problem in initializing cluster centers.." ); 
      } 
 
 
      public static void MInitializeCentersRandomlyFromKPP( List< MyPoint > aoPList, ref List< ClusterCenterPoint > aoCList, int aiNumClusters )
      {
         Random             koRand = new Random( ( int )DateTime.Now.Ticks );
         List< int >        koPListInt = new List< int >( );
         int                kiNum;
         double             kdRandom;
         double             kdSumProbab;
         double             kdDist;
         double             kdDistPrev;
         double             kdDxSquared;
         double[ ]          kdDxPrimeSquared;
         ClusterCenterPoint koCP;

         aoCList = new List< ClusterCenterPoint >( );
         for( int i = 0; i < aoPList.Count; i++ )
            koPListInt.Add( i ); 
 
         //step1: of KPP - choose a center randomly from given set of points
         kiNum = koRand.Next( koPListInt.Count );
         koCP = new ClusterCenterPoint{ VdCx = aoPList[ kiNum ].VdX, VdCy = aoPList[ kiNum ].VdY };
         koCP.ViClusterID = 0;
         koPListInt.RemoveAt( kiNum ); // remove the number that has been selected so that it does not get selected again            
         aoCList.Add( koCP ); 
 
         for( int i = 1; i < aiNumClusters; i++ )             
         {                 // Step2: Compute D(x)^2  where D(x) is the distance of x from closest centers chosen.                 
            kdDxSquared = 0;
            kdDxPrimeSquared = new double[ koPListInt.Count ];  
            
            for( int m = 0; m < koPListInt.Count; m++ )       
            {                     
               kdDistPrev = double.MaxValue;
               foreach( ClusterCenterPoint koCCP in aoCList )
               {
                  kdDist = MFindDistance( aoPList[ koPListInt[ m ] ].VdX, aoPList[ koPListInt[ m ] ].VdY, koCCP.VdCx, koCCP.VdCy );
                  if( kdDist < kdDistPrev )
                  {
                     kdDistPrev = kdDist;
                  }
               }
               
               //dxprimeSquared[PListInt[m]] = distprev * distprev;                     
               kdDxPrimeSquared[ m ] = kdDistPrev * kdDistPrev;  // dxprimesquared value is actually for point PListInt[m]                     
               kdDxSquared += kdDistPrev * kdDistPrev;
            } 
            
            // select the center according to probability d(x')^2/(d()^2
            kdRandom = koRand.NextDouble( );
            kdSumProbab = 0;
            for( int n = 0; n < kdDxPrimeSquared.Length; n++ )
            {
               kdSumProbab += ( kdDxPrimeSquared[ n ] / kdDxSquared );
               if( kdRandom <= kdSumProbab )
               {
                  // choose this PList[PListInt[n]] as the next cluster center                         
                  koCP = new ClusterCenterPoint{ VdCx = aoPList[ koPListInt[ n ] ].VdX, VdCy = aoPList[ koPListInt[ n ] ].VdY };   
                  koCP.ViClusterID = i;                         
                  koPListInt.RemoveAt( n ); // remove the number that has been selected so that it does not get selected again                         
                  aoCList.Add( koCP );                         
                  break;
               }
            }
         }
      } 
 
      public static double MFindDistance( double adX1, double adY1, double adX2, double adY2 )
      {
         return Math.Sqrt( ( adX2 - adX1 ) * ( adX2 - adX1 ) + ( adY2 - adY1 ) * ( adY2 - adY1 ) );         
      } 
 
   }
}
