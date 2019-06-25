using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMeansClustering
{
   public partial class Form1 : Form
   {
      private List< MyPoint > voPList = new List< MyPoint >( );

      public Form1( )
      {
         InitializeComponent( );
      }

      private void voBtnLoad_Click( object sender, EventArgs e )
      {
         string    koDataFileName;
         string    koLine;
         string[ ] koParts;
         char[ ]   kcDelim = { ',', ' ' };

         try
         {
            OpenFileDialog koDlg = new OpenFileDialog( );

            if( koDlg.ShowDialog( ) == DialogResult.OK )
            {
               this.voPList.Clear( );
               koDataFileName = koDlg.FileName;
               using( StreamReader koReader = new StreamReader( koDataFileName ) )
               {
                  while( ( koLine = koReader.ReadLine( ) ) != null )
                  {
                     koParts = koLine.Split( kcDelim );
                     if( koParts.Length >= 3 )
                     {
                        this.voPList.Add( new MyPoint( ){ VdX = double.Parse( koParts[ 1 ] ),
                                                          VdY = double.Parse( koParts[ 2 ] ) } );
                     }
                  }

                  MyImageProc.MDrawClusters( this.voPB, this.voPList, 1.0, 1 );
               }
            }
         }
         catch( Exception koEx )
         {
            MessageBox.Show( koEx.Message );
         }
      }

      private void voBtnInit_Click( object sender, EventArgs e )
      {
         MyPoint koPt;
         Random  koRand = new Random( );
         int     kiDataLength = 5000; // number of data points
         double  kdRNum;

         this.voPList.Clear( );

         // create 4 distributions with different means and std devs
         double kdMeanX0 = 150, kdMeanX1 = 250, kdMeanX2 = 375, kdMeanX3 = 475;
         double kdMeanY0 = 175, kdMeanY1 = 250, kdMeanY2 = 350, kdMeanY3 = 450; 
         double kdStdDevX0 = 240, kdStdDevX1 = 270, kdStdDevX2 = 220, kdStdDevX3 = 260;
         double kdStdDevY0 = 250, kdStdDevY1 = 240, kdStdDevY2 = 280, kdStdDevY3 = 245; 
         int kiIndex = 0;             
         for( int i = 0; i < ( kiDataLength / 4 ); i++ )
         {
            koPt = new MyPoint( );
            kdRNum = koRand.NextDouble( );
            if( kdRNum < 0.5 ) koPt.VdX = koRand.NextDouble( ) * kdStdDevX0 / 2 + kdMeanX0;
            else               koPt.VdX = -1 * koRand.NextDouble( ) * kdStdDevX0 / 2 + kdMeanX0;
            if( kdRNum < 0.5 ) koPt.VdY = koRand.NextDouble( ) * kdStdDevY0 / 2 + kdMeanY0;       
            else               koPt.VdY = -1 * koRand.NextDouble( ) * kdStdDevY0 / 2 + kdMeanY0;
            kiIndex++;                 
            this.voPList.Add( koPt );            
         } 
 
         for( int i = 0; i < ( kiDataLength / 4 ); i++ )
         {
            koPt = new MyPoint( );
            kdRNum = koRand.NextDouble( );
            if( kdRNum < 0.5 ) koPt.VdX = koRand.NextDouble( ) * kdStdDevX1 / 2 + kdMeanX1;
            else               koPt.VdX = -1 * koRand.NextDouble( ) * kdStdDevX1 / 2 + kdMeanX1;
            if( kdRNum < 0.5 ) koPt.VdY = koRand.NextDouble( ) * kdStdDevY1 / 2 + kdMeanY1;       
            else               koPt.VdY = -1 * koRand.NextDouble( ) * kdStdDevY1 / 2 + kdMeanY1;
            kiIndex++;                 
            this.voPList.Add( koPt );            
         } 
         
         for( int i = 0; i < ( kiDataLength / 4 ); i++ )
         {
            koPt = new MyPoint( );
            kdRNum = koRand.NextDouble( );
            if( kdRNum < 0.5 ) koPt.VdX = koRand.NextDouble( ) * kdStdDevX2 / 2 + kdMeanX2;
            else               koPt.VdX = -1 * koRand.NextDouble( ) * kdStdDevX2 / 2 + kdMeanX2;
            if( kdRNum < 0.5 ) koPt.VdY = koRand.NextDouble( ) * kdStdDevY2 / 2 + kdMeanY2;       
            else               koPt.VdY = -1 * koRand.NextDouble( ) * kdStdDevY2 / 2 + kdMeanY2;
            kiIndex++;                 
            this.voPList.Add( koPt );            
         } 
         
         for( int i = 0; i < ( kiDataLength / 4 ); i++ )
         {
            koPt = new MyPoint( );
            kdRNum = koRand.NextDouble( );
            if( kdRNum < 0.5 ) koPt.VdX = koRand.NextDouble( ) * kdStdDevX3 / 2 + kdMeanX3;
            else               koPt.VdX = -1 * koRand.NextDouble( ) * kdStdDevX3 / 2 + kdMeanX3;
            if( kdRNum < 0.5 ) koPt.VdY = koRand.NextDouble( ) * kdStdDevY3 / 2 + kdMeanY3;       
            else               koPt.VdY = -1 * koRand.NextDouble( ) * kdStdDevY3 / 2 + kdMeanY3;
            kiIndex++;                 
            this.voPList.Add( koPt );            
         }
         
         MyImageProc.MDrawClusters( this.voPB, this.voPList, 1.0, 1 );
      }

      private void voBtnKMeans_Click( object sender, EventArgs e )
      {
         int kiNumClusters;
         List< ClusterCenterPoint > koCList = null;

         try
         {
            if( this.voPList.Count == 0 )
            {
               throw new Exception( "No points data exists.." );
            }
            kiNumClusters = int.Parse( this.voTbCount.Text );
            KMeans.MDoKMeans( kiNumClusters, ref this.voPList, ref koCList, 0.1, 1000 );
            MyImageProc.MDrawClusters( this.voPB, this.voPList, 1.0, kiNumClusters );
            this.voTbResult.Text = mComputeAndShowVarianceResults( kiNumClusters );
         }
         catch( Exception koEx )
         {
            MessageBox.Show( koEx.Message );
         }
      }

      private void voBtnKMeansPP_Click( object sender, EventArgs e )
      {
         int kiNumClusters;
         List< ClusterCenterPoint > koCList = null;

         try
         {
            if( this.voPList.Count == 0 )
            {
               throw new Exception( "No points data exists.." );
            }
            kiNumClusters = int.Parse( this.voTbCount.Text );
            KMeans.MDoKMeans( kiNumClusters, ref this.voPList, ref koCList, 0.1, 1000, true );
            MyImageProc.MDrawClusters( this.voPB, this.voPList, 1.0, kiNumClusters );
            this.voTbResult.Text = mComputeAndShowVarianceResults( kiNumClusters );
         }
         catch( Exception koEx )
         {
            MessageBox.Show( koEx.Message );
         }
      }

      private void voBtnKMeanPPV_Click( object sender, EventArgs e )
      {
         int kiNumClusters;
         List< ClusterCenterPoint > koCList = null;

         try
         {
            if( this.voPList.Count == 0 )
            {
               throw new Exception( "No points data exists.." );
            }
            kiNumClusters = int.Parse( this.voTbCount.Text );
            KMeans.MDoKMeansWithMinVariance( kiNumClusters, ref this.voPList, ref koCList, 0.1, 1000, true );
            MyImageProc.MDrawClusters( this.voPB, this.voPList, 1.0, kiNumClusters );
            this.voTbResult.Text = mComputeAndShowVarianceResults( kiNumClusters );
         }
         catch( Exception koEx )
         {
            MessageBox.Show( koEx.Message );
         }
      }

      private string mComputeAndShowVarianceResults( int aiNumClusters )
      {
         // ----compute variance of cluster memberships
         string koOut;
         int[ ] kiCCount = new int[ aiNumClusters ];
         double kdVariance;
         double kdStdDev;

         for( int i = 0; i < aiNumClusters; i++ )
            kiCCount[ i ] = 0;             
         foreach( MyPoint koMP in this.voPList )
            kiCCount[ koMP.ViClusterId ] += 1;             
         
          kdVariance = 0;
         for( int i = 0; i < aiNumClusters; i++ )
            kdVariance += ( kiCCount[ i ] - ( this.voPList.Count / ( double )aiNumClusters ) ) * 
                          ( kiCCount[ i ] - ( this.voPList.Count / ( double )aiNumClusters ) );

         kdStdDev = Math.Sqrt( kdVariance ); 
 
         koOut = "Std Dev = " + string.Format( "{0:f2}", kdStdDev ) +"\r\n" ;
         for( int n = 0; n < kiCCount.Length; n++ )
            koOut += "Cluster #" + n.ToString( ) + " count = " + kiCCount[ n ].ToString( ) + "\r\n";             
         
         return( koOut );
      }
   }
}
