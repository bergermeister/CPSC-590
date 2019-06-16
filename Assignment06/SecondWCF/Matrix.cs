using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SecondWCF
{
   [DataContract]
   public class Matrix
   {
      [DataMember]
      public int Rows{ get; set; }

      [DataMember]
      public int Cols{ get; set; }

      [DataMember]
      public double[][] Data = null; // jagged array

      public Matrix( int rows, int cols )
      {
         this.Rows = rows;
         this.Cols = cols;

         Data = new double[ Rows ][ ];
         for( int i = 0; i < rows; i++ )
            Data[ i ] = new double[ Cols ];
      }

      public double this[ int i, int j ]
      {
         get{ return( Data[ i ][ j ] ); }
         set{ Data[ i ][ j ] = value; }
      }
   }
}