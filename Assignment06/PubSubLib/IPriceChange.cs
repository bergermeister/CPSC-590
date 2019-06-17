using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace PubSubLib
{
   [ ServiceContract ]
   public interface IPriceChange
   {
      [ OperationContract( ) ]
      bool ChangeStockPrice( string symbol, double newprice );
   }
}
