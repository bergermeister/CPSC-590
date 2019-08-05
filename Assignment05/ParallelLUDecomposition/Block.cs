namespace ParallelLUDecomposition
{
   using System.Threading;

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
      private Semaphore   voSem;

      public Block( double[ , ] adA, double[ , ] adL, double[ , ] adU, 
                    int aiRow, int aiCol, int aiSize, int aiI, int aiJ,
                    Semaphore aoSemaphore )
      {
         this.vdA = adA;
         this.vdL = adL;
         this.vdU = adU;
         this.viRow = aiRow;
         this.viCol = aiCol;
         this.viSize = aiSize;
         this.viI = aiI;
         this.viJ = aiJ;
         this.voSem = aoSemaphore;
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

      public int ViRow
      {
         get{ return( this.viRow ); }
      }

      public int ViCol
      {
         get{ return( this.viCol ); }
      }

      public Semaphore VoSemaphore
      {
         get{ return( this.voSem ); }
      }

      public void MDecompose( Block[ , ] aoBlock )
      {
         Matrix      koA = this.VdA;
         Block       koBi = null;
         Block       koBj = null;
         Matrix      koAi = null;
         Matrix      koAj = null;
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

         /// -# Compute Ann' = Ann - (Ln1 * U1n + ... + Lm1 * U1m)
         for( int kiI = 0; kiI < this.viI; kiI++ )
         {
            koA = koA - ( aoBlock[ this.viI, kiI ].VdL * aoBlock[ kiI, this.viI ].VdU );
         }

         /// -# Perform LU Decomposition
         koA.MLUDecompose( kdL, kdU );

         /// -# Compute A' for A[i,i+1] and A[i+1,i]
         if( this.viI > 0 )
         {
            for( int kiI = 1; ( this.viI + kiI ) < aoBlock.GetLength( 0 ); kiI++ )
            //if( ( this.viI > 0 ) && ( this.viI < aoBlock.GetUpperBound( 0 ) ) )
            {
               koBj = aoBlock[ this.viI, this.viI + kiI ];
               koBi = aoBlock[ this.viI + kiI, this.viI ];

               // A[i,i+1] = A[i,i+1] - ( L[i, i-1] * U[i-1,i+1] )
               koAj = koBj.VdA - ( aoBlock[ this.viI, this.viI - 1 ].VdL * aoBlock[ this.viI - 1, this.viI + kiI ].VdU );
            
               // A[i+1,i] = A[i+1,i] - ( L[i+1, i-1] * U[i-1,i] )
               koAi = koBi.VdA - ( aoBlock[ this.viI + kiI, this.viI - 1 ].VdL * aoBlock[ this.viI - 1, this.viI ].VdU );
         
               for( int kiR = 0; kiR < this.viSize; kiR++ )
               {
                  for( int kiC = 0; kiC < this.viSize; kiC++ )
                  {
                     this.vdA[ koBi.ViRow + kiR, koBi.ViCol + kiC ] = koAi[ kiR, kiC ];
                     this.vdA[ koBj.ViRow + kiR, koBj.ViCol + kiC ] = koAj[ kiR, kiC ];
                  }
               }
            }
         }

         /// -# Copy data, L, and U out
         for( int kiR = 0; kiR < this.viSize; kiR++ )
         {
            for( int kiC = 0; kiC < this.viSize; kiC++ )
            {
               this.vdA[ this.viRow + kiR, this.viCol + kiC ] = koA[ kiR, kiC ];
               this.vdL[ this.viRow + kiR, this.viCol + kiC ] = kdL[ kiR, kiC ];
               this.vdU[ this.viRow + kiR, this.viCol + kiC ] = kdU[ kiR, kiC ];
               if( ( koBj != null ) && ( koBi != null ) && ( koAi != null ) && ( koAj != null ) )
               {
                  this.vdA[ koBi.ViRow + kiR, koBi.ViCol + kiC ] = koAi[ kiR, kiC ];
                  this.vdA[ koBj.ViRow + kiR, koBj.ViCol + kiC ] = koAj[ kiR, kiC ];
               }
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
