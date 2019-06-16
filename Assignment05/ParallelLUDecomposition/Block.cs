using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLUDecomposition
{
   class Block
   {
      private double[ , ] vdA;
      private double[ , ] vdL;
      private double[ , ] vdU;
      private int         viRow;
      private int         viCol;
      private int         viSize;
      private int         viI;
      private int         viJ;

      public Block( double[ , ] adA, double[ , ] adL, double[ , ] adU, 
                    int aiRow, int aiCol, int aiSize, int aiI, int aiJ )
      {
         this.vdA = adA;
         this.vdL = adL;
         this.vdU = adU;
         this.viRow = aiRow;
         this.viCol = aiCol;
         this.viSize = aiSize;
         this.viI = aiI;
         this.viJ = aiJ;
      }

      public Matrix VdA
      {
         get
         {
            Matrix koA = new Matrix( this.viSize, this.viSize );
            for( int kiR = 0; kiR < this.viSize; kiR++ )
            {
               for( int kiC = 0; kiC < this.viSize; kiC++ )
               {
                  koA[ kiR, kiC ] = this.vdA[ this.viRow + kiR, this.viCol + kiC ];
               }
            }
            return( koA );
         }
      }

      public Matrix VdL
      {
         get
         {
            Matrix koL = new Matrix( this.viSize, this.viSize );
            for( int kiR = 0; kiR < this.viSize; kiR++ )
            {
               for( int kiC = 0; kiC < this.viSize; kiC++ )
               {
                  koL[ kiR, kiC ] = this.vdL[ this.viRow + kiR, this.viCol + kiC ];
               }
            }
            return( koL );
         }
      }

      public Matrix VdU
      {
         get
         {
            Matrix koU = new Matrix( this.viSize, this.viSize );
            for( int kiR = 0; kiR < this.viSize; kiR++ )
            {
               for( int kiC = 0; kiC < this.viSize; kiC++ )
               {
                  koU[ kiR, kiC ] = this.vdU[ this.viRow + kiR, this.viCol + kiC ];
               }
            }
            return( koU );
         }
      }

      public int ViI
      {
         get{ return( this.viI ); }
      }

      public int ViJ
      {
         get{ return( this.viJ ); }
      }

      public void MDecompose( Block[ , ] aoBlock )
      {
         Matrix      koA = new Matrix( this.viSize, this.viSize );
         double[ , ] kdL = new double[ this.viSize, this.viSize ];
         double[ , ] kdU = new double[ this.viSize, this.viSize ];

         /// -# Copy the block data into matrix A
         for( int kiR = 0; kiR < this.viSize; kiR++ )
         {
            for( int kiC = 0; kiC < this.viSize; kiC++ )
            {
               koA[ kiR, kiC ] = this.vdA[ this.viRow + kiR, this.viCol + kiC ];
            }
         }

         if( this.viI > 0 )
         {
            koA = koA - ( aoBlock[ this.viI, this.viJ - 1 ].VdL * aoBlock[ this.viI - 1, this.viJ ].VdU );
         }

         /// -# Perform LU Decomposition
         koA.MLUDecompose( kdL, kdU );

         /// -# Copy data, L, and U out
         for( int kiR = 0; kiR < this.viSize; kiR++ )
         {
            for( int kiC = 0; kiC < this.viSize; kiC++ )
            {
               this.vdA[ this.viRow + kiR, this.viCol + kiC ] = koA[ kiR, kiC ];
               this.vdL[ this.viRow + kiR, this.viCol + kiC ] = kdL[ kiR, kiC ];
               this.vdU[ this.viRow + kiR, this.viCol + kiC ] = kdU[ kiR, kiC ];
            }
         }
      }

      public void MComputeL( Block[ , ] aoBlock )
      {
         Matrix koL = this.VdA * aoBlock[ this.viJ, this.viJ ].VdU.MInverse( );
         for( int kiR = 0; kiR < this.viSize; kiR++ )
         {
            for( int kiC = 0; kiC < this.viSize; kiC++ )
            {
               this.vdL[ this.viRow + kiR, this.viCol + kiC ] = koL[ kiR, kiC ];
            }
         }
      }

      public void MComputeU( Block[ , ] aoBlock )
      {
         Matrix koU = aoBlock[ this.viI, this.viI ].VdL.MInverse( ) * this.VdA;
         for( int kiR = 0; kiR < this.viSize; kiR++ )
         {
            for( int kiC = 0; kiC < this.viSize; kiC++ )
            {
               this.vdU[ this.viRow + kiR, this.viCol + kiC ] = koU[ kiR, kiC ];
            }
         }
      }
   }
}
