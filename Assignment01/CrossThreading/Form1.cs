using System;
using System.Windows.Forms;
using System.Threading;

namespace CrossThreading
{
   public partial class Form1 : Form
   {
      private delegate void ToUpdateDel( string aoMsg );

      private Thread      voThClock = null;
      private ToUpdateDel voUDel;
      private bool        vbTerminate = false;

      public Form1()
      {
         InitializeComponent();
         this.voUDel = new ToUpdateDel( this.MUpdateLabel );
      }

      private void Form1_FormClosing( object sender, FormClosingEventArgs e )
      {
         this.vbTerminate = true;

         if( this.voThClock != null )
         {
            if( this.voThClock.IsAlive )
            {
               this.voThClock.Join( );
            }
         }
      }

      private void voBtnStartClock_Click( object sender, EventArgs e )
      {
         this.voThClock = new Thread( new ThreadStart( MClock ) );
         this.voThClock.Start( );
      }

      public void MClock( )
      {
         int kiI;

         for( kiI = 0; kiI < 10; kiI++ )
         {
            //this.voLblTime.Text = DateTime.Now.ToString( );
            // We cannot update the label because that will cause cross threading error,
            // Use invoke on the UI element
            if( this.vbTerminate == false )
            {
               this.voLblTime.Invoke( this.voUDel, new string[ ] { DateTime.Now.ToString( ) } );
            }
            Thread.Sleep( 1000 );
         }
      }

      public void MUpdateLabel( string aoMsg )
      {
         this.voLblTime.Text = aoMsg;
      }      
   }
}
