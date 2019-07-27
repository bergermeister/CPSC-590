namespace GASvcLib
{
   namespace Servant
   {
      using System.ServiceModel;
   
      interface ICallback
      {
         [ OperationContract( IsOneWay = true ) ]
         void MUpdateResult( Member aoMember );
      }

      [ ServiceContract( CallbackContract = typeof( ICallback ) ) ] // ( SessionMode = SessionMode.Required ) ]
      public interface IWorker
      {
         [ OperationContract ]
         void MInitialize( int aiSizePop, int aiNumCities, float afRateMutate, float afRateCross, int[ ][ ] aiDistMat, int aiWorkerNum );

         [ OperationContract ]
         void MRun( int aiIterations );
      }
   }
}
