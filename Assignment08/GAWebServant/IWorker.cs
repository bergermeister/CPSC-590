namespace GAWebServant
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
      [ OperationContract ]
      void MRun( GAWebLib.Worker aoWorker, int aiIterations );
   }
}
