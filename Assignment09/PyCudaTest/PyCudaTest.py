
import pycuda.autoinit
import sys
import pycuda.driver as drv
import numpy
from pycuda.compiler import SourceModule

mod = SourceModule( """
__global__ void multiply_them( float* dest, float* a, float* b )
{
   const int i = threadIdx.x;
   dest[ i ] = a[ i ] * b[ i ];
}
""" )

XcpKernel = """
__global__ void MMultiplyKernel( float* afRes, float* afX, float* afY )
{
   int kiX = threadIdx.x + ( blockDim.x * blockIdx.x );
   int kiY = threadIdx.y + ( blockDim.y * blockIdx.y );

   // Result value used to store the element of the matrix computed by the thread
   float kfValue = 0.0f;

   // Each thread loads one row of X and one column of Y to produce one element of Res
   for( int i = 0; i < %(XiSize)s; i++ )
   {
      kfValue += ( afX[ ( kiY * %(XiSize)s ) + i ] * afY[ ( i * %(XiSize)s ) + kiX ] );
   }

   afRes[ ( kiY * %(XiSize)s ) + kiX ] = kfValue;
}
"""

XiSize = 4

def main( ):
   multiply_them = mod.get_function( "multiply_them" )
   a = numpy.random.randn( 400 ).astype( numpy.float32 )
   b = numpy.random.randn( 400 ).astype( numpy.float32 )
   dest = numpy.zeros_like( a )
   multiply_them( drv.Out( dest ), drv.In( a ), drv.In( b ), block=(400, 1, 1), grid=(1,1))
   c = dest - a*b
   print(c)

   # Get the kernel code and specify the matrix size
   kcpKernel = XcpKernel % { 'XiSize' : XiSize }

   # Compile the kernel code
   aoMod = SourceModule( kcpKernel )

   # Get the kernel function from the compiled module
   aoMultiplyKernel = aoMod.get_function( "MMultiplyKernel" )

   # Define the input and result matrices
   kfX = numpy.random.random_sample( ( XiSize, XiSize ) ).astype( numpy.float32 )
   kfY = numpy.random.random_sample( ( XiSize, XiSize ) ).astype( numpy.float32 )
   kfR = numpy.zeros_like( kfX )

   # Execute the kernel
   aoMultiplyKernel( drv.Out( kfR ), drv.In( kfX ), drv.In( kfY ), 
                   block = ( XiSize, XiSize, 4 ), grid=( 1, 1 ) )

   print( kfX )
   print( kfY )
   print( kfR )

if __name__ == "__main__":
   sys.exit( int(main() or 0 ) )