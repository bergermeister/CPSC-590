using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLUDecomposition
{
   class Matrix
   {
      private int         viRows;
      private int         viCols;
      private double[ , ] vdData;
      
      public Matrix( int aiRows, int aiColumns )
      {
         this.viRows = aiRows;
         this.viCols = aiColumns;
         this.vdData = new double[ this.viRows, this.viCols ];
      }

      public int ViRows
      {
         get{ return( this.viRows ); }
      }

      public int ViColumns
      {
         get{ return( this.viCols ); }
      }

      public double this[ int aiI, int aiJ ]
      {
         get{ return( this.vdData[ aiI, aiJ ] ); }
         set{ this.vdData[ aiI, aiJ ] = value; }
      }

      public void MLUDecompose( double[ , ] adL, double[ , ] adU, ref double adError )
      {
         if( this.viRows != this.viCols )
         {
            throw new Exception( "Row and Column dimensions are not the same." );
         }

         /// -# Copy data into a matrix
         double[ , ] kdA; // = new double[ this.viRows, this.viCols ];
         double[ , ] kdRes = new double[ this.viRows, this.viRows ];

         kdA = ( double[ , ] )this.vdData.Clone( );

         for( int kiK = 0; kiK < this.viRows; kiK++ )
         {
            adU[ kiK, kiK ] = this.vdData[ kiK, kiK ];
            for( int kiJ = kiK + 1; kiJ < this.viRows; kiJ++ )
            {
               adU[ kiK, kiJ ] = this.vdData[ kiK, kiJ ];
            }
            for( int kiI = kiK; kiI < this.viRows; kiI++ )
            {
               if( kiI == kiK )
               {
                  adL[ kiI, kiK ] = 1;
               }
               else
               {
                  adL[ kiI, kiK ] = this.vdData[ kiI, kiK ] / adU[ kiK, kiK ];
               }
            }
            for( int kiI = kiK + 1; kiI < this.viRows; kiI++ )
            {
               for( int kiJ = kiK + 1; kiJ < this.viRows; kiJ++ )
               {
                  this.vdData[ kiI, kiJ ] = this.vdData[ kiI, kiJ ] - adL[ kiI, kiK ] * adU[ kiK, kiJ ];
               }
            }    
         }

         // verify if LU decomp is correct
         
         for( int kiI = 0; kiI < this.viRows; kiI++ )
         {
            for( int kiJ = 0; kiJ < this.viRows; kiJ++ )
            {
               for( int kiK = 0; kiK < this.viRows; kiK++ )
               {
                  kdRes[ kiI, kiJ ] += adL[ kiI, kiK ] * adU[ kiK, kiJ ];
               }
            }
         }
         adError = 0;
         for( int kiI = 0; kiI < this.viRows; kiI++ )
         {
            for( int kiJ = 0; kiJ < this.viRows; kiJ++ )
            {
               adError += Math.Abs( kdRes[ kiI, kiJ ] - kdA[ kiI, kiJ ] );
            }
         }
      }

      public override string ToString()
      {
         string koOut = "";

         for( int kiI = 0; kiI < this.viRows; kiI++ )
         {
            for( int kiJ = 0; kiJ < this.viCols; kiJ++ )
            {
               koOut += this.vdData[ kiI, kiJ ].ToString() + " \t";
            }
            koOut += Environment.NewLine;
         }

         return( koOut );
      }

      public static Matrix operator*( Matrix aoA, Matrix aoB )
      {
         Matrix koRes = new Matrix( aoA.ViRows, aoB.ViColumns );
         Parallel.For( 0, aoA.ViRows, ( kiI ) =>
         {
            for( int kiK = 0; kiK < aoA.ViColumns; kiK++ )
            {
               for( int kiJ = 0; kiJ < aoB.ViColumns; kiJ++ )
               {
                  koRes.vdData[ kiI, kiJ ] += aoA.vdData[ kiI, kiK ] * aoB.vdData[ kiK, kiJ ];
               }
            }
         } );

         return( koRes );
      }
   }
}
