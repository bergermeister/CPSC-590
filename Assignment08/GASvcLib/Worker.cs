namespace GASvcLib
{
   namespace Servant
   {
      using System;
      using System.Collections;
      using System.ServiceModel;
      using System.Threading.Tasks;

      [ ServiceBehavior( InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single ) ]
      public class Worker : IGeneticAlgorithm, IWorker, ICallback
      {
         public Member[ ]        voPopulation;          ///< Population Members
         public int              viSizeMem;             ///< Size of Members
         public int              viSizePop;             ///< Size of Population
         public float            vfRateMutat = 0.05f;   ///< Mutation Rate
         public float            vfRateCross = 0.50f;   ///< Crossover Rate
         public int[ ][ ]        viDistance;            ///< Distance Matrix
         public Member           voBest;                ///< Best Member
         public int              viIter;                ///< Iteration Count
         int                     viWorkerNum;

         public void MUpdateResult( Member aoMember )
         {
            throw new NotImplementedException( );
         }

         public void MInitialize( int aiSizePop, int aiNumCities, float afRateMutate, float afRateCross, int[ ][ ] aiDistMat, int aiWorkerNum ) 
         {
            this.vfRateMutat  = afRateMutate;
            this.viSizeMem    = aiNumCities + 1; // start and end city is 0
            this.vfRateCross  = afRateCross;

            this.viDistance = new int[ aiDistMat.Length ][ ];
            Parallel.For( 0, aiDistMat.Length, ( i ) =>
            {
               this.viDistance[ i ] = new int[ aiDistMat[ i ].Length ];
               for( int j = 0; j < aiDistMat[ i ].Length; j++ )
               {
                  this.viDistance[ i ][ j ] = aiDistMat[ i ][ j ];
               }
            } );

            this.voPopulation = new Member[ aiSizePop ];
            for( int i = 0; i < aiSizePop; i++ )
            {
               this.voPopulation[i] = new Member( viSizeMem, viDistance );
            } 
            this.viSizePop = aiSizePop;

            this.viWorkerNum  = aiWorkerNum;
         
            this.MInitializePopulation( );
            this.MEvaluatePopulation( );
            Array.Sort( this.voPopulation );                 // sort population
         }

         public void MRun( int aiIterations )
         {
            int kiBestFitness = this.voPopulation[ 0 ].ViFitness;
            voBest = ( Member )voPopulation[ 0 ].Clone( );

            for (int j = 0; j < aiIterations; j++)
            {
               // each loop is one generation
               this.MSelectPopulation( );
               this.MCrossoverPopulation( );
               this.MEvaluatePopulation( );
               Array.Sort( this.voPopulation );  // sort population

               if( this.voPopulation[ 0 ].ViFitness < this.voBest.ViFitness )
               {
                  this.voBest = ( Member )voPopulation[ 0 ].Clone( );
               }
               viIter = j;

               this.MMutatePopulation( );
               this.MEvaluatePopulation( );
               Array.Sort( this.voPopulation );  // sort population

               if( this.voPopulation[ 0 ].ViFitness < kiBestFitness )
               {
                  kiBestFitness = voPopulation[ 0 ].ViFitness;
               }
            }
         }

         #region IGeneticAlgorithm Members

         public void MInitializePopulation()
         {
            for( int i = 0; i < this.viSizePop; i++ )
            {
               this.voPopulation[ i ].InitializeMember( );
               //for (int j = 1; j < viSizeMem - 1; j++)
               //{
               //   if (voPopulation[i].ViMem[j] == 0)
               //   {
               //      MessageBox.Show(voPopulation[i].ToString() + ";" + i.ToString());
               //   }
               //}
            }
         }

         public void MEvaluatePopulation( )
         {
            for( int i = 0; i < this.viSizePop; i++ )
            {
               this.voPopulation[ i ].EvaluateMember( );
            }
         }

         public void MSelectPopulation( )
         {
            int i, j;
         
            // Drop 30% of population. Duplicate top 30% of population.
            j = 0;  
            for( i = ( int )( 0.7 * this.viSizePop ); i < this.viSizePop; i++ )
            {
               this.voPopulation[ i ] = ( Member )( this.voPopulation[ j ].Clone( ) );
               j = j + 1;
            }
         }

         public void MCrossoverPopulation( )
         {
            // randomize the population before selecting parents
            Random   koRand = new Random( System.DateTime.Now.Millisecond );
            Member koTemp;
            Member koCross1, koCross2;  // Crossover Members
            int      kiPos1, kiPos2;
            int      kiPar1, kiPar2;  // Parents 1 and 2
            int      kiI, kiJ, kiK;    // Loop iterators
            int      kiCut1, kiCut2;
            int      kiStartPos;
            Hashtable koHash1 = new Hashtable();
            Hashtable koHash2 = new Hashtable();

            for( kiI = 0; kiI < ( this.viSizePop * 10 ); kiI++)
            {
               kiPos1 = ( int )( koRand.NextDouble( ) * this.viSizePop );
               if( kiPos1 == this.viSizePop )
               {
                  kiPos1 = this.viSizePop - 1;
               }

               kiPos2 = ( int )( koRand.NextDouble( ) * this.viSizePop );
               if( kiPos2 == this.viSizePop )
               {
                  kiPos2 = this.viSizePop - 1;
               }

               if( kiPos1 != kiPos2 )
               {
                  koTemp = this.voPopulation[ kiPos1 ];
                  this.voPopulation[ kiPos1 ] = this.voPopulation[ kiPos2 ];
                  this.voPopulation[ kiPos2 ] = koTemp;
               }
            }

            // pick 2 parents and do crossover
            // First parent starts from the beginning, second from
            // middle, recall the population has already been mixed up.
         
            for( kiI = 0; kiI < ( int )( ( this.vfRateCross / 2.0f ) * this.viSizePop ); kiI++ )
            {
               kiPar1 = kiI; kiPar2 = kiI + ( int )( 0.5 * this.viSizePop );
               koCross1 = ( Member )this.voPopulation[ kiPar1 ].Clone( );
               koCross2 = ( Member )this.voPopulation[ kiPar2 ].Clone( );

               //--------------transferring Genes to children -----------
               // 1/4 to 3/4 cut is made to transfer 1/2 tour to a child
               // rest of the information is transferred in cyclic order
               // from the other parent
               kiCut1 = ( int )Math.Ceiling( this.viSizeMem / 4.0 );
               kiCut2 = ( int )Math.Floor( this.viSizeMem * 3.0 / 4.0 );
               koHash1.Clear( );
               koHash2.Clear( );
               for( kiJ = kiCut1; kiJ < kiCut2; kiJ++ )
               {
                  //		c1.mem[i] = pop[p1].mem[i];// already cloned
                  //		c2.mem[i] = pop[p2].mem[i];
                  koHash1.Add( koCross1.ViMem[ kiJ ], -1 );  // value does not matter
                  koHash2.Add( koCross2.ViMem[ kiJ ], -1 );
               }
               koCross1.ViMem[ 0 ] = 0; 
               koHash1.Add( 0, -1 );
               koCross1.ViMem[ this.viSizeMem - 1 ] = 0; // start, end city is 0
               koCross2.ViMem[ 0 ] = 0; 
               koHash2.Add( 0, -1 );
               koCross2.ViMem[ this.viSizeMem - 1 ] = 0; // start, end city is 0

               // now do a circular addition of tour from the second parent
               kiStartPos = 1;
               for( kiJ = 1; kiJ < kiCut1; kiJ++ )
               {
                  for( kiK = 0; kiK < this.viSizeMem; kiK++ )
                  { 
                     if( ( koHash1.Contains( this.voPopulation[ kiPar2 ].ViMem[ kiStartPos ] ) ) == false )
                     {
                        koHash1.Add( this.voPopulation[ kiPar2 ].ViMem[ kiStartPos ], -1 );
                        koCross1.ViMem[ kiJ ] = this.voPopulation[ kiPar2 ].ViMem[ kiStartPos ];
                        kiStartPos = ( kiStartPos + 1 ) % this.viSizeMem;
                        break;
                     }
                     else
                     {
                        kiStartPos = ( kiStartPos + 1 ) % this.viSizeMem;
                     }
                  }
               }

               //---from cut2 to memSize-1, copy second parent's genes
               //startpos = cut2;
               for( kiJ = kiCut2; kiJ < this.viSizeMem - 1; kiJ++ )
               {
                  for( kiK = 0; kiK < this.viSizeMem; kiK++ )
                  {
                     if( ( koHash1.Contains( this.voPopulation[ kiPar2 ].ViMem[ kiStartPos ] ) ) == false )
                     {
                        koHash1.Add( this.voPopulation[ kiPar2 ].ViMem[ kiStartPos ], -1 );
                        koCross1.ViMem[ kiJ ] = this.voPopulation[ kiPar2 ].ViMem[ kiStartPos ];
                        kiStartPos = ( kiStartPos + 1 ) % this.viSizeMem;
                        break;
                     }
                     else
                     {
                        kiStartPos = ( kiStartPos + 1 ) % this.viSizeMem;
                     }
                  }
               }

               //--------now for the second child
               kiStartPos = 1;
               for( kiJ = 1; kiJ < kiCut1; kiJ++ )
               {
                  for( kiK = 0; kiK < this.viSizeMem; kiK++ )
                  {
                     if( ( koHash2.Contains( this.voPopulation[ kiPar1 ].ViMem[ kiStartPos ] ) ) == false )
                     {
                        koHash2.Add( this.voPopulation[ kiPar1 ].ViMem[ kiStartPos ], -1 );
                        koCross2.ViMem[ kiJ ] = this.voPopulation[ kiPar1 ].ViMem[ kiStartPos ];
                        kiStartPos = ( kiStartPos + 1 ) % this.viSizeMem;
                        break;
                     }
                     else
                     {
                        kiStartPos = ( kiStartPos + 1 ) % this.viSizeMem;
                     }
                  }
               }

               //---from cut2 to memSize-1, copy first parent's genes
               kiStartPos = kiCut2;
               for( kiJ = kiCut2; kiJ < ( this.viSizeMem - 1 ); kiJ++ )
               {
                  for( kiK = 0; kiK < this.viSizeMem; kiK++ )
                  {
                     if( ( koHash2.Contains( this.voPopulation[ kiPar1 ].ViMem[ kiStartPos ] ) ) == false )
                     {
                        koHash2.Add( this.voPopulation[ kiPar1 ].ViMem[ kiStartPos ], -1 );
                        koCross2.ViMem[ kiJ ] = this.voPopulation[ kiPar1 ].ViMem[ kiStartPos ];
                        kiStartPos = ( kiStartPos + 1 ) % this.viSizeMem;
                        break;
                     }
                     else
                     {
                        kiStartPos = ( kiStartPos + 1 ) % this.viSizeMem;
                     }
                  }
               }

               this.voPopulation[ kiPar1 ] = koCross1;   // parents p1, p2 are replaced by their children
               this.voPopulation[ kiPar2 ] = koCross2;
               this.voPopulation[ kiPar1 ].EvaluateMember( );
               this.voPopulation[ kiPar2 ].EvaluateMember( );
            }
         }

         public void MMutatePopulation( )
         {
            Random koRand = new Random( System.DateTime.Now.Millisecond );
            int    kiPos, kiRNum, kiPopNum = 0;
            int    kiXPos, kiTemp;
            bool   kbRandomXChange;

            for( int i = 0; i < ( int )( this.viSizePop * this.viSizeMem * this.vfRateMutat ); i++ )
            {
               kiPos = 0;
               while( ( kiPos == 0) || ( kiPos == ( viSizeMem - 1 ) ) )
               {
                  kiRNum = ( int )( this.viSizePop * this.viSizeMem * koRand.NextDouble( ) );
                  kiPos = kiRNum % this.viSizeMem;
                  kiPopNum = ( kiRNum / viSizeMem );
               }

               //---exchange with the previous neighbor, but sometimes
               //   exchange with a random position in the current tour
               kiXPos = 0; 
               kiTemp = 0;
               kbRandomXChange = true;
               if( koRand.NextDouble( ) < 0.7 )
               {
                  if( kiPos > 2 )
                  {
                     kiXPos = kiPos - 1;
                     kiTemp = voPopulation[ kiPopNum ].ViMem[ kiPos ];
                     this.voPopulation[ kiPopNum ].ViMem[ kiPos ] = this.voPopulation[ kiPopNum ].ViMem[ kiXPos ];
                     this.voPopulation[ kiPopNum ].ViMem[ kiXPos ] = kiTemp;
                     kbRandomXChange = false;
                  }
               }
               if( kbRandomXChange == true )
               {
                  kiXPos = 0;
                  while( ( kiXPos == 0) || ( kiXPos == this.viSizeMem ) || ( kiXPos == ( this.viSizeMem - 1 ) ) )
                  {
                     kiXPos = ( int )( koRand.NextDouble( ) * viSizeMem );
                  }
                  kiTemp = voPopulation[ kiPopNum ].ViMem[ kiPos ];
                  voPopulation[ kiPopNum ].ViMem[ kiPos ] = voPopulation[ kiPopNum ].ViMem[ kiXPos ];
                  voPopulation[ kiPopNum ].ViMem[ kiXPos ] = kiTemp;
               }
            }
         }

         #endregion

         public void printPopulation()
         {
            for( int i = 0; i < this.viSizePop; i++ )
            {
               this.voPopulation[ i ].ToString( );
            }
         }

         public Member this[ int aiMember ]  // creating indexer
         {
            get { return( this.voPopulation[ aiMember ] ); }
            set { this.voPopulation[ aiMember ] = ( Member )value; }
         }
      }
   }
}
