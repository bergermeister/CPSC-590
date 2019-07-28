namespace GAWebHost
{
   using System.ServiceModel;

   interface ICallback
   {
      [ OperationContract( IsOneWay = true ) ]
      void MOnUpdate( GAWebLib.Member[ ] aoMembers );

      [ OperationContract( IsOneWay = true ) ]
      void MOnComplete( GAWebLib.Member[ ] aoMember );
   }

   [ ServiceContract( CallbackContract = typeof( ICallback ) ) ]
   public interface IDistributor
   {
      [ OperationContract( IsOneWay = true ) ]
      void MExecute( double[ ][ ] adDistMat, int aiNumWorkers );
   }
}
