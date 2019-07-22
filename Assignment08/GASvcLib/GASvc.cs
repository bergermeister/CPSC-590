namespace GASvcLib
{
   using System;
   using System.ServiceModel;

   [ ServiceBehavior( InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple ) ]
   public class GASvc : IGASvc
   {
      private int[ , ] viDistance;
      private int      viNumThreads;

      public void MExecute( int[ ][ ] aiDistMat, int aiNumThreads )
      {
         int kiRow = aiDistMat.Length;
         int kiCol = aiDistMat[ 0 ].Length;

         this.viDistance = new int[ kiRow, kiCol ];

         for( int kiI = 0; kiI < kiRow; kiI++ )
         {
            for( int kiJ = 0; kiJ < kiCol; kiJ++ )
            {
               this.viDistance[ kiI, kiJ ] = aiDistMat[ kiI ][ kiJ ];
            }
         }
         this.viNumThreads = aiNumThreads;
      }

      void ExchangeData( )
      {
         int    kiI;
         Random koRand = new Random( DateTime.Now.Millisecond );
         bool   kbDone = true;
         /*
         while( true )
         {
            for( kiI = 0; kiI < this.viNumThreads; kiI++)  // wait for all threads to synchronize 
            {
               if (TGAs[kiI].IsAlive)
               {
                  if (dataready[kiI] == 0)
                  {
                     lock (GAs[kiI].synchObjsA[kiI])
                     {
                        Monitor.Wait(GAs[kiI].synchObjsA[kiI]);
                     }
                  }
                  lock (lockobj)
                  {
                     dataready[kiI] = 0;
                  }
               }
            }

            //----------exchange data between threads------
            for (kiI = 0; kiI < numThreads; kiI++)
            {
            int t1 = (int)(koRand.NextDouble() * numThreads);
            int t2 = (int)(koRand.NextDouble() * numThreads);
            if (t1 == t2) // while (t1 == t2)
            t2 = (int)(koRand.NextDouble() * numThreads);

            GAMember temp; int m1 = 0; int m2 = 0;
            for (int j = 0; j < TSGAConstants.NumMembersToExchange; j++)  // exchange 3 values
            {
            m1 = (int)(koRand.NextDouble() * TSGAConstants.PopSize);
            m2 = (int)(koRand.NextDouble() * TSGAConstants.PopSize);
            lock (lockobj)
            {
            temp = GAs[t1].pop[m1];
            GAs[t1].pop[m1] = GAs[t2].pop[m2];
            GAs[t2].pop[m2] = temp;
            }
            }
            }
            for (kiI = 0; kiI < numThreads; kiI++)
            {
            lock (lockobj)
            {
            xchgdone[kiI] = 1;
            }
            lock (synchObjsB[kiI])
            {
            Monitor.PulseAll(synchObjsB[kiI]); // tell each thread to proceed
            }
            }
            kbDone = true;
            for (kiI = 0; kiI < numThreads; kiI++)
            {
            if (TGAs[kiI].IsAlive)
            kbDone = false;
            }
            if (kbDone == true)
            break;  // all threads done
         }
         */
      }   
   }
}
