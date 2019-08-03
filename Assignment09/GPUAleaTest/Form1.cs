using Alea;
using Alea.CSharp;
using Alea.Parallel;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace GPUAleaTest
{
   public partial class Form1 : Form
   {
      private const int xiDimX = 1000;
      private const int xiDimY = 1000;
      private Random    voRand = new Random( 500 );
      private float[ ][ ] vfA = null;
      private float[ ][ ] vfB = null;
      private float[ ][ ] vfC = null;
      private Gpu voGpu = null;

      public Form1( )
      {
         /// -# Initialize Windows Forms Components
         InitializeComponent( );

         /// -# Initialize Members
         this.voGpu = Gpu.Default;
         this.vfA = new float[ xiDimX ][ ];
         this.vfB = new float[ xiDimX ][ ];
         this.vfC = new float[ xiDimX ][ ];
         for( int i = 0; i < xiDimX; i++ )
         {
            this.vfA[ i ] = new float[ xiDimY ];
            this.vfB[ i ] = new float[ xiDimY ];
            this.vfC[ i ] = new float[ xiDimY ];
         }
      }

      private void voBtnGPUForWithLambda_Click( object sender, EventArgs e )
      {
         this.mGPUForWithLambdaGpu( );
      }

      private void voBtnGPUTestKernel_Click( object sender, EventArgs e )
      {
         this.mRunKernel( );
      }

      private void voBtnInitMatrices_Click( object sender, EventArgs e )
      {
         this.mInitMatrix( this.vfA );
         this.mInitMatrix( this.vfB );
         this.mClearMatrix( this.vfC );
         MessageBox.Show( "Done initialization.." );
      }

      private void voBtnMatMulSeq_Click( object sender, EventArgs e )
      {
         Stopwatch  koSW = new Stopwatch( );

         this.mClearMatrix( this.vfC );

         koSW.Start( );
         this.mMatrixMultiply( this.vfC, this.vfA, this.vfB );
         koSW.Stop( );
         MessageBox.Show( "C[200][200] = " + this.vfC[ 200 ][ 200 ].ToString( ) + Environment.NewLine +
                          "Time Elapsed = " + koSW.ElapsedMilliseconds.ToString( ) );
      }

      private void voBtnMatMulGPU_Click( object sender, EventArgs e )
      {
         this.mRunMatrixMultiplyGPU1( );
      }

      private void voBtnMatMulGPU2_Click( object sender, EventArgs e )
      {
         this.mRunMatrixMultiplyGPU2( );
      }

      private void voBtnMatMulGPU3_Click( object sender, EventArgs e )
      {
         this.mRunMatrixMultiplyGPU3( );
      }

      private void voBtnMatMulGPU4_Click( object sender, EventArgs e )
      {
         this.mRunMatrixMultiplyGPU4( );
      }

      [ GpuManaged ]
      private void mGPUForWithLambdaGpu( )
      {
         int kiLength = 1000;
         var koArg1 = Enumerable.Range( 0, kiLength ).ToArray( );
         var koArg2 = Enumerable.Range( 0, kiLength ).ToArray( );
         var koExpected = koArg1.Zip( koArg2, ( x, y ) => x + y );
         var koResult = new int[ kiLength ];

         this.voGpu.For( 0, koResult.Length, i => koResult[ i ] = koArg1[ i ] + koArg2[ i ] );
         Assert.That( koResult, Is.EqualTo( koExpected ) );
         MessageBox.Show( "Result[50] = " + koResult[ 50 ].ToString( ) );
      }

      [ GpuManaged ]
      private void mRunKernel( )
      {
         int kiLength = 1000;
         var koArg1 = Enumerable.Range( 0, kiLength ).ToArray( );
         var koArg2 = Enumerable.Range( 0, kiLength ).ToArray( );
         var koExpected = koArg1.Zip( koArg2, ( x, y ) => x + y );
         var koResult = new int[ kiLength ];
         var koLP = new LaunchParam( 4, 32 );   // Use 4 blocks with 32 threads per block
         
         this.voGpu.Launch( this.mKernel, koLP, koResult, koArg1, koArg2 );
         Assert.That( koResult, Is.EqualTo( koExpected ) );
         MessageBox.Show( "Result[600] = " + koResult[ 600 ].ToString( ) );
      }

      [ GpuManaged ]
      private void mRunMatrixMultiplyGPU1( )
      {
         Stopwatch   koSW = new Stopwatch( );
         LaunchParam koLP;

         this.mClearMatrix( this.vfC );

         koSW.Start( );
         koLP = new LaunchParam( 4, 250 );
         this.voGpu.Launch( MatrixMulCuda.MMultiplyKernel1, koLP, this.vfC, this.vfA, this.vfB );
         koSW.Stop( );
         MessageBox.Show( "C[200][200] = " + this.vfC[ 200 ][ 200 ].ToString( ) + Environment.NewLine +
                          "Time Elapsed = " + koSW.ElapsedMilliseconds.ToString( ) );
      }

      [ GpuManaged ]
      private void mRunMatrixMultiplyGPU2( )
      {
         Stopwatch  koSW = new Stopwatch( );
         LaunchParam koLP;

         this.mClearMatrix( this.vfC );

         koSW.Start( );
         koLP = new LaunchParam( new dim3( 2, 2 ), new dim3( 250 ) );
         this.voGpu.Launch( MatrixMulCuda.MMultiplyKernel2, koLP, this.vfC, this.vfA, this.vfB );
         koSW.Stop( );
         MessageBox.Show( "C[200][200] = " + this.vfC[ 200 ][ 200 ].ToString( ) + Environment.NewLine +
                          "Time Elapsed = " + koSW.ElapsedMilliseconds.ToString( ) );
      }

      [ GpuManaged ]
      private void mRunMatrixMultiplyGPU3( )
      {
         Stopwatch   koSW = new Stopwatch( );
         LaunchParam koLP;

         this.mClearMatrix( this.vfC );

         koSW.Start( );
         koLP = new LaunchParam( new dim3( 2, 2 ), new dim3( 25, 25 ) );
         this.voGpu.Launch( MatrixMulCuda.MMultiplyKernel3, koLP, this.vfC, this.vfA, this.vfB );
         koSW.Stop( );
         MessageBox.Show( "C[200][200] = " + this.vfC[ 200 ][ 200 ].ToString( ) + Environment.NewLine +
                          "Time Elapsed = " + koSW.ElapsedMilliseconds.ToString( ) );
      }

      [ GpuManaged ]
      private void mRunMatrixMultiplyGPU4( )
      {
         Stopwatch koSW = new Stopwatch( );

         this.mClearMatrix( this.vfC );

         koSW.Start( );
         MatrixMulCuda.MMulitplyGpuFor( this.vfC, this.vfA, this.vfB );
         koSW.Stop( );
         MessageBox.Show( "C[200][200] = " + this.vfC[ 200 ][ 200 ].ToString( ) + Environment.NewLine +
                          "Time Elapsed = " + koSW.ElapsedMilliseconds.ToString( ) );
      }

      private void mKernel( int[ ] aiResult, int[ ] aiArg1, int[ ] aiArg2 )
      {
         // Start index of the array:
         // e.g: if launch with LaunchParam( 4, 32 )
         // blockDim.x = 32         (32 threads per block)
         // threadIdx.x = 0 to 31   (Thread index)
         // blockIdx.x = 0 to 4     (Block index)
         var kiStart = blockIdx.x * blockDim.x + threadIdx.x;  
         var kiStride = gridDim.x * blockDim.x;

         for( var i = kiStart; i < aiResult.Length; i += kiStride )
         {
            aiResult[ i ] = aiArg1[ i ] + aiArg2[ i ];
         }
      }

      private void mClearMatrix( float[ ][ ] afM )
      {
         for( int i = 0; i < afM.GetLength( 0 ); i++ )
         {
            for( int j = 0; j < afM[ i ].GetLength( 0 ); j++ )
            {
               afM[ i ][ j ] = 0.0f;
            }
         }
      }

      private void mInitMatrix( float[ ][ ] afM )
      {
         for( int i = 0; i < afM.GetLength( 0 ); i++ )
         {
            for( int j = 0; j < afM[ i ].GetLength( 0 ); j++ )
            {
               afM[ i ][ j ] = ( float )( ( this.voRand.NextDouble( ) * 5.0 ) + 2.0 );
            }
         }
      }

      private void mMatrixMultiply( float[ ][ ] afRes, float[ ][ ] afX, float[ ][ ] afY )
      {
         int kiSize = afX.GetLength( 0 );
         for( int i = 0; i < kiSize; i++ )
         {
            for( int j = 0; j < kiSize; j++ )
            {
               for( int k = 0; k < kiSize; k++ )
               {
                  afRes[ i ][ j ] += afX[ i ][ k ] * afY[ k ][ j ];
               }
            }
         }
      }
   }
}
