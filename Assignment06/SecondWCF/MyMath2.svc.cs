using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SecondWCF
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyMath2" in code, svc and config file together.
   // NOTE: In order to launch WCF Test Client for testing this service, please select MyMath2.svc or MyMath2.svc.cs at the Solution Explorer and start debugging.
   public class MyMath2 : IMyMath2
   {
      public void DoWork( )
      {
         public Matrix InitMatrix( int rows, int cols )         
         {  
            // constructors are not exposed via service             
            Matrix mat = new Matrix(rows, cols);             
            return( mat );
         } 
 
         
         public Matrix MultiplyMatrix( Matrix A, Matrix B )
         {             
            Matrix C = new Matrix(A.Rows, B.Cols);             
            for (int i = 0; i < A.Rows; i++)                 
               for (int j = 0; j < B.Cols; j++)                     
                  for (int k = 0; k < A.Cols; k++)                         
                     C[i, j] = C[i, j] + A[i, k] * B[k, j];             
            return C;        
         } 
      }
   }
}
