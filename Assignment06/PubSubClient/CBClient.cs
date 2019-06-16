using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PubSubClient
{
   class CBClient : PS.ILongComputeCallback, IDisposable
   {
      PS.LongComputeClient proxy = null;

      public void CallLongCompute( int x, int y, string ClientID )
      {
         try
         {
            proxy = new PS.LongComputeClient( new System.ServiceModel.InstanceContext( this ), "PSEP" );
            proxy.Compute( x, y, ClientID );
         }
         catch( Exception ex )
         {
            throw ex;
         }
      }

      public void OnComputeResult( PS.ComputeResult res )
      {
         MessageBox.Show( res.Result.ToString( ) + Environment.NewLine + res.ClientID );
      }

      public void Dispose( )
      {
         proxy.Close( );
      }
   }
}
