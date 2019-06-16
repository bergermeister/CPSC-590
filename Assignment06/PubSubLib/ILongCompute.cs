using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PubSubLib
{
   interface IComputeCallback
   {
      [ OperationContract( IsOneWay=true ) ]
      void OnComputeResult( ComputeResult res );
   }

   [ ServiceContract(CallbackContract = typeof( IComputeCallback ) ) ]
   public interface ILongCompute
   {
      [ OperationContract( IsOneWay = true ) ]
      void Compute( int a, int b, string clientId );
   }
}
