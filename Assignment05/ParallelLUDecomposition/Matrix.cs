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

      public Matrix( int aiRows, int aiColumns, double[ , ] adData )
      {
         this.viRows = aiRows;
         this.viCols = aiColumns;
         this.vdData = adData;
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

      public void MLUDecomposeBlock( double[ , ] adL, double[ , ] adU, int aiSize, ref double adError )
      {
         int         kiCount = this.viRows / aiSize;
         int         kiBr;
         int         kiBc;
         double[ , ] kdRes   = new double[ this.viRows, this.viRows ];
         Matrix[ , ] koBlock = new Matrix[ kiCount, kiCount ];

         adError = 0.0;

         /// -# Break the matrix into blocks
         for( int kiI = 0; kiI < kiCount; kiI++ )
         {
            kiBr = kiI * aiSize;
            for( int kiJ = 0; kiJ < kiCount; kiJ++ )
            {
               kiBc = kiJ * aiSize;
               koBlock[ kiI, kiJ ] = new Matrix( aiSize, aiSize );
               for( int kiR = 0; kiR < aiSize; kiR++ )
               {
                  for( int kiC = 0; kiC < aiSize; kiC++ )
                  {
                     koBlock[ kiI, kiJ ].vdData[ kiR, kiC ] = this.vdData[ kiBr + kiR, kiBc + kiC ];
                  }
               }
            }
         }

         Matrix koA;
         Matrix koLii = new Matrix( aiSize, aiSize );
         Matrix koUii = new Matrix( aiSize, aiSize );
         Matrix koAi0 = new Matrix( aiSize, aiSize );
         Matrix koA0i = new Matrix( aiSize, aiSize );
         Task< Matrix >[ ] koTaskL = new Task< Matrix >[ kiCount - 1 ];
         Task< Matrix >[ ] koTaskU = new Task< Matrix >[ kiCount - 1 ];
         for( int kiI = 0; kiI < kiCount; kiI++ )
         {
            /// -# On the first iteration work on Aii, all other iterations calculate Aii'
            if( kiI == 0 )
            {
               koA = koBlock[ kiI, kiI ];
            }
            else
            {
               //koA = koBlock[ kiI, kiI ] - ( koLi0 * koU0i );
               koA = koBlock[ kiI, kiI ] - ( koTaskL[ kiI - 1 ].Result * koTaskU[ kiI - 1 ].Result );
            }

            /// -# Break Aii into Lii and Uii
            koA.MLUDecompose( koLii.vdData, koUii.vdData );

            // Copy the data out
            for( int kiM = 0; kiM < aiSize; kiM++ )
            {
               for( int kiN = 0; kiN < aiSize; kiN++ )
               {
                  adL[ ( kiI * aiSize ) + kiM, ( kiI * aiSize ) + kiN ] = koLii[ kiM, kiN ];
                  adU[ ( kiI * aiSize ) + kiM, ( kiI * aiSize ) + kiN ] = koUii[ kiM, kiN ];
                  this.vdData[ ( kiI * aiSize ) + kiM, ( kiI * aiSize ) + kiN ] = koA[ kiM, kiN ];
               }
            }

            if( kiI < ( kiCount - 1 ) )
            {
               /// -# Compute U0i and Li0 in parallel
               for( int kiJ = kiI + 1; kiJ < kiCount; kiJ++ )
               {  
                  /// -# Compute Li0 = Ai0 * Uii^-1
                  koTaskL[ kiJ - 1 ] = Task.Factory.StartNew< Matrix >( ( aiJ ) =>
                  {
                     return( koBlock[ ( int )aiJ, kiI ] * koUii.MInverse( ) );
                  }, kiJ );

                  /// -# Compute U0i = Lii^-1 * A0i
                  koTaskU[ kiJ - 1 ] = Task.Factory.StartNew< Matrix >( ( aiJ ) =>
                  {
                     return(  koLii.MInverse( ) * koBlock[ kiI, ( int )aiJ ] );
                  }, kiJ ); 
               }
               Task.WaitAll( koTaskL );
               Task.WaitAll( koTaskU );

               // Copy the data out
               for( int kiJ = kiI + 1; kiJ < kiCount; kiJ++ )
               { 
                  koAi0 = koBlock[ kiJ, kiI ] + ( koTaskL[ kiJ - 1 ].Result * koUii ); 
                  koA0i = koBlock[ kiI, kiJ ] + ( koLii * koTaskU[ kiJ - 1 ].Result );

                  for( int kiM = 0; kiM < aiSize; kiM++ )
                  {
                     for( int kiN = 0; kiN < aiSize; kiN++ )
                     {
                        adL[ ( kiJ * aiSize ) + kiM, ( kiI * aiSize ) + kiN ] = koTaskL[ kiJ - 1 ].Result[ kiM, kiN ];
                        adU[ ( kiI * aiSize ) + kiM, ( kiJ * aiSize ) + kiN ] = koTaskU[ kiJ - 1 ].Result[ kiM, kiN ];
                        this.vdData[ ( ( kiJ ) * aiSize ) + kiM, ( ( kiI ) * aiSize ) + kiN ] = koAi0[ kiM, kiN ];
                        this.vdData[ ( ( kiI ) * aiSize ) + kiM, ( ( kiJ ) * aiSize ) + kiN ] = koA0i[ kiM, kiN ];
                     }
                  }
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
               adError += Math.Abs( kdRes[ kiI, kiJ ] - this.vdData[ kiI, kiJ ] );
            }
         }
      }

      public void MLUDecompose( double[ , ] adL, double[ , ] adU )
      {
         if( this.viRows != this.viCols )
         {
            throw new Exception( "Row and Column dimensions are not the same." );
         }

         /// -# Copy data into a matrix
         double[ , ] kdA;

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
      }

      public Matrix MInverse( )
      {
         const double xdE = 0.000001;

         int    kiNumCols = this.viCols * 2;
         Matrix koAug = new Matrix( this.viRows, kiNumCols );
         Matrix koInv = new Matrix( this.viRows, this.viCols );

         /// -# Build augmented matrix
         for( int kiRow = 0; kiRow < this.viRows; kiRow++ )
         {
            for( int kiCol = 0; kiCol < this.viCols; kiCol++ )
            {
               koAug[ kiRow, kiCol ] = this.vdData[ kiRow, kiCol ];
            }

            // Augment with the Identity Matrix
            koAug[ kiRow, kiRow + this.viRows ] = 1.0;
         }

         /// -# Solve the Matrix
         for( int kiRow = 0; kiRow < this.viRows; kiRow++ )
         {
            /// -# Zero out all entries in column R after this row
            if( Math.Abs( koAug[ kiRow, kiRow ] ) < xdE )
            {
               // Close to zero, try to swap with a later row
               for( int kiR2 = kiRow + 1; kiR2 < this.viRows; kiR2++ )
               {
                  if( Math.Abs( koAug[ kiR2, kiRow ] ) > xdE )
                  {
                     for( int kiCol = 0; kiCol < kiNumCols; kiCol++ )
                     {
                        double kdTemp = koAug[ kiR2, kiCol ];
                        koAug[ kiRow, kiCol ] = koAug[ kiR2, kiCol ];
                        koAug[ kiR2, kiCol ] = kdTemp;
                     }
                     break;
                  }
               }
            }

            // If this row has a non-zero entry in column r, use it
            if( Math.Abs( koAug[ kiRow, kiRow ] ) > xdE )
            {
               // Divide the row by augmented[ row, row ] to make this entry 1
               for( int kiCol = 0; kiCol < kiNumCols; kiCol++ )
               {
                  if( kiCol != kiRow )
                  {
                     koAug[ kiRow, kiCol ] /= koAug[ kiRow, kiRow ];
                  }
               }
               koAug[ kiRow, kiRow ] = 1;

               // Subtract this row from the other rows
               for( int kiR2 = 0; kiR2 < this.viRows; kiR2++ )
               {
                  if( kiR2 != kiRow )
                  {
                     double kdFactor = koAug[ kiR2, kiRow ] / koAug[ kiRow, kiRow ];
                     for( int kiCol = 0; kiCol < kiNumCols; kiCol++ )
                     {
                        koAug[ kiR2, kiCol ] -= kdFactor * koAug[ kiRow, kiCol ];
                     }
                  }
               }
            }
         }

         if( koAug[ this.viRows - 1, this.viCols - 1] != 0 )
         {
            for( int kiRow = 0; kiRow < this.viRows; kiRow++ )
            {
               for( int kiCol = 0; kiCol < this.viCols; kiCol++ )
               {
                  koInv[ kiRow, kiCol ] = koAug[ kiRow, kiCol + this.viRows ];
               }
            }
         }

         return( koInv );
         /*
         int dimension = this.viRows;
			int count = this.viCols;
		
			Matrix B = Matrix.MDiagonal( this.viRows, 1.0 );
			double[,] l = this.vdData;
		
			// Solve L*Y = B;
			for (int k = 0; k < this.viRows; k++)
			{
				for (int i = k + 1; i < dimension; i++) 
					for (int j = 0; j < count; j++)
						B[i,j] -= B[k,j] * l[i,k];
		
				for (int j = 0; j < count; j++) 
					B[k,j] /= l[k,k];
			}
		
			// Solve L'*X = Y;
			for (int k = dimension - 1; k >= 0; k--)
			{
				for (int j = 0; j < count; j++)
					B[k,j] /= l[k,k];
					
				for (int i = 0; i < k; i++)
					for (int j = 0; j < count; j++)
						B[i,j] -= B[k,j] * l[k,i];
			}
		
			return B;
         /*
         Matrix koB = Matrix.MDiagonal( this.viRows, 1.0 );
		
         // Solve L*Y = B;
         for( int kiK = 0; kiK < this.viRows; kiK++ )
         {
            for( int kiI = kiK + 1; kiI < this.viRows; kiI++ )
            {
		         for( int kiJ = 0; kiJ < this.viRows; kiJ++ )
               {
			         koB[ kiI, kiJ ] -= koB[ kiK, kiJ ] * this.vdData[ kiI, kiK ];
               }
            }

	         for( int kiJ = 0; kiJ < this.viRows; kiJ++ )
            {
		         koB[ kiK, kiJ ] /= this.vdData[ kiK, kiK ];
            }
         }
		
         // Solve L'*X = Y;
         for( int kiK = ( this.viRows - 1 ); kiK >= 0; kiK-- )
         {
	         for( int kiJ = 0; kiJ < this.viRows; kiJ++ )
            {
		         koB[ kiK, kiJ ] /= this.vdData[ kiK, kiK ];
            }	
	         for( int kiI = 0; kiI < kiK; kiI++ )
            {
		         for( int kiJ = 0; kiJ < this.viRows; kiJ++ )
               {
			         koB[ kiI, kiJ ] -= koB[ kiK, kiJ ] * this.vdData[ kiK, kiI ];
               }
            }
         }

         return( koB );
         //*/
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

      public static Matrix MDiagonal( int aiSize, double adValue )
      {
         Matrix      koM = new Matrix( aiSize, aiSize );
         double[ , ] kdX = koM.vdData;
         int kiI = 0;
         for( int kiJ = 0; kiJ < aiSize; kiJ++ )
         {
            kdX[ kiI, kiJ ] = adValue;
            kiI++;
         }
         return( koM );
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

      public static Matrix operator+( Matrix aoA, Matrix aoB )
      {
         Matrix koRes = new Matrix( aoA.ViRows, aoA.ViColumns );
         Parallel.For( 0, aoA.ViRows, ( kiI ) =>
         {
            for( int kiJ = 0; kiJ < aoA.ViColumns; kiJ++ )
            {
               koRes.vdData[ kiI, kiJ ] = aoA.vdData[ kiI, kiJ ] + aoB.vdData[ kiI, kiJ ];
            }
         } );

         return( koRes );
      }

      public static Matrix operator-( Matrix aoA, Matrix aoB )
      {
         Matrix koRes = new Matrix( aoA.ViRows, aoA.ViColumns );
         Parallel.For( 0, aoA.ViRows, ( kiI ) =>
         {
            for( int kiJ = 0; kiJ < aoA.ViColumns; kiJ++ )
            {
               koRes.vdData[ kiI, kiJ ] = aoA.vdData[ kiI, kiJ ] - aoB.vdData[ kiI, kiJ ];
            }
         } );

         return( koRes );
      }
   }
}
