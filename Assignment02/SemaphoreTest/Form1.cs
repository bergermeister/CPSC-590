using System.Windows.Forms;
using System.Threading;

namespace SemaphoreTest
{
   public partial class Form1 : Form
   {
      private TcLimoCar voCar = new TcLimoCar( 1234, 10 );

      public Form1()
      {
         InitializeComponent();
      }

      private void voBtnNewCust_Click(object sender, System.EventArgs e)
      {
         Thread koLimo = new Thread( new ThreadStart( this.voCar.MUse ) );
         koLimo.Start( );
      }
   }
}
