using Mapack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMM
{
   public partial class Form1 : Form
   {
      // reference for equations involved in Gaussian Mixture Model using Expectation Maximization
      // https://brilliant.org/wiki/gaussian-mixture-model/

      private Bitmap           voOrig = null;
      private List< string >   voCluster;
      private List< string >   voStrSwarmGMM;
      private List< GMM_NDim > voSwarmGMM;
      private GMM_NDim         voGmmnd;
      private Random           voRand = new Random();

      public Form1( )
      {
         InitializeComponent( );

         this.voCluster = new List< string >( );
         this.voLB.DataSource = this.voCluster;
      }

      private void voBtnBrowse_Click( object aoSender, EventArgs aoArgs )
      {
         OpenFileDialog koDialog = new OpenFileDialog( );
         
         if( koDialog.ShowDialog( ) == DialogResult.OK )
         {
            this.voOrig = new Bitmap( koDialog.FileName );
            this.voPB.Image = this.voOrig;
         }
      }

      private void btnGMMND_Click( object aoSender, EventArgs aoArg )
      {
         try
         {
            int    kiK = int.Parse( txtNumClusters.Text );   // number of clusters
            int    kiDim = 3;                                // number of dimensions for data
            Matrix koX = new Matrix( this.voOrig.Height * this.voOrig.Width, 3 );

            for( int i = 0; i < this.voOrig.Height; i++ )
            {
               for( int j = 0; j < this.voOrig.Width; j++ )
               {
                 Color koC = this.voOrig.GetPixel( j, i );
                 koX[ ( i * this.voOrig.Width ) + j, 0] = koC.R;
                 koX[ ( i * this.voOrig.Width ) + j, 1] = koC.G;
                 koX[ ( i * this.voOrig.Width ) + j, 2] = koC.B; 
               }
            }

            voGmmnd = new GMM_NDim( kiK, kiDim, koX );
            voGmmnd.ComputeGMM_ND();

            this.voLB.DataSource = null;
            this.voCluster.Clear( );
            for( int i = 0; i < kiK; i++ )
            {
               this.voCluster.Add( String.Format( "Cluster {0}", i ) );
            }
            this.voLB.DataSource = this.voCluster;
         }
         catch( Exception koEx )
         {
            MessageBox.Show( koEx.Message );
         }
      }

      private void voLB_SelectedIndexChanged( object aoSender, EventArgs aoArgs )
      {
         ListBox koLB = aoSender as ListBox;
         Bitmap  koBmp;
         
         if( koLB.SelectedIndex >= 0 )
         {
            koBmp = ( Bitmap )this.voOrig.Clone( );
            MyImageProc.DrawCluster( this.voPB, this.mClusterPoints( ), ref koBmp, 1, koLB.SelectedIndex );
         }
         else
         {
            this.voPB.Image = null;
            this.voPB.Image = this.voOrig;
         }
      }

      private void voBtnShowBall_Click( object sender, EventArgs e )
      {
         int    kiTr = 209;
         int    kiTg = 224;
         int    kiTb = 17;
         double kdLoss = 0.0;
         double kdBest = double.MaxValue;
         int    kiCnum = 0;
         Bitmap koBmp = ( Bitmap )this.voOrig.Clone( );

         for( int m = 0; m < this.voCluster.Count; m++ )
         {
            kdLoss = Math.Sqrt( ( ( double )kiTr - this.voGmmnd.mu[ m ][ 0, 0 ] ) * ( ( double )kiTr - this.voGmmnd.mu[ m ][ 0, 0 ] ) +
                                ( ( double )kiTg - this.voGmmnd.mu[ m ][ 0, 1 ] ) * ( ( double )kiTg - this.voGmmnd.mu[ m ][ 0, 1 ] ) +
                                ( ( double )kiTb - this.voGmmnd.mu[ m ][ 0, 2 ] ) * ( ( double )kiTb - this.voGmmnd.mu[ m ][ 0, 2 ] ) );
            if( kdLoss < kdBest )
            {
              kdBest = kdLoss;
              kiCnum = m;
            }
         }

         MyImageProc.DrawCluster( this.voPB, this.mClusterPoints( ), ref koBmp, 1, kiCnum );
      }

      private void voBtnSwarm_Click( object sender, EventArgs e )
      {
         int                 kiI;
         Task< GMM_NDim >[ ] koTask   = new Task< GMM_NDim >[ 4 ];
         Task                koFinal;

         this.voSwarmGMM = new List< GMM_NDim >( );

         for( kiI = 0; kiI < koTask.Length; kiI++ )
         {
            koTask[ kiI ] = Task.Factory.StartNew< GMM_NDim >( ( aoContext ) =>
            {
               int      kiK = ( ( int )aoContext ) + 2;
               int      kiDim = 3;                     // number of dimensions for data
               Bitmap   koBmp;
               lock( this.voOrig ){ koBmp = ( Bitmap )this.voOrig.Clone( ); }
               Matrix   koX = new Matrix( koBmp.Height * koBmp.Width, 3 );
               GMM_NDim koRes;
                              
               for( int i = 0; i < koBmp.Height; i++ )
               {
                  for( int j = 0; j < koBmp.Width; j++ )
                  {
                    Color koC = koBmp.GetPixel( j, i );
                    koX[ ( i * koBmp.Width ) + j, 0] = koC.R;
                    koX[ ( i * koBmp.Width ) + j, 1] = koC.G;
                    koX[ ( i * koBmp.Width ) + j, 2] = koC.B; 
                  }
               }
               koRes = new GMM_NDim( kiK, kiDim, koX );
               koRes.ComputeGMM_ND( );
               koRes.VdInertia = koRes.MInertia( koBmp );

               return( koRes );
            }, kiI );
         }

         koFinal = Task.Factory.ContinueWhenAll( koTask, ( aoTask ) =>
         {
            Console.WriteLine( aoTask.Length.ToString( ) + " tasks" );
            for( kiI = 0; kiI < aoTask.Length; kiI++ )
            {
               this.voSwarmGMM.Add( aoTask[ kiI ].Result );
            }
         } );

         koFinal.Wait( );
         this.voSwarmGMM.Sort( );

         this.voStrSwarmGMM = new List< string >( );
         for( int i = 0; i < this.voSwarmGMM.Count; i++ )
         {
            this.voStrSwarmGMM.Add( String.Format( "K = {0}", this.voSwarmGMM[ i ].ViK ) );
         }

         this.voResult.DataSource = null;
         this.voResult.DataSource = this.voStrSwarmGMM;
      }   

      private void voResult_SelectedIndexChanged( object aoSender, EventArgs aoArgs )
      {
         ListBox koLB = aoSender as ListBox;

         if( koLB.SelectedIndex >= 0 )
         {
            this.voCluster.Clear( );
            for( int i = 0; i < this.voSwarmGMM[ koLB.SelectedIndex ].ViK; i++ )
            {
               this.voCluster.Add( String.Format( "Cluster {0}", i ) );
            }
            this.voLB.DataSource = null;
            this.voLB.DataSource = this.voCluster;
            this.voGmmnd = this.voSwarmGMM[ koLB.SelectedIndex ];
         }
         else
         {
            this.voPB.Image = null;
            this.voPB.Image = this.voOrig;
         }
      }
   
      private List< MyPoint > mClusterPoints( )
      {
         double          kdPm;
         int             kiC;
         MyPoint         koPt;
         List< MyPoint > koPList = new List< MyPoint >( );

         int x = 0, y = 0;
         for( int i = 0; i < this.voGmmnd.X.Rows; i++ )
         {
            // Gamma matrix has the probabilities for a data point for its membership in each cluster
            kiC = 0;
            kdPm = this.voGmmnd.Gamma[ i, 0 ];
            for( int m = 0; m < this.voGmmnd.ViK; m++ )
            {
               if( this.voGmmnd.Gamma[ i, m ] > kdPm )
               {
                  kiC = m;  // data i belongs to cluster m
                  kdPm = this.voGmmnd.Gamma[ i, m ];
               }
            }
            koPt = new MyPoint{ ClusterId = kiC, X = x, Y = y };
            koPList.Add( koPt );
            x++;
            if( x >= this.voOrig.Width )
            {
               x = 0;
               y++;
            }
         }

         return( koPList );
      }
   }
}
