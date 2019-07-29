namespace GAWebHost
{
   using GAWebLib;

   public class Habitat
   {
      public Worker VoWorker{ get; set; }    ///< Populations
      public double VdLambda{ get; set; }    ///< Immigration probability
      public double VdMu{ get; set; }        ///< Emigration propability
      public bool   VbComplete{ get; set; }  ///< Habitat complete, ready for exchange

      public Habitat( Worker aoWorker )
      {
         this.VoWorker = aoWorker;
         this.VdLambda = 0.0 ; // new double[ aoWorker.ViSizePop ];
         this.VdMu     = 0.0 ; // new double[ aoWorker.ViSizePop ];
         this.VbComplete = false;
      }
   }
}