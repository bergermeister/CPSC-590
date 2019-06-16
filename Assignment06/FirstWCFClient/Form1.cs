using FirstWCFClient.FRWCF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstWCFClient
{
   public partial class Form1 : Form
   {
      public Form1( )
      {
         InitializeComponent( );
      }

      private void voBtnTestMyMath_Click( object sender, EventArgs e )
      {
         IMyMath im = new  ChannelFactory< IMyMath >( new BasicHttpBinding( ),
                                                      new EndpointAddress( "http://localhost:8700/MM" ) ).CreateChannel( );
         double result = im.ComputeAvg( 7, 12, 14 );
         MessageBox.Show( "Result = " + result.ToString( ) );
         ( ( IChannel )im ).Close( );
      }

      private void voBtnTestProxy_Click( object sender, EventArgs e )
      {
         FRWCF.MyMathClient mmc = new FRWCF.MyMathClient( );
         double res = mmc.ComputeAvg( 5, 8, 13 );
         MessageBox.Show( "Result = " + res.ToString( ) );
      }
   }
}
