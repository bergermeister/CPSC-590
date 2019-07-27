namespace GAWebHost
{
   using System.ServiceModel;

   /*
    * TODO: Breaks build
   interface ICallback
   {
      [ OperationContract( IsOneWay = true ) ]
      void MUpdateResult( GAWebLib.Member aoMember );
   }
   */

   [ ServiceContract ]
   public interface IDistributor
   {
      [ OperationContract ]
      void MExecute( int[ ][ ] aiDistMat, int aiNumWorkers );
   }
}
