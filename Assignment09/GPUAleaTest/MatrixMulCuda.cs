namespace GPUAleaTest
{
   using Alea;
   using Alea.Parallel;

   class MatrixMulCuda
   {
      public static void MMultiplyKernel1( float[ ][ ] afRes, float[ ][ ] afX, float[ ][ ] afY )
      {
         // Linear number of blocks and threads per block
         // e.g. (1, 1000), (4, 250), or (8, 125)
         // The outer i loop is executed in each thread
         int kiTId = threadIdx.x + ( blockDim.x * blockIdx.x );
         int kiSize = afX.GetLength( 0 );
         for( int j = 0; j < kiSize; j++ )
         {
            for( int k = 0; k < kiSize; k++ )
            {
               afRes[ kiTId ][ j ] += afX[ kiTId ][ k ] * afY[ k ][ j ];
            }
         }
      }

      public static void MMultiplyKernel2( float[ ][ ] afRes, float[ ][ ] afX, float[ ][ ] afY )
      {
         int kiTId = threadIdx.x + ( blockDim.x * blockIdx.x ) + ( ( blockDim.x * blockIdx.y ) * 2 );
         // int kiTId = threadIdx.x + ( blockDim.x * blockIdx.x ) + 
         //             threadIdx.x + ( blockDim.y * blockIdx.y );
         int kiSize = afX.GetLength( 0 );
         for( int j = 0; j < kiSize; j++ )
         {
            for( int k = 0; k < kiSize; k++ )
            {
               afRes[ kiTId ][ j ] += afX[ kiTId ][ k ] * afY[ k ][ j ];
            }
         }
      }

      public static void MMultiplyKernel3( float[ ][ ] afRes, float[ ][ ] afX, float[ ][ ] afY )
      {
         int kiSize = afX.GetLength( 0 );
         int kiStartX = ( ( kiSize / gridDim.x ) * blockIdx.x ) + threadIdx.x;
         int kiStartY = ( ( kiSize / gridDim.y ) * blockIdx.y ) + threadIdx.y;
         int kiInc = blockDim.x;
         int kiBoundX = ( ( kiSize / gridDim.x ) * blockIdx.x ) + ( kiSize / gridDim.x );
         int kiBoundY = ( ( kiSize / gridDim.y ) * blockIdx.y ) + ( kiSize / gridDim.y );
         int kiCount = ( kiSize / gridDim.x ) / blockDim.x;

         for( int i = kiStartX; i < kiBoundX; i = i + kiInc )
         {
            for( int j = kiStartY; j < kiBoundY; j = j + kiInc )
            {
               for( int k = 0; k < kiSize; k++ )
               {
                  afRes[ i ][ j ] += afX[ i ][ k ] * afY[ k ][ j ];
               }
            }
         }
      }

      public static void MMulitplyGpuFor( float[ ][ ] afRes, float[ ][ ] afX, float[ ][ ] afY )
      {
         int kiSize = afX.GetLength( 0 );
         Gpu.Default.For( 0, kiSize, i =>
         {
            for( int j = 0; j < kiSize; j++ )
            {
               for( int k = 0; k < kiSize; k++ )
               {
                  afRes[ i ][ j ] += afX[ i ][ k ] * afY[ k ][ j ];
               }
            }
         } );
      }
   }
}
