using System.ServiceModel;

namespace WCFLibrary
{
   [ServiceContract]
   public interface IMyMath
   {
      [OperationContract]
      double ComputeAvg( int a, int b, int c );

      [OperationContract]
      int FindMin( int a, int b, int c );
   }
}
