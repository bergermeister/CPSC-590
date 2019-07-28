namespace GAWebClient
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Drawing;
   using System.ServiceModel;
   using System.Threading.Tasks;
   using System.Windows.Forms;
   using GAWebLib;

   class Client : Host.IDistributorCallback
   {
      private Label[ ]   voLabel;
      private PictureBox voMap;
      private Bitmap     voOrig;
      private Bitmap     voWork;
      private ArrayList  voPoints;

      public Client( Label[ ] aoLabel, Bitmap aoOrig, Bitmap aoWork, PictureBox aoMap )
      {
         this.voLabel = aoLabel;
         this.voOrig  = aoOrig;
         this.voWork  = aoWork;
         this.voMap   = aoMap;
      }

      public bool MRun( ArrayList aoPoints )
      {
         int[ ][ ]              kiDistance;
         Host.DistributorClient koClient;
         bool                   kbStatus = false;
         
         this.voPoints = aoPoints;

         if( ( aoPoints != null ) && ( aoPoints.Count > 0 ) )
         {
            kbStatus = true;

            /// -# Create the distance jagged array
            kiDistance = new int[ aoPoints.Count ][ ];
            for( int kiI = 0; kiI < aoPoints.Count; kiI++ )
            {
               kiDistance[ kiI ] = new int[ aoPoints.Count ];
            }

            /// -# Fill the distance jagged array
            Parallel.For( 0, aoPoints.Count, ( kiI ) =>
            {
               int kiDx;
               int kiDy;
               int kiD;

               kiDistance[ kiI ] = new int[ aoPoints.Count ];
               for( int kiJ = kiI; kiJ < aoPoints.Count; kiJ++ )
               {
                  if( kiI == kiJ )
                  {
                     kiDistance[ kiI ][ kiJ ] = 0;
                  }
                  else
                  {
                     kiDx = Math.Abs( ( ( Point )aoPoints[ kiI ] ).X - ( ( Point )aoPoints[ kiJ ] ).X );
                     kiDy = Math.Abs( ( ( Point )aoPoints[ kiI ] ).Y - ( ( Point )aoPoints[ kiJ ] ).Y );
                     kiD = ( int )Math.Sqrt( ( kiDx * kiDx ) + ( kiDy * kiDy ) );
                     kiDistance[ kiI][ kiJ ] = kiD;
                     kiDistance[ kiJ][ kiI ] = kiD;
                  }
               }
            } );


            /// -# Create the client
            koClient = new Host.DistributorClient( new InstanceContext( this ), "Distributor" );

            /// -# Execute the GA Algorithm
            koClient.MExecute( kiDistance, 4 );
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
      }

      public void MOnComplete( Member[ ] aoMembers )
      {
         Console.WriteLine( "{0} - Client: COMPLETE", DateTime.Now );
         for( int i = 0; i < aoMembers.Length; i++ )
         {
            this.voLabel[ i ].Text = aoMembers[ i ].ToString( );
         }
      }
   }
}
