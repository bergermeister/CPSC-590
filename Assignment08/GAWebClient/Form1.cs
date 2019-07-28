namespace GAWebClient
{
   using System;
   using System.Collections;
   using System.Drawing;
   using System.Windows.Forms;

   public partial class Form1 : Form
   {
      private bool      vbCapture = false;
      private Bitmap    voOrig = null;
      private Bitmap    voWork = null;
      private ArrayList voPoints = new ArrayList( );
      private Client    voClient;

      public Form1( )
      {
         InitializeComponent( );
      }

      private void Form1_Load( object sender, EventArgs e )
      {
         this.voOrig = new Bitmap( @"Resources\usmap.jpg" );
         this.voMap.Image = ( Image )this.voOrig;

         Label[ ] koLabel = new Label[ ]
         {
            this.voLblBestResult0, this.voLblBestResult1, this.voLblBestResult2, this.voLblBestResult3
         };
         this.voClient = new Client( koLabel, this.voOrig, new Bitmap( this.voOrig ), this.voMap );
      }

      private void voBtnStartCap_Click( object sender, EventArgs e )
      {
         /// -# Restore the original image
         this.voMap.Image = this.voOrig;

         /// -# Start a new working copy of the original
         this.voWork = new Bitmap( this.voOrig );

         /// -# Clear the list of points
         this.voPoints.Clear( );

         /// -# Being a new capture
         this.vbCapture = true;         
      }

      private void voBtnEndCap_Click( object sender, EventArgs e )
      {
         /// -# End the capture
         this.vbCapture = false;
         
         /// -# Draw the Tour
         TSGAMT2010.MyImageProc.DrawTour( this.voOrig, ref this.voWork, this.voPoints );

         /// -# Update the map
         this.voMap.Image = this.voWork;

         /// -# Update the constants
         GAWebLib.Constants.NumCities = this.voPoints.Count;
         // TODO: GAWebLib.Constants.MutationRate = float.Parse( 
         // TODO: GAWebLib.CrossoverRate = float.Parse(
      }

      private void voBtnRunGADist_Click( object sender, EventArgs e )
      {
         this.voClient.MRun( this.voPoints );
      }

      private void voMap_MouseDown( object aoSender, MouseEventArgs aoArgs )
      {
         Point  koPt;

         if( this.vbCapture == true )
         {
            koPt = new Point( aoArgs.X, aoArgs.Y );
            this.voPoints.Add( koPt );
            TSGAMT2010.MyImageProc.DrawX( this.voWork, ref this.voWork, koPt );
            this.voMap.Image = this.voWork;
         }
      }
   }
}
