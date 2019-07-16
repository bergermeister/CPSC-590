using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TSGAMT2010
{
    public class GAMember : IPopulationMember,IComparable, ICloneable
    {
        public int[] mem;   
        public int fitness;
        public int memSize;
        public static int[,] DistMatrix; // common for all
        
        static Random r = new Random(System.DateTime.Now.Millisecond);  
                                      // important otherwise all objects are identical

        public GAMember(int memsz, int[,] DMatrix)
        {  // constructor
            memSize = memsz;  // start and end city are the same
            mem = new int[memSize];
            InitializeMember();
            DistMatrix = DMatrix;
            EvaluateMember();
        }

        public object Clone()
        {  // make a copy of self and return it in object
            GAMember g1 = new GAMember(this.memSize, DistMatrix);
            for (int i = 0; i < g1.memSize; i++)
                g1.mem[i] = this.mem[i];
            g1.memSize = this.memSize;
            g1.fitness = this.fitness;
            return g1;
        }
 
        public override string ToString()
        {
            string res = mem[0].ToString();
            for (int i = 1; i < memSize; i++)
                res = res + "->" + mem[i];
            return res;
        }

        public int CompareTo(Object rhs)  // for sorting
        {
            GAMember mr = (GAMember)rhs;
            return this.fitness.CompareTo(mr.fitness);  // index 0 is best
        }


        #region IPopulationMember Members

        public void InitializeMember()
        {
            // random initialization of all cities
            ArrayList am = new ArrayList();
            for (int i = 1; i < memSize - 1; i++) 
                am.Add(i); // all cities in list, implicit boxing
            mem[0] = 0; mem[memSize - 1] = 0; // 0 is the start city as well as the end city
            int index = 1; int rnum;
            for (int j = 1; j < memSize - 1; j++)
            {
                rnum = (int)(r.NextDouble() * am.Count);
                mem[index++] = (int)am[rnum]; // explicit unboxing
                am.RemoveAt(rnum);
            }
        }

        public void EvaluateMember()
        {
            fitness = DistMatrix[mem[0], mem[1]];
            for (int i = 1; i < memSize - 1; i++)
                fitness = fitness + DistMatrix[mem[i], mem[i + 1]];
        }

        #endregion
    }
}
