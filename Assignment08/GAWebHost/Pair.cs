namespace GAWebHost
{
   public class Pair< Type1, Type2 >
   {
      public Type1 VoItem1{ get; set; }
      public Type2 VoItem2{ get; set; }

      public Pair( Type1 aoItem1, Type2 aoItem2 )
      {
         this.VoItem1 = aoItem1;
         this.VoItem2 = aoItem2;
      }
   }
}