using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PubSubClient
{
   public partial class Form1 : Form
   {
      STKClient stkc = new STKClient( );
      int myId = 0;

      public Form1( )
      {
         InitializeComponent( );
      }

      private void Form1_Load( object sender, EventArgs e )
      {
         this.myId = new Random( ( int )DateTime.Now.Ticks ).Next( );
         this.Text = myId.ToString( );
      }

      private void Form1_FormClosing( object sender, FormClosingEventArgs e )
      {
         try
         {
            stkc.UnsubscribeToPriceChange( "IBM" );
         }
         catch( Exception ex )
         {
            MessageBox.Show( ex.Message );
         }
      }

      private void btnTestCallback_Click( object sender, EventArgs e )
      {
         try
         {
            CBClient cbc = new CBClient( );
            cbc.CallLongCompute( int.Parse( txtA.Text ), int.Parse( txtB.Text ), txtClientID.Text );
         }
         catch( Exception ex )
         {
            MessageBox.Show( ex.Message );
         }
      }

      private void voBtnSubscribe_Click( object sender, EventArgs e )
      {
         try
         {
            stkc.SubscribeToPriceChange( this.voTxtSymbol.Text, 
                                         double.Parse( this.voTxtTrigger.Text ), 
                                         this.myId );
         }
         catch( Exception ex )
         {
            MessageBox.Show( ex.Message );
         }
      }

      private void voBtnChngPrice_Click( object sender, EventArgs e )
      {
         PS.PriceChangeClient pcc = new PS.PriceChangeClient( );
         pcc.ChangeStockPrice( this.voTxtChngSym.Text, 
                               double.Parse( this.voTxtPrice.Text ) );
      }

      private void voBtnUnsubscribe_Click( object sender, EventArgs e )
      {
         try
         {
            stkc.UnsubscribeToPriceChange( "IBM" );
         }
         catch( Exception ex )
         {
            MessageBox.Show( ex.Message );
         }
      }
   }
}
