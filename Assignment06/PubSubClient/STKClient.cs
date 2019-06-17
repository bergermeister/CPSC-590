using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PubSubClient
{
   class STKClient : PS.IStocksCallback, IDisposable
   {
      PS.StocksClient stkProxy = null;
      int             myId = 0;

      public void SubscribeToPriceChange( string sym, double triggerPrice, int id )
      {
         try
         {
            myId = id;
            stkProxy = new PS.StocksClient( new System.ServiceModel.InstanceContext( this ), "SPEP" );
            stkProxy.SubscribeToStockPrice( sym, triggerPrice );
         }
         catch( Exception ex )
         {
            throw ex;
         }
      }

      public void UnsubscribeToPriceChange( string sym )
      {
         try
         {
            if( stkProxy != null )
            {
               stkProxy.UnsubscribeToStockPrice( sym );
            }
         }
         catch( Exception ex )
         {
            throw ex;
         }
      }

      public void OnPriceChange( PS.StockInfo sinfo )
      {
         MessageBox.Show( "Price Change Notification Received (MyID = " + myId.ToString( ) + ")" + Environment.NewLine +
                          sinfo.Symbol + ":" + sinfo.Price.ToString( ) );
      }

      public void Dispose( )
      {
         stkProxy.Close( );
      }
   }
}
