using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SecondWCF
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyMath2" in both code and config file together.
   [ServiceContract]
   public interface IMyMath2
   {
      [OperationContract]
      Matrix MultiplyMatrix( Matrix A, Matrix B );

      [OperationContract]
      Matrix InitMatrix( int rows, int cols );
   }
}
