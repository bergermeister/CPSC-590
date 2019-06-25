namespace KMeansClustering
{
   using System;
   using System.Collections.Generic;

   public class ClusterCenterPoint : ICloneable
   {
      public int ViClusterID{ get; set; }
      public double VdCx{ get; set; }
      public double VdCy{ get; set; }
      public List< MyPoint > VoList{ get; set; }   /**< List of points belonging to this cluster */

      public object Clone( )
      {
         return( this.MemberwiseClone( ) );
      }
   }
}
