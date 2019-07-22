namespace GASvcLib
{
   using System.ServiceModel;
   
   interface ICallback
   {
      [ OperationContract( IsOneWay = true ) ]
      void MUpdateResult( GAMember aoRes );
   }

   [ ServiceContract( CallbackContract = typeof( ICallback ) ) ]   
   public interface IGASvc
   {
      [ OperationContract( IsOneWay = true ) ]
      void MExecute( int[ ][ ] aiDistMat, int aiNumThreads );
   }
}
