namespace GAWebLib
{
   using System;
   using System.Collections;
   using System.Runtime.Serialization;
   using System.Threading.Tasks;

   [ DataContract ]
   public class Worker : IGeneticAlgorithm
   {
      public static double[ ][ ] VdDistance; ///< Distance Matrix

      [ DataMember ]
      public Member[ ] VoPopulation; ///< Population Members

      [ DataMember ]
      public int ViSizeMem; ///< Size of Members

      [ DataMember ]
      public int ViSizePop; ///< Size of Population

      [ DataMember ]
      public float VfRateMutat = 0.05f;   ///< Mutation Rate

      [ DataMember ]
      public float VfRateCross = 0.50f;   ///< Crossover Rate

      [ DataMember ]
      public Member VoBest; ///< Best Member
      
      [ DataMember ]
      public int ViIter; ///< Iteration Count

      [ DataMember ]
      public int ViWorkerNum;

      public void MInitialize( int aiSizePop, int aiNumCities, float afRateMutate, float afRateCross, int aiWorkerNum ) 
      {
         this.VfRateMutat = afRateMutate;
         this.ViSizeMem   = aiNumCities + 1; // start and end city is 0
         this.VfRateCross = afRateCross;

         this.ViSizePop    = aiSizePop;
         this.VoPopulation = new Member[ this.ViSizePop ];
         for( int i = 0; i < this.ViSizePop; i++ )
         {
            this.VoPopulation[ i ] = new Member( this.ViSizeMem );
         } 

         this.ViWorkerNum  = aiWorkerNum;
         
         this.MInitializePopulation( );
         this.MEvaluatePopulation( );
         Array.Sort( this.VoPopulation );                 // sort population
      }

      public void MRun( int aiIterations )
      {
         double kdBestFitness = this.VoPopulation[ 0 ].VdFitness;
         
         this.VoBest = ( Member )this.VoPopulation[ 0 ].Clone( );

         for( int j = 0; j < aiIterations; j++ )
         {
            // each loop is one generation
            this.MSelectPopulation( );
            this.MCrossoverPopulation( );
            this.MEvaluatePopulation( );
            Array.Sort( this.VoPopulation );  // sort population

            if( this.VoPopulation[ 0 ].VdFitness < this.VoBest.VdFitness )
            {
               this.VoBest = ( Member )VoPopulation[ 0 ].Clone( );
            }
            this.ViIter = j;

            // Let the distributor handle the last evaluation after exchange
            if( j < ( aiIterations - 1 ) )
            {
               this.MMutatePopulation( );
               this.MEvaluatePopulation( );
               Array.Sort( this.VoPopulation );  // sort population

               if( this.VoPopulation[ 0 ].VdFitness < kdBestFitness )
               {
                  kdBestFitness = VoPopulation[ 0 ].VdFitness;
               }
            }
         }
      }

      #region IGeneticAlgorithm Members

