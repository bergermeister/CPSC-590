namespace GAWebLib
{
   using System;
   using System.Collections;
   using System.Runtime.Serialization;

   [ DataContract ]
   public class Member : IPopulationMember, IComparable, ICloneable
   {
      public static double[ ][ ] VdDistMatrix; // common for all

      [ DataMember ]
      public int[ ] ViMem;   

      [ DataMember ]
      public double VdFitness;

      [ DataMember ]
      public int ViMemSize;
        
      private static Random voRand = new Random( DateTime.Now.Millisecond );  // important otherwise all objects are identical

      public Member( int aiSize )
      {  
         this.ViMemSize = aiSize;  // start and end city are the same
         this.ViMem = new int[ ViMemSize ];
         this.InitializeMember( );
         this.EvaluateMember( );
      }

      public object Clone( )
      {  // make a copy of self and return it in object
         Member koMem = new Member( this.ViMemSize );
         for( int kiI = 0; kiI < koMem.ViMemSize; kiI++ )
         {
            koMem.ViMem[ kiI ] = this.ViMem[ kiI ];
         }

         koMem.ViMemSize = this.ViMemSize;
         koMem.VdFitness = this.VdFitness;

         return( koMem );
      }
 
      public override string ToString( )
      {
         string koRes = this.ViMem[ 0 ].ToString( );
         for( int kiI = 1; kiI < this.ViMemSize; kiI++ )
         {
            koRes = koRes + "->" + this.ViMem[ kiI ];
         }
         return( koRes );
      }

      public int CompareTo( object aoRHS )  // for sorting
      {
         Member koMR = ( Member )aoRHS;
         return( this.VdFitness.CompareTo( koMR.VdFitness ) );  // index 0 is best
      }

      #region IPopulationMember Members

      public void InitializeMember( )
      {
         // random initialization of all cities
         int kiIndex = 1; 
         int kiRNum;
         ArrayList koAM = new ArrayList( );
         for( int kiI = 1; kiI < this.ViMemSize - 1; kiI++ )
         {
            koAM.Add( kiI ); // all cities in list, implicit boxing
         }

         this.ViMem[ 0 ] = 0; 
         this.ViMem[ this.ViMemSize - 1 ] = 0; // 0 is the start city as well as the end city
         
         for( int kiJ = 1; kiJ < this.ViMemSize - 1; kiJ++ )
         {
            kiRNum = ( int )( voRand.NextDouble( ) * koAM.Count );
            this.ViMem[ kiIndex++ ] = ( int )koAM[ kiRNum ]; // explicit unboxing
            koAM.RemoveAt( kiRNum );
         }
      }

      public void EvaluateMember( )
      {
         this.VdFitness = VdDistMatrix[ ViMem[ 0 ] ][ ViMem[ 1 ] ];
         for( int kiI = 1; kiI < this.ViMemSize - 1; kiI++ )
         {
            this.VdFitness = this.VdFitness + VdDistMatrix[ this.ViMem[ kiI ] ][ this.ViMem[ kiI + 1 ] ];
         }
      }

      #endregion
   }
}
