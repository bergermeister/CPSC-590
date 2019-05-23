using System;
using System.Windows.Forms;
using System.Threading;

namespace Threading2
{
   public partial class Form1 : Form
   {
      private Thread voThCompute = null;
      private Thread voThWeather = null;
      private Thread voThStock   = null;

      TcLongOperations voLOp = null;

      public Form1()
      {
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         this.voLOp = new TcLongOperations( );
         this.voThWeather = new Thread( new ThreadStart( this.voLOp.MGetWeather ) );

         // For long running threads that can be stopped halfway without causing any harm, 
         // set them as background threads. Background threads get terminated automatically
         // when the parent process is terminated
         this.voThWeather.IsBackground = true;
         this.voThWeather.Start( );

         this.voThStock = new Thread( new ThreadStart( this.voLOp.MGetStockPrice ) );
         this.voThStock.Start( );
      }

      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
         this.voLOp.VbTerminate = true;

         if( this.voThStock != null )
         {
            if( this.voThStock.IsAlive )
            {
               this.voThStock.Join( ); // Wait for thread to finish
            }
         }

         if( this.voThCompute != null )
         {
            if( this.voThCompute.IsAlive )
            {
               this.voThCompute.Join( );
            }
         }
      }

      private void voBtnCompute_Click(object sender, EventArgs e)
      {
         double kdRes;

         this.voLOp.ViData = 25;
         this.voThCompute = new Thread( new ThreadStart( this.voLOp.MCompute ) );
         this.voThCompute.Start( );
         this.voThCompute.Join( );

         kdRes = this.voLOp.VdResult;
         MessageBox.Show( kdRes.ToString( ) );
      }

      private void voBtnGetTemp_Click(object sender, EventArgs e)
      {
         MessageBox.Show( this.voLOp.ViTemperature.ToString( ) );
      }

      private void voBtnGetStockPrice_Click(object sender, EventArgs e)
      {
         MessageBox.Show( this.voLOp.VdStockPrice.ToString( ) );
      }
   }
}
