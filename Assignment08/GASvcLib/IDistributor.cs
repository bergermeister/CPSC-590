namespace GASvcLib
{
   namespace Host
   {
      using System.ServiceModel;

      interface ICallback
      {
         [ OperationContract( IsOneWay = true ) ]
         void MUpdateResult( Member aoMember );
      }

      [ ServiceContract ]//( CallbackContract = typeof( ICallback ) ]
      public interface IDistributor
      {
         [ OperationContract ]
         void MExecute( int[ ][ ] aiDistMat, int aiNumWorkers );
      }
   }
}
