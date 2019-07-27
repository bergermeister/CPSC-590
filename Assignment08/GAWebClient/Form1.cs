namespace GAWebClient
{
   using System;
   using System.Collections;
   using System.Drawing;
   using System.Threading.Tasks;
   using System.Windows.Forms;

   public partial class Form1 : Form
   {
      private bool      vbCapture = false;
      private Bitmap    voOrig = null;
      private Bitmap    voWork = null;
      private ArrayList voPoints = new ArrayList( );
      private int[ , ]  viDistMat = null;
      

      public Form1( )
      {
         InitializeComponent( );
      }

      private void Form1_Load( object sender, EventArgs e )
      {
         this.voOrig = new Bitmap( @"Resources\usmap.jpg" );
         this.voMap.Image = ( Image )this.voOrig;
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
         int kiDx;
         int kiDy;
         int kiD;

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

         this.viDistMat = new int[ this.voPoints.Count, this.voPoints.Count ];
         for( int i = 0; i < this.voPoints.Count; i++ )
         {
            for( int j = i; j < this.voPoints.Count; j++ )
            {
               if( i == j )
               {
                  this.viDistMat[ i, j ] = 0;
               }
               else
               {
                  kiDx = Math.Abs( ( ( Point )this.voPoints[ i ] ).X - ( ( Point )this.voPoints[ j ] ).X );
                  kiDy = Math.Abs( ( ( Point )this.voPoints[ i ] ).Y - ( ( Point )this.voPoints[ j ] ).Y );
                  kiD = ( int )Math.Sqrt( ( kiDx * kiDx ) + ( kiDy * kiDy ) );
                  this.viDistMat[ i, j ] = kiD;
                  this.viDistMat[ j, i ] = kiD;
               }
            }
         }
      }

      private void voBtnRunGADist_Click( object sender, EventArgs e )
      {
         int[ ][ ] kiDistance;
         Host.DistributorClient koClient;
         
         if( this.viDistMat != null )
         {
            /// -# Create the client
            koClient = new Host.DistributorClient( );

            /// -# Convert multi-dimensional array to jagged array
            kiDistance = new int[ this.viDistMat.GetUpperBound( 0 ) ][ ];
            Parallel.For( 0, this.viDistMat.GetUpperBound( 0 ), ( i ) =>
            {
               kiDistance[ i ] = new int[ this.viDistMat.GetUpperBound( 1 ) ];
               for( int j = 0; j < this.viDistMat.GetUpperBound( 1 ); j++ )
               {
                  kiDistance[ i ][ j ] = this.viDistMat[ i, j ];
               }
            } ); 

            /// -# Execute the GA Algorithm
            koClient.MExecute( kiDistance, 1 );
         }
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
