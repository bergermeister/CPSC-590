namespace GAWebServant2
{
   using System.ServiceModel;
   
   interface ICallback
   {
      [ OperationContract( IsOneWay = true ) ]
      void MOnComplete( GAWebLib.Worker aoWorker );
   }

   [ ServiceContract( CallbackContract = typeof( ICallback ) ) ] // ( SessionMode = SessionMode.Required ) ]
   public interface IWorker
   {
      [ OperationContract( IsOneWay = true ) ]
      void MRun( GAWebLib.Worker aoWorker, double[ ][ ] adDistMat, int aiIterations );
   }
}
