namespace GAWebClient
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Drawing;
   using System.ServiceModel;
   using System.Windows.Forms;
   using GAWebLib;

   class Client : Host.IDistributorCallback
   {
      private Label[ ]             voLabel;
      private PictureBox           voMap;
      private Bitmap               voOrig;
      private Bitmap               voWork;
      private ArrayList            voPoints;
      private ToolStripStatusLabel voStatus;
      private ToolStripProgressBar voProgress;
      private int                  viUpdates;

      public Client( Label[ ] aoLabel, Bitmap aoOrig, Bitmap aoWork, PictureBox aoMap, ToolStripStatusLabel aoStatus, ToolStripProgressBar aoProgress )
      {
         this.voLabel    = aoLabel;
         this.voOrig     = aoOrig;
         this.voWork     = aoWork;
         this.voMap      = aoMap;
         this.voStatus   = aoStatus;
         this.voProgress = aoProgress;
      }

      public bool MRun( ArrayList aoPoints, double[ ][ ] adDistance )
      {
         Host.DistributorClient koClient;
         bool                   kbStatus = false;
         
         this.voPoints = aoPoints;

         this.viUpdates = 0;

         if( ( aoPoints != null ) && ( aoPoints.Count > 0 ) )
         {
            kbStatus = true;

            /// -# Create the client
            koClient = new Host.DistributorClient( new InstanceContext( this ), "Distributor" );

            /// -# Execute the GA Algorithm
            koClient.MExecute( adDistance, 2 );
         }

         return( kbStatus );
      }

      public void MOnUpdate( Member[ ] aoMembers )
      {
         List< Member > koMembers = new List< Member >( aoMembers );
         koMembers.Sort( );

         Console.WriteLine( "{0} - Client: UPDATE", DateTime.Now );
         for( int i = 0; i < aoMembers.Length; i++ )
         {
            this.voLabel[ i ].Text = aoMembers[ i ].ToString( );
         }

         TSGAMT2010.MyImageProc.DrawBestTour( this.voOrig, ref this.voWork, this.voPoints, koMembers[ 0 ].ViMem );
         this.voMap.Image = this.voWork;

         this.viUpdates++;
         this.voProgress.Value = ( int )( ( ( double )this.viUpdates * ( double )Constants.ExchangeAfterIterations * 100.0 ) / ( double )Constants.NumIterations );
         this.voStatus.Text = "Running";
      }

      public void MOnComplete( Member[ ] aoMembers )
      {
         Console.WriteLine( "{0} - Client: COMPLETE", DateTime.Now );
         for( int i = 0; i < aoMembers.Length; i++ )
         {
            this.voLabel[ i ].Text = aoMembers[ i ].ToString( );
         }

         this.voProgress.Value = 100;
         this.voStatus.Text = "Complete";
      }
   }
}
