namespace WCFLibrary
{
   public class MyMath : IMyMath
   {
      public double ComputeAvg( int a, int b, int c )
      {
         return( ( a + b + c ) / 3.0 );
      }

      public int FindMin( int a, int b, int c )
      {
         int min = a;
         if( b < min ) min = b;
         if( c < min ) min = c;
         return( min );
      }
   }
}
