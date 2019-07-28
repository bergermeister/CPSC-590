namespace GAWebClient
{
   using System;
   using System.Collections;
   using System.Drawing;
   using System.IO;
   using System.Threading.Tasks;
   using System.Windows.Forms;

   public partial class Form1 : Form
   {
      private bool         vbCapture = false;
      private Bitmap       voOrig = null;
      private Bitmap       voWork = null;
      private ArrayList    voPoints = new ArrayList( );
      private double[ ][ ] vdDistance;
      private Client       voClient;

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
         this.voClient = new Client( koLabel, this.voOrig, new Bitmap( this.voOrig ), this.voMap, this.voLblStatus, this.voProgress );
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

         /// -# Create the distance jagged array
         this.vdDistance = new double[ this.voPoints.Count ][ ];
         for( int kiI = 0; kiI < this.voPoints.Count; kiI++ )
         {
            this.vdDistance[ kiI ] = new double[ this.voPoints.Count ];
         }

         /// -# Fill the distance jagged array
         //Parallel.For( 0, this.voPoints.Count, ( kiI ) =>
         for( int kiI = 0; kiI < this.voPoints.Count; kiI++ )
         {
            double kdDx;
            double kdDy;
            double kdD;

            for( int kiJ = kiI; kiJ < this.voPoints.Count; kiJ++ )
            {
               if( kiI == kiJ )
               {
                  this.vdDistance[ kiI ][ kiJ ] = 0;
               }
               else
               {
                  kdDx = Math.Abs( ( ( Point )this.voPoints[ kiI ] ).X - ( ( Point )this.voPoints[ kiJ ] ).X );
                  kdDy = Math.Abs( ( ( Point )this.voPoints[ kiI ] ).Y - ( ( Point )this.voPoints[ kiJ ] ).Y );
                  kdD =  Math.Sqrt( ( kdDx * kdDx ) + ( kdDy * kdDy ) );
                  this.vdDistance[ kiI ][ kiJ ] = kdD;
                  this.vdDistance[ kiJ ][ kiI ] = kdD;
               }
            }
         } //);
      }

      private void voBtnLoad_Click( object sender, EventArgs e )
      {
         OpenFileDialog koDlg = new OpenFileDialog( );
         string         koLine;
         string[ ]      koCell;
         Coordinate[ ]  koCoordinates = null;
         double[ , ]    koDistMat;
         int            kiDimension;
         int            kiIndex;
         int            kiMaxX = 0, kiMaxY = 0;
         double         kdMaxX = 0.0, kdMaxY = 0.0;

         if( koDlg.ShowDialog( ) == DialogResult.OK )
         {
            using( StreamReader koReader = new StreamReader( koDlg.FileName ) )
            {
               while( ( koLine = koReader.ReadLine( ) ) != null )
               {
                  if( koLine.StartsWith( "DIMENSION" ) )
                  {
                     kiDimension = int.Parse( koLine.Split( new char[ ]{ ':' } )[ 1 ].Trim( ) );
                     koDistMat = new double[ kiDimension, kiDimension ];
                     koCoordinates = new Coordinate[ kiDimension ];
                     break;
                  }
               }

               while( ( koLine = koReader.ReadLine( ) ) != null )
               {
                  if( koLine.StartsWith( "NODE_COORD_SECTION" ) )
                  {
                     break;
                  }
               }

               while( ( ( koLine = koReader.ReadLine( ) ) != null ) && ( koLine.Length > 0 ) && ( koLine != "EOF" ) )
               {
                  koCell = koLine.Trim( ).Split( new char[ ]{ ' ' }, StringSplitOptions.RemoveEmptyEntries );
                  kiIndex = int.Parse( koCell[ 0 ] ) - 1;
                  koCoordinates[ kiIndex ] = new Coordinate( )
                  {
                     X = double.Parse( koCell[ 1 ] ),
                     Y = double.Parse( koCell[ 2 ] )
                  };
                  if( kdMaxX < koCoordinates[ kiIndex ].X )
                  {
                     kdMaxX = koCoordinates[ kiIndex ].X;
                  }
                  if( kdMaxY < koCoordinates[ kiIndex ].Y )
                  {
                     kdMaxY = koCoordinates[ kiIndex ].Y;
                  }
               }
            }

            /// -# Create the distance jagged array
            this.vdDistance = new double[ koCoordinates.Length ][ ];
            for( int kiI = 0; kiI < koCoordinates.Length; kiI++ )
            {
               this.vdDistance[ kiI ] = new double[ koCoordinates.Length ];
            }

            /// -# Fill the distance jagged array
            Parallel.For( 0, koCoordinates.Length, ( kiI ) =>
            {
               double kdDx;
               double kdDy;
               double kdD;

               for( int kiJ = kiI; kiJ < koCoordinates.Length; kiJ++ )
               {
                  if( kiI == kiJ )
                  {
                     this.vdDistance[ kiI ][ kiJ ] = 0;
                  }
                  else
                  {
                     kdDx = Math.Abs( koCoordinates[ kiI ].X - koCoordinates[ kiJ ].X );
                     kdDy = Math.Abs( koCoordinates[ kiI ].Y - koCoordinates[ kiJ ].Y );
                     kdD = Math.Sqrt( ( kdDx * kdDx ) + ( kdDy * kdDy ) );
                     this.vdDistance[ kiI][ kiJ ] = kdD;
                     this.vdDistance[ kiJ][ kiI ] = kdD;
                  }
               }
            } );

            /// -# Convert Coordinates to Points for drawnig
            kiMaxX = this.voMap.Width;
            kiMaxY = this.voMap.Height;
            this.voPoints.Clear( );
            for( int i = 0; i < koCoordinates.Length; i++ )
            {
               this.voPoints.Add( new Point( ( int )( koCoordinates[ i ].X / kdMaxX * kiMaxX ), ( int )( koCoordinates[ i ].Y / kdMaxY * kiMaxY ) ) );
            }
         }
      }

      private void voBtnRunGADist_Click( object sender, EventArgs e )
      {
         this.voClient.MRun( this.voPoints, this.vdDistance );
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