      public void MInitializePopulation()
      {
         for( int i = 0; i < this.ViSizePop; i++ )
         {
            this.VoPopulation[ i ].InitializeMember( );
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
         for( int i = 0; i < this.ViSizePop; i++ )
         {
            this.VoPopulation[ i ].EvaluateMember( );
         }
      }

      public void MSelectPopulation( )
      {
         int i, j;
         
         // Drop 30% of population. Duplicate top 30% of population.
         j = 0;  
         for( i = ( int )( 0.7 * this.ViSizePop ); i < this.ViSizePop; i++ )
         {
            this.VoPopulation[ i ] = ( Member )( this.VoPopulation[ j ].Clone( ) );
            j = j + 1;
         }
      }

      public void MCrossoverPopulation( )
      {
         // randomize the population before selecting parents
         Random   koRand = new Random( System.DateTime.Now.Millisecond );
         Member   koTemp;
         Member   koCross1, koCross2;  // Crossover Members
         int      kiPos1, kiPos2;
         int      kiPar1, kiPar2;  // Parents 1 and 2
         int      kiI, kiJ, kiK;    // Loop iterators
         int      kiCut1, kiCut2;
         int      kiStartPos;
         Hashtable koHash1 = new Hashtable( );
         Hashtable koHash2 = new Hashtable( );

         for( kiI = 0; kiI < ( this.ViSizePop * 10 ); kiI++)
         {
            kiPos1 = ( int )( koRand.NextDouble( ) * this.ViSizePop );
            if( kiPos1 == this.ViSizePop )
            {
               kiPos1 = this.ViSizePop - 1;
            }

            kiPos2 = ( int )( koRand.NextDouble( ) * this.ViSizePop );
            if( kiPos2 == this.ViSizePop )
            {
               kiPos2 = this.ViSizePop - 1;
            }

            if( kiPos1 != kiPos2 )
            {
               koTemp = this.VoPopulation[ kiPos1 ];
               this.VoPopulation[ kiPos1 ] = this.VoPopulation[ kiPos2 ];
               this.VoPopulation[ kiPos2 ] = koTemp;
            }
         }

         // pick 2 parents and do crossover
         // First parent starts from the beginning, second from
         // middle, recall the population has already been mixed up.
         
         for( kiI = 0; kiI < ( int )( ( this.VfRateCross / 2.0f ) * this.ViSizePop ); kiI++ )
         {
            kiPar1 = kiI; 
            kiPar2 = kiI + ( int )( 0.5 * this.ViSizePop );
            koCross1 = ( Member )this.VoPopulation[ kiPar1 ].Clone( );
            koCross2 = ( Member )this.VoPopulation[ kiPar2 ].Clone( );

            //--------------transferring Genes to children -----------
            // 1/4 to 3/4 cut is made to transfer 1/2 tour to a child
            // rest of the information is transferred in cyclic order
            // from the other parent
            kiCut1 = ( int )Math.Ceiling( this.ViSizeMem / 4.0 );
            kiCut2 = ( int )Math.Floor( this.ViSizeMem * 3.0 / 4.0 );
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
            koCross1.ViMem[ this.ViSizeMem - 1 ] = 0; // start, end city is 0
            koCross2.ViMem[ 0 ] = 0; 
            koHash2.Add( 0, -1 );
            koCross2.ViMem[ this.ViSizeMem - 1 ] = 0; // start, end city is 0

            // now do a circular addition of tour from the second parent
            kiStartPos = 1;
            for( kiJ = 1; kiJ < kiCut1; kiJ++ )
            {
               for( kiK = 0; kiK < this.ViSizeMem; kiK++ )
               { 
                  if( ( koHash1.Contains( this.VoPopulation[ kiPar2 ].ViMem[ kiStartPos ] ) ) == false )
                  {
                     koHash1.Add( this.VoPopulation[ kiPar2 ].ViMem[ kiStartPos ], -1 );
                     koCross1.ViMem[ kiJ ] = this.VoPopulation[ kiPar2 ].ViMem[ kiStartPos ];
                     kiStartPos = ( kiStartPos + 1 ) % this.ViSizeMem;
                     break;
                  }
                  else
                  {
                     kiStartPos = ( kiStartPos + 1 ) % this.ViSizeMem;
                  }
               }
            }

            //---from cut2 to memSize-1, copy second parent's genes
            //startpos = cut2;
            for( kiJ = kiCut2; kiJ < this.ViSizeMem - 1; kiJ++ )
            {
               for( kiK = 0; kiK < this.ViSizeMem; kiK++ )
               {
                  if( ( koHash1.Contains( this.VoPopulation[ kiPar2 ].ViMem[ kiStartPos ] ) ) == false )
                  {
                     koHash1.Add( this.VoPopulation[ kiPar2 ].ViMem[ kiStartPos ], -1 );
                     koCross1.ViMem[ kiJ ] = this.VoPopulation[ kiPar2 ].ViMem[ kiStartPos ];
                     kiStartPos = ( kiStartPos + 1 ) % this.ViSizeMem;
                     break;
                  }
                  else
                  {
                     kiStartPos = ( kiStartPos + 1 ) % this.ViSizeMem;
                  }
               }
            }

            //--------now for the second child
            kiStartPos = 1;
            for( kiJ = 1; kiJ < kiCut1; kiJ++ )
            {
               for( kiK = 0; kiK < this.ViSizeMem; kiK++ )
               {
                  if( ( koHash2.Contains( this.VoPopulation[ kiPar1 ].ViMem[ kiStartPos ] ) ) == false )
                  {
                     koHash2.Add( this.VoPopulation[ kiPar1 ].ViMem[ kiStartPos ], -1 );
                     koCross2.ViMem[ kiJ ] = this.VoPopulation[ kiPar1 ].ViMem[ kiStartPos ];
                     kiStartPos = ( kiStartPos + 1 ) % this.ViSizeMem;
                     break;
                  }
                  else
                  {
                     kiStartPos = ( kiStartPos + 1 ) % this.ViSizeMem;
                  }
               }
            }

            //---from cut2 to memSize-1, copy first parent's genes
            kiStartPos = kiCut2;
            for( kiJ = kiCut2; kiJ < ( this.ViSizeMem - 1 ); kiJ++ )
            {
               for( kiK = 0; kiK < this.ViSizeMem; kiK++ )
               {
                  if( ( koHash2.Contains( this.VoPopulation[ kiPar1 ].ViMem[ kiStartPos ] ) ) == false )
                  {
                     koHash2.Add( this.VoPopulation[ kiPar1 ].ViMem[ kiStartPos ], -1 );
                     koCross2.ViMem[ kiJ ] = this.VoPopulation[ kiPar1 ].ViMem[ kiStartPos ];
                     kiStartPos = ( kiStartPos + 1 ) % this.ViSizeMem;
                     break;
                  }
                  else
                  {
                     kiStartPos = ( kiStartPos + 1 ) % this.ViSizeMem;
                  }
               }
            }

            this.VoPopulation[ kiPar1 ] = koCross1;   // parents p1, p2 are replaced by their children
            this.VoPopulation[ kiPar2 ] = koCross2;
            this.VoPopulation[ kiPar1 ].EvaluateMember( );
            this.VoPopulation[ kiPar2 ].EvaluateMember( );
         }
      }

      public void MMutatePopulation( )
      {
         Random koRand = new Random( System.DateTime.Now.Millisecond );
         int    kiPos, kiRNum, kiPopNum = 0;
         int    kiXPos, kiTemp;
         bool   kbRandomXChange;

         for( int i = 0; i < ( int )( this.ViSizePop * this.ViSizeMem * this.VfRateMutat ); i++ )
         {
            kiPos = 0;
            while( ( kiPos == 0) || ( kiPos == ( ViSizeMem - 1 ) ) )
            {
               kiRNum = ( int )( this.ViSizePop * this.ViSizeMem * koRand.NextDouble( ) );
               kiPos = kiRNum % this.ViSizeMem;
               kiPopNum = ( kiRNum / ViSizeMem );
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
                  kiTemp = VoPopulation[ kiPopNum ].ViMem[ kiPos ];
                  this.VoPopulation[ kiPopNum ].ViMem[ kiPos ] = this.VoPopulation[ kiPopNum ].ViMem[ kiXPos ];
                  this.VoPopulation[ kiPopNum ].ViMem[ kiXPos ] = kiTemp;
                  kbRandomXChange = false;
               }
            }
            if( kbRandomXChange == true )
            {
               kiXPos = 0;
               while( ( kiXPos == 0) || ( kiXPos == this.ViSizeMem ) || ( kiXPos == ( this.ViSizeMem - 1 ) ) )
               {
                  kiXPos = ( int )( koRand.NextDouble( ) * ViSizeMem );
               }
               kiTemp = VoPopulation[ kiPopNum ].ViMem[ kiPos ];
               VoPopulation[ kiPopNum ].ViMem[ kiPos ] = VoPopulation[ kiPopNum ].ViMem[ kiXPos ];
               VoPopulation[ kiPopNum ].ViMem[ kiXPos ] = kiTemp;
            }
         }
      }

      #endregion

      public void printPopulation()
      {
         for( int i = 0; i < this.ViSizePop; i++ )
         {
            this.VoPopulation[ i ].ToString( );
         }
      }

      public Member this[ int aiMember ]  // creating indexer
      {
         get { return( this.VoPopulation[ aiMember ] ); }
         set { this.VoPopulation[ aiMember ] = ( Member )value; }
      }

      public object Clone( )
      {
         Worker koWorker = new Worker( );

         koWorker.VoPopulation = new Member[ this.VoPopulation.Length ];
         for( int i = 0; i < this.VoPopulation.Length; i++ )
         {
            koWorker.VoPopulation[ i ] = ( Member )this.VoPopulation[ i ].Clone( );
         }

         koWorker.ViSizeMem   = this.ViSizeMem;
         koWorker.ViSizePop   = this.ViSizePop;
         koWorker.VfRateMutat = this.VfRateMutat;
         koWorker.VfRateCross = this.VfRateCross;
         koWorker.VoBest      = this.VoBest; 
         koWorker.ViIter      = this.ViIter; 
         koWorker.ViWorkerNum = this.ViWorkerNum;

         return( koWorker );
      }
   }
}
