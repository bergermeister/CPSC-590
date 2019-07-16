using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Threading;

namespace TSGAMT2010
{
    public class TSGA : IGeneticAlgorithm
    {
        public GAMember[] pop;
        public int memSize;
        public int popSize;
        public float mutationRate = 0.05f;
        public float crossoverRate = 0.50f;
        public static int[,] DistMat;
        public GAMember bestMember;
        public int iterationCount;
        object lockobj;
        int threadNum;
        int[] dataready;
        int[] xchgdone;

        // for mthread exchange version
        public object[] synchObjsA;
        public object[] synchObjsB;


        public TSGA(int popSz, int numCities, float mutRate, float crossRate,
            int[,] distMat, ref object lockobj) // for mulithreaded version
        {  // constructor
            this.mutationRate = mutRate;
            this.memSize = numCities + 1; // start and end city is 0
            this.crossoverRate = crossRate;
            DistMat = distMat;
            this.pop = new GAMember[popSz];
            for (int i = 0; i < popSz; i++)
                pop[i] = new GAMember(memSize, distMat);
            this.popSize = popSz;
            this.lockobj = lockobj;
        }


        public TSGA(int popSz, int numCities, float mutRate, float crossRate,
            int[,] distMat, ref object lockobj, ref object[] synchObjsA, ref object[] synchObjsB,
            int[] dataready, int[] xchgdone, int threadNum) // for mulithreaded version
        {  // constructor
            this.mutationRate = mutRate;
            this.memSize = numCities + 1; // start and end city is 0
            this.crossoverRate = crossRate;
            this.pop = new GAMember[popSz];
            for (int i = 0; i < popSz; i++)
                pop[i] = new GAMember(memSize, DistMat);
            this.popSize = popSz;
            DistMat = distMat;
            this.lockobj = lockobj;

            this.threadNum = threadNum;
            this.synchObjsA = synchObjsA;
            this.synchObjsB = synchObjsB;
            this.dataready = dataready;
            this.xchgdone = xchgdone;
        }


        

        public void RunGA() // overall GA 
        {
            //----------
            InitializePopulation();
            EvaluatePopulation();
            Array.Sort(pop);  // sort population
            int bestFitness = pop[0].fitness;  // because of indexer
            bestMember = (GAMember)pop[0].Clone();
            for (int j = 0; j < TSGAConstants.NumIterations; j++)
            {
                // each loop is one generation
                SelectPopulation();
                CrossoverPopulation();
                EvaluatePopulation();
                Array.Sort(pop);  // sort population
 
                lock (lockobj)
                {
                    if (pop[0].fitness < bestMember.fitness)
                        bestMember = (GAMember)pop[0].Clone();
                    iterationCount = j;
                }

                MutatePopulation();
                EvaluatePopulation();
                Array.Sort(pop);  // sort population

                lock (lockobj)
                {
                    if (pop[0].fitness < bestFitness)
                    {
                        bestFitness = pop[0].fitness;
                    }
                }
            }
        }


        public void RunGA_XCHG() // overall GA with XCHG capabilities 
        {
            InitializePopulation();
            EvaluatePopulation();
            Array.Sort(pop);  // sort population
            int bestFitness = pop[0].fitness;  // because of indexer
            bestMember = (GAMember)pop[0].Clone();
            for (int j = 0; j < TSGAConstants.NumIterations; j++)
            {
                // each loop is one generation
                SelectPopulation();
                CrossoverPopulation();
                EvaluatePopulation();
                Array.Sort(pop);  // sort population

                lock (lockobj)
                {
                    if (pop[0].fitness < bestMember.fitness)
                        bestMember = (GAMember)pop[0].Clone();
                    iterationCount = j;
                }

                if (((j + 1) % TSGAConstants.ExchangeAfterIterations) == 0)  // xchange pop every few hundred generations
                {
                    lock (lockobj)
                    {
                        dataready[threadNum] = 1; // data is ready
                    }
                    lock (synchObjsA[threadNum])
                    {
                        Monitor.PulseAll(synchObjsA[threadNum]); // main will xchg and signal back
                    }

                    if (xchgdone[threadNum] == 0)
                    {
                        lock (synchObjsB[threadNum])
                        {
                            Monitor.Wait(synchObjsB[threadNum]); // wait for main to get done with xchg
                        }
                    }
                    lock (lockobj)
                    {
                        xchgdone[threadNum] = 0;
                    }
                }


                MutatePopulation();
                EvaluatePopulation();
                Array.Sort(pop);  // sort population

                lock (lockobj)
                {
                    if (pop[0].fitness < bestFitness)
                    {
                        bestFitness = pop[0].fitness;
                    }
                }
            }
        }

        #region IGeneticAlgorithm Members

        public void InitializePopulation()
        {
            for (int i = 0; i < popSize; i++)
            {
                pop[i].InitializeMember();
                for (int j = 1; j < memSize - 1; j++)
                    if (pop[i].mem[j] == 0)
                        MessageBox.Show(pop[i].ToString() + ";" + i.ToString());
            }
        }

        public void EvaluatePopulation()
        {
            for (int i = 0; i < popSize; i++)
            {
                pop[i].EvaluateMember();
            }
        }

        public void SelectPopulation()
        {
            int i, j; j = 0;  // I am dropping 30% of the worst
            // population. top 30% is duplicated
            for (i = (int)(0.7 * popSize); i < popSize; i++)
            {
                pop[i] = (GAMember)(pop[j].Clone());
                j = j + 1;
            }
        }

