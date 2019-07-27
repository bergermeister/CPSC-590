namespace GASvcLib
{
   using System;
   using System.Collections;
   using System.Runtime.Serialization;

   [ DataContract ]
   public class Member : IPopulationMember, IComparable, ICloneable
   {
      public static int[ ][ ] ViDistMatrix; // common for all

      [ DataMember ]
      public int[ ] ViMem;   

      [ DataMember ]
      public int ViFitness;

      [ DataMember ]
      public int ViMemSize;
        
      private static Random voRand = new Random( DateTime.Now.Millisecond );  // important otherwise all objects are identical

      public Member( int aiSize, int[ ][ ] aiDMatrix )
      {  
         ViDistMatrix = aiDMatrix;

         this.ViMemSize = aiSize;  // start and end city are the same
         this.ViMem = new int[ ViMemSize ];
         this.InitializeMember( );
         this.EvaluateMember( );
      }

      public object Clone( )
      {  // make a copy of self and return it in object
         Member koMem = new Member( this.ViMemSize, ViDistMatrix );
         for( int kiI = 0; kiI < koMem.ViMemSize; kiI++ )
         {
            koMem.ViMem[ kiI ] = this.ViMem[ kiI ];
         }

         koMem.ViMemSize = this.ViMemSize;
         koMem.ViFitness = this.ViFitness;

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
         return( this.ViFitness.CompareTo( koMR.ViFitness ) );  // index 0 is best
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
         this.ViFitness = ViDistMatrix[ ViMem[ 0 ] ][ ViMem[ 1 ] ];
         for( int kiI = 1; kiI < this.ViMemSize - 1; kiI++ )
         {
            this.ViFitness = this.ViFitness + ViDistMatrix[ this.ViMem[ kiI ] ][ this.ViMem[ kiI + 1 ] ];
         }
      }

      #endregion
   }
}
