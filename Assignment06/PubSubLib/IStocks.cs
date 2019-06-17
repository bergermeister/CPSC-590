using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PubSubLib
{
   interface IStocksCallback
   {
      [ OperationContract( IsOneWay = true ) ]
      void OnPriceChange( StockInfo sinfo );
   }

   [ ServiceContract( CallbackContract = typeof( IStocksCallback ) ) ]
   public interface IStocks
   {
      [ OperationContract ]
      bool SubscribeToStockPrice( string stocksym, double triggerPrice );

      [ OperationContract ]
      bool UnsubscribeToStockPrice( string stocksym );
   }
}
