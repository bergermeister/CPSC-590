namespace GAWebServant
{
   using System.ServiceModel;
   
   [ ServiceContract ]
   public interface IWorker
   {
      [ OperationContract ]
      void MInitialize( int aiSizePop, int aiNumCities, float afRateMutate, float afRateCross, int[ ][ ] aiDistMat, int aiWorkerNum );

      [ OperationContract ]
      void MRun( int aiIterations );
   }
}
