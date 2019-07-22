namespace GASvcLib
{
   using System;
   using System.Collections;
   using System.Threading;

   public class TSGA : IGeneticAlgorithm
   {
      public GAMember[ ]     voPopulation;          ///< Population Members
      public int             viSizeMem;             ///< Size of Members
      public int             viSizePop;             ///< Size of Population
      public float           vfRateMutat = 0.05f;   ///< Mutation Rate
      public float           vfRateCross = 0.50f;   ///< Crossover Rate
      public static int[ , ] viDistance;            ///< Distance Matrix
      public GAMember        voBest;                ///< Best Member
      public int             viIter;                ///< Iteration Count
      object                 voLock;                ///< Lock object
      int                    viThreadNum;
      int[ ]                 viDataReady;
      int[ ]                 viXchgDone;

      // for mthread exchange version
      public object[] voSynchObjsA;
      public object[] voSynchObjsB;

      public TSGA( int aiSizePop, int aiNumCities, float afRateMutate, float afRateCross, int[ , ] aiDistMat, 
                   ref object aorLock, ref object[ ] aorSyncA, ref object[ ] aorSyncB,
                   int[ ] aiDataReady, int[ ] aiXchgDone, int aiThreadNum ) 
      {
         this.vfRateMutat  = afRateMutate;
         this.viSizeMem    = aiNumCities + 1; // start and end city is 0
         this.vfRateCross  = afRateCross;
         this.voPopulation = new GAMember[ aiSizePop ];
         for( int i = 0; i < aiSizePop; i++ )
         {
            this.voPopulation[i] = new GAMember( viSizeMem, viDistance );
         } 
         this.viSizePop = aiSizePop;
         viDistance     = aiDistMat;
         this.voLock    = aorLock;

         this.viThreadNum  = aiThreadNum;
         this.voSynchObjsA = aorSyncA;
         this.voSynchObjsB = aorSyncB;
         this.viDataReady  = aiDataReady;
         this.viXchgDone   = aiXchgDone;
      }

      public void RunGA( ) // Overall GA with XCHG capabilities 
      {
         int kiBestFitness;

         InitializePopulation( );
         EvaluatePopulation( );
         Array.Sort( this.voPopulation );                 // sort population
         kiBestFitness = this.voPopulation[ 0 ].ViFitness;  // because of indexer
         voBest = (GAMember)voPopulation[0].Clone();
         for (int j = 0; j < TSGAConstants.ViNumIterations; j++)
         {
         // each loop is one generation
         SelectPopulation();
         CrossoverPopulation();
         EvaluatePopulation();
         Array.Sort(voPopulation);  // sort population

         lock (voLock)
         {
         if (voPopulation[0].ViFitness < voBest.ViFitness)
         voBest = (GAMember)voPopulation[0].Clone();
         viIter = j;
         }

         if (((j + 1) % TSGAConstants.ViExchangeAfterIterations) == 0)  // xchange pop every few hundred generations
         {
            lock (voLock)
            {
               viDataReady[viThreadNum] = 1; // data is ready
            }
            lock (voSynchObjsA[viThreadNum])
            {
               Monitor.PulseAll(voSynchObjsA[viThreadNum]); // main will xchg and signal back
            }

            if (viXchgDone[viThreadNum] == 0)
            {
               lock (voSynchObjsB[viThreadNum])
               {
                  Monitor.Wait(voSynchObjsB[viThreadNum]); // wait for main to get done with xchg
               }
            }
            lock (voLock)
            {
               viXchgDone[viThreadNum] = 0;
            }
         }

         MutatePopulation( );
         EvaluatePopulation( );
         Array.Sort( this.voPopulation );  // sort population

            lock (voLock)
            {
               if (voPopulation[0].ViFitness < kiBestFitness)
               {
                  kiBestFitness = voPopulation[0].ViFitness;
               }
            }
         }
      }

      #region IGeneticAlgorithm Members

      public void InitializePopulation()
      {
      for (int i = 0; i < viSizePop; i++)
      {
      voPopulation[i].InitializeMember();
      //for (int j = 1; j < viSizeMem - 1; j++)
      //if (voPopulation[i].ViMem[j] == 0)
      //MessageBox.Show(voPopulation[i].ToString() + ";" + i.ToString());
      }
      }

      public void EvaluatePopulation()
      {
      for (int i = 0; i < viSizePop; i++)
      {
      voPopulation[i].EvaluateMember();
      }
      }

      public void SelectPopulation()
      {
      int i, j; j = 0;  // I am dropping 30% of the worst
      // population. top 30% is duplicated
      for (i = (int)(0.7 * viSizePop); i < viSizePop; i++)
      {
      voPopulation[i] = (GAMember)(voPopulation[j].Clone());
      j = j + 1;
      }
      }

      public void CrossoverPopulation()
      {
      Random r = new Random(System.DateTime.Now.Millisecond);
      // randomize the population before selecting parents
      int pos1, pos2;
      GAMember temp;
      for (int i = 0; i < viSizePop * 10; i++)
      {
      pos1 = (int)(r.NextDouble() * viSizePop);
      if (pos1 == viSizePop)
      pos1 = viSizePop - 1;

      pos2 = (int)(r.NextDouble() * viSizePop);
      if (pos2 == viSizePop)
      pos2 = viSizePop - 1;
      if (pos1 != pos2)
      {
      temp = voPopulation[pos1];
      voPopulation[pos1] = voPopulation[pos2];
      voPopulation[pos2] = temp;
      }
      }

      // pick 2 parents and do crossover
      // First parent starts from the beginning, second from
      // middle, recall the population has already been mixed up.
      int p1, p2;  // two parents
      GAMember c1, c2;
      for (int ii = 0; ii < (int)((vfRateCross / 2.0) * viSizePop); ii++)
      {
      p1 = ii; p2 = ii + (int)(0.5 * viSizePop);
      c1 = (GAMember)voPopulation[p1].Clone();
      c2 = (GAMember)voPopulation[p2].Clone();

      //--------------transferring Genes to children -----------
      // 1/4 to 3/4 cut is made to transfer 1/2 tour to a child
      // rest of the information is transferred in cyclic order
      // from the other parent
      int cut1 = (int)Math.Ceiling(viSizeMem / 4.0);
      int cut2 = (int)Math.Floor(viSizeMem * 3.0 / 4.0);
      Hashtable h1 = new Hashtable();
      Hashtable h2 = new Hashtable();
      int i;
      for (i = cut1; i < cut2; i++)
      {
      //		c1.mem[i] = pop[p1].mem[i];// already cloned
      //		c2.mem[i] = pop[p2].mem[i];
      h1.Add(c1.ViMem[i], -1);  // value does not matter
      h2.Add(c2.ViMem[i], -1);
      }
      c1.ViMem[0] = 0; h1.Add(0, -1);
      c1.ViMem[viSizeMem - 1] = 0; // start, end city is 0
      c2.ViMem[0] = 0; h2.Add(0, -1);
      c2.ViMem[viSizeMem - 1] = 0; // start, end city is 0

      // now do a circular addition of tour from the second parent
      int startpos = 1;
      for (i = 1; i < cut1; i++)
      {
      for (int j = 0; j < viSizeMem; j++)
      {
      if ((h1.Contains(voPopulation[p2].ViMem[startpos])) == false)
      {
      h1.Add(voPopulation[p2].ViMem[startpos], -1);
      c1.ViMem[i] = voPopulation[p2].ViMem[startpos];
      startpos = (startpos + 1) % viSizeMem;
      break;
      }
      else
      startpos = (startpos + 1) % viSizeMem;
      }
      }

      //---from cut2 to memSize-1, copy second parent's genes
      //startpos = cut2;
      for (i = cut2; i < viSizeMem - 1; i++)
      {
      for (int j = 0; j < viSizeMem; j++)
      {
      if ((h1.Contains(voPopulation[p2].ViMem[startpos])) == false)
      {
      h1.Add(voPopulation[p2].ViMem[startpos], -1);
      c1.ViMem[i] = voPopulation[p2].ViMem[startpos];
      startpos = (startpos + 1) % viSizeMem;
      break;
      }
      else
      startpos = (startpos + 1) % viSizeMem;
      }
      }


      //--------now for the second child
      startpos = 1;
      for (i = 1; i < cut1; i++)
      {
      for (int j = 0; j < viSizeMem; j++)
      {
      if ((h2.Contains(voPopulation[p1].ViMem[startpos])) == false)
      {
      h2.Add(voPopulation[p1].ViMem[startpos], -1);
      c2.ViMem[i] = voPopulation[p1].ViMem[startpos];
      startpos = (startpos + 1) % viSizeMem;
      break;
      }
      else
      startpos = (startpos + 1) % viSizeMem;
      }
      }

      //---from cut2 to memSize-1, copy first parent's genes
      startpos = cut2;
      for (i = cut2; i < viSizeMem - 1; i++)
      {
      for (int j = 0; j < viSizeMem; j++)
      {
      if ((h2.Contains(voPopulation[p1].ViMem[startpos])) == false)
      {
      h2.Add(voPopulation[p1].ViMem[startpos], -1);
      c2.ViMem[i] = voPopulation[p1].ViMem[startpos];
      startpos = (startpos + 1) % viSizeMem;
      break;
      }
      else
      startpos = (startpos + 1) % viSizeMem;
      }
      }

      voPopulation[p1] = c1;   // parents p1, p2 are replaced by their children
      voPopulation[p2] = c2;
      voPopulation[p1].EvaluateMember();
      voPopulation[p2].EvaluateMember();
      }

      }

      public void MutatePopulation()
      {
      Random r = new Random(System.DateTime.Now.Millisecond);
      int pos, rnum, popnum = 0;
      for (int i = 0; i < (int)(viSizePop * viSizeMem * vfRateMutat); i++)
      {
      pos = 0;
      while ((pos == 0) || (pos == viSizeMem - 1))
      {
      rnum = (int)(viSizePop * viSizeMem * r.NextDouble());
      pos = rnum % viSizeMem;
      popnum = (int)(rnum / viSizeMem);
      }

      //---exchange with the previous neighbor, but sometimes
      //   exchange with a random position in the current tour
      int exchpos = 0; int temp = 0;
      bool doRandomExchange = true;
      if (r.NextDouble() < 0.7)
      {
      if (pos > 2)
      {
      exchpos = pos - 1;
      temp = voPopulation[popnum].ViMem[pos];
      voPopulation[popnum].ViMem[pos] = voPopulation[popnum].ViMem[exchpos];
      voPopulation[popnum].ViMem[exchpos] = temp;
      doRandomExchange = false;
      }
      }
      if (doRandomExchange == true)
      {
      exchpos = 0;
      while ((exchpos == 0) || (exchpos == viSizeMem)
      || (exchpos == (viSizeMem - 1)))
      exchpos = (int)(r.NextDouble() * viSizeMem);
      temp = voPopulation[popnum].ViMem[pos];
      voPopulation[popnum].ViMem[pos] = voPopulation[popnum].ViMem[exchpos];
      voPopulation[popnum].ViMem[exchpos] = temp;
      }
      }
      }

      #endregion

      public void printPopulation()
      {
      for (int i = 0; i < viSizePop; i++)
      voPopulation[i].ToString();
      }

      public GAMember this[int popmember]  // creating indexer
      {
      get { return voPopulation[popmember]; }
      set { voPopulation[popmember] = (GAMember)value; }
      }

     }
}
