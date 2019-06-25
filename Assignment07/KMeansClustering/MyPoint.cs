namespace KMeansClustering
{
   using System;

   public class MyPoint : ICloneable
   {
      public int    ViClusterId{ get; set; }
      public double VdX{ get; set; }
      public double VdY{ get; set; }
      
      public object Clone( )
      {
         return( this.MemberwiseClone( ) );
      }
   }
}
