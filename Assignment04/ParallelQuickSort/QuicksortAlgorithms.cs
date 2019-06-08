using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelQuickSort
{
   class QuicksortAlgorithms
   {
      public static void MQuicksort< T >( T[ ] aoData, int aiLeft, int aiRight )
         where T : IComparable< T >
      {
         int kiPivot;

         if( aiRight > aiLeft )
         {
            kiPivot = mPartition( aoData, aiLeft, aiRight );
            MQuicksort( aoData, aiLeft, kiPivot - 1 );
            MQuicksort( aoData, kiPivot + 1, aiRight );
         }
      }

      public static void MQuicksortParallel< T >( T[ ] aoData, int aiLeft, int aiRight )
         where T : IComparable< T >
      {
         const int xiSequentialThreshold = 1000;

         if( aiRight > aiLeft )
         {
            if( ( aiRight - aiLeft ) < xiSequentialThreshold )
            {
               MQuicksort( aoData, aiLeft, aiRight );
            }
            else
            {
               int kiPivot = mPartition( aoData, aiLeft, aiRight );
               Parallel.Invoke( ( ) => MQuicksortParallel( aoData, aiLeft, kiPivot - 1 ),
                                ( ) => MQuicksortParallel( aoData, kiPivot + 1, aiRight ) );
            }
         }
      }

      private static int mPartition< T >( T[ ] aoData, int aiLow, int aiHigh )
         where T : IComparable< T >
      {
         int kiLeft, kiRight;
         T   koPivotItem;
         int kiPivot;

         koPivotItem = aoData[ aiLow ];
         kiPivot = kiLeft = aiLow;
         kiRight = aiHigh;

         while( kiLeft < kiRight )
         {
            while( aoData[ kiLeft ].CompareTo( koPivotItem ) <= 0 )
            {
               if( kiLeft < ( aoData.Length - 1 ) )
               {
                  kiLeft++;
               }
               else
               {
                  break;
               }
            }
            while( aoData[ kiRight ].CompareTo( koPivotItem ) > 0 )
            {
               if( kiRight > 0 )
               {
                  kiRight--;
               }
               else
               {
                  break;
               }
            }
            if( kiLeft < kiRight )
            {
               mSwap( aoData, kiLeft, kiRight );
            }
         }

         aoData[ aiLow ] = aoData[ kiRight ];
         aoData[ kiRight ] = koPivotItem;

         return( kiRight );
      }

      private static void mSwap< T >( T[ ] aoData, int aiI, int aiJ )
      {
         T koTemp = aoData[ aiI ];
         aoData[ aiI ] = aoData[ aiJ ];
         aoData[ aiJ ] = koTemp;
      }
   }
}