        public void CrossoverPopulation()
        {
            Random r = new Random(System.DateTime.Now.Millisecond);
            // randomize the population before selecting parents
            int pos1, pos2;
            GAMember temp;
            for (int i = 0; i < popSize * 10; i++)
            {
                pos1 = (int)(r.NextDouble() * popSize);
                if (pos1 == popSize)
                    pos1 = popSize - 1;

                pos2 = (int)(r.NextDouble() * popSize);
                if (pos2 == popSize)
                    pos2 = popSize - 1;
                if (pos1 != pos2)
                {
                    temp = pop[pos1];
                    pop[pos1] = pop[pos2];
                    pop[pos2] = temp;
                }
            }

            // pick 2 parents and do crossover
            // First parent starts from the beginning, second from
            // middle, recall the population has already been mixed up.
            int p1, p2;  // two parents
            GAMember c1, c2;
            for (int ii = 0; ii < (int)((crossoverRate / 2.0) * popSize); ii++)
            {
                p1 = ii; p2 = ii + (int)(0.5 * popSize);
                c1 = (GAMember)pop[p1].Clone();
                c2 = (GAMember)pop[p2].Clone();

                //--------------transferring Genes to children -----------
                // 1/4 to 3/4 cut is made to transfer 1/2 tour to a child
                // rest of the information is transferred in cyclic order
                // from the other parent
                int cut1 = (int)Math.Ceiling(memSize / 4.0);
                int cut2 = (int)Math.Floor(memSize * 3.0 / 4.0);
                Hashtable h1 = new Hashtable();
                Hashtable h2 = new Hashtable();
                int i;
                for (i = cut1; i < cut2; i++)
                {
                    //		c1.mem[i] = pop[p1].mem[i];// already cloned
                    //		c2.mem[i] = pop[p2].mem[i];
                    h1.Add(c1.mem[i], -1);  // value does not matter
                    h2.Add(c2.mem[i], -1);
                }
                c1.mem[0] = 0; h1.Add(0, -1);
                c1.mem[memSize - 1] = 0; // start, end city is 0
                c2.mem[0] = 0; h2.Add(0, -1);
                c2.mem[memSize - 1] = 0; // start, end city is 0

                // now do a circular addition of tour from the second parent
                int startpos = 1;
                for (i = 1; i < cut1; i++)
                {
                    for (int j = 0; j < memSize; j++)
                    {
                        if ((h1.Contains(pop[p2].mem[startpos])) == false)
                        {
                            h1.Add(pop[p2].mem[startpos], -1);
                            c1.mem[i] = pop[p2].mem[startpos];
                            startpos = (startpos + 1) % memSize;
                            break;
                        }
                        else
                            startpos = (startpos + 1) % memSize;
                    }
                }

                //---from cut2 to memSize-1, copy second parent's genes
                //startpos = cut2;
                for (i = cut2; i < memSize - 1; i++)
                {
                    for (int j = 0; j < memSize; j++)
                    {
                        if ((h1.Contains(pop[p2].mem[startpos])) == false)
                        {
                            h1.Add(pop[p2].mem[startpos], -1);
                            c1.mem[i] = pop[p2].mem[startpos];
                            startpos = (startpos + 1) % memSize;
                            break;
                        }
                        else
                            startpos = (startpos + 1) % memSize;
                    }
                }


                //--------now for the second child
                startpos = 1;
                for (i = 1; i < cut1; i++)
                {
                    for (int j = 0; j < memSize; j++)
                    {
                        if ((h2.Contains(pop[p1].mem[startpos])) == false)
                        {
                            h2.Add(pop[p1].mem[startpos], -1);
                            c2.mem[i] = pop[p1].mem[startpos];
                            startpos = (startpos + 1) % memSize;
                            break;
                        }
                        else
                            startpos = (startpos + 1) % memSize;
                    }
                }

                //---from cut2 to memSize-1, copy first parent's genes
                startpos = cut2;
                for (i = cut2; i < memSize - 1; i++)
                {
                    for (int j = 0; j < memSize; j++)
                    {
                        if ((h2.Contains(pop[p1].mem[startpos])) == false)
                        {
                            h2.Add(pop[p1].mem[startpos], -1);
                            c2.mem[i] = pop[p1].mem[startpos];
                            startpos = (startpos + 1) % memSize;
                            break;
                        }
                        else
                            startpos = (startpos + 1) % memSize;
                    }
                }

                pop[p1] = c1;   // parents p1, p2 are replaced by their children
                pop[p2] = c2;
                pop[p1].EvaluateMember();
                pop[p2].EvaluateMember();
            }

        }

        public void MutatePopulation()
        {
            Random r = new Random(System.DateTime.Now.Millisecond);
            int pos, rnum, popnum = 0;
            for (int i = 0; i < (int)(popSize * memSize * mutationRate); i++)
            {
                pos = 0;
                while ((pos == 0) || (pos == memSize - 1))
                {
                    rnum = (int)(popSize * memSize * r.NextDouble());
                    pos = rnum % memSize;
                    popnum = (int)(rnum / memSize);
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
                        temp = pop[popnum].mem[pos];
                        pop[popnum].mem[pos] = pop[popnum].mem[exchpos];
                        pop[popnum].mem[exchpos] = temp;
                        doRandomExchange = false;
                    }
                }
                if (doRandomExchange == true)
                {
                    exchpos = 0;
                    while ((exchpos == 0) || (exchpos == memSize)
                        || (exchpos == (memSize - 1)))
                        exchpos = (int)(r.NextDouble() * memSize);
                    temp = pop[popnum].mem[pos];
                    pop[popnum].mem[pos] = pop[popnum].mem[exchpos];
                    pop[popnum].mem[exchpos] = temp;
                }
            }
        }

        #endregion

        public void printPopulation()
        {
            for (int i = 0; i < popSize; i++)
                pop[i].ToString();
        }

        public GAMember this[int popmember]  // creating indexer
        {
            get { return pop[popmember]; }
            set { pop[popmember] = (GAMember)value; }
        }
    }
}
