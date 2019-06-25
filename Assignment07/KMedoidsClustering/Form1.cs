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

namespace KMedoidsClustering
{
   public partial class Form1 : Form
   {
      private List< Point > voPList = new List< Point >( );
      KMedoid< Point > voKM = null;

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
                        this.voPList.Add( new Point( int.Parse( koParts[ 1 ] ), int.Parse( koParts[ 2 ] ) ) );
                     }
                  }
               }

               //Visualization.MDrawClusters( this.voPB, this.voPList, 1.0, 1 );
            }
         }
         catch( Exception koEx )
         {
            MessageBox.Show( koEx.Message );
         }
      }

      private void voBtnInit_Click( object sender, EventArgs e )
      {
         Point   koPt;
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
            koPt = new Point( );
            kdRNum = koRand.NextDouble( );
            if( kdRNum < 0.5 ) koPt.X = ( int )( koRand.NextDouble( ) * kdStdDevX0 / 2 + kdMeanX0 );
            else               koPt.X = ( int )( -1 * koRand.NextDouble( ) * kdStdDevX0 / 2 + kdMeanX0 );
            if( kdRNum < 0.5 ) koPt.Y = ( int )( koRand.NextDouble( ) * kdStdDevY0 / 2 + kdMeanY0 );       
            else               koPt.Y = ( int )( -1 * koRand.NextDouble( ) * kdStdDevY0 / 2 + kdMeanY0 );
            kiIndex++;                 
            this.voPList.Add( koPt );            
         } 
 
         for( int i = 0; i < ( kiDataLength / 4 ); i++ )
         {
            koPt = new Point( );
            kdRNum = koRand.NextDouble( );
            if( kdRNum < 0.5 ) koPt.X = ( int )( koRand.NextDouble( ) * kdStdDevX1 / 2 + kdMeanX1 );
            else               koPt.X = ( int )( -1 * koRand.NextDouble( ) * kdStdDevX1 / 2 + kdMeanX1 );
            if( kdRNum < 0.5 ) koPt.Y = ( int )( koRand.NextDouble( ) * kdStdDevY1 / 2 + kdMeanY1 );       
            else               koPt.Y = ( int )( -1 * koRand.NextDouble( ) * kdStdDevY1 / 2 + kdMeanY1 );
            kiIndex++;                 
            this.voPList.Add( koPt );            
         } 
         
         for( int i = 0; i < ( kiDataLength / 4 ); i++ )
         {
            koPt = new Point( );
            kdRNum = koRand.NextDouble( );
            if( kdRNum < 0.5 ) koPt.X = ( int )( koRand.NextDouble( ) * kdStdDevX2 / 2 + kdMeanX2 );
            else               koPt.X = ( int )( -1 * koRand.NextDouble( ) * kdStdDevX2 / 2 + kdMeanX2 );
            if( kdRNum < 0.5 ) koPt.Y = ( int )( koRand.NextDouble( ) * kdStdDevY2 / 2 + kdMeanY2 );       
            else               koPt.Y = ( int )( -1 * koRand.NextDouble( ) * kdStdDevY2 / 2 + kdMeanY2 );
            kiIndex++;                 
            this.voPList.Add( koPt );            
         } 
         
         for( int i = 0; i < ( kiDataLength / 4 ); i++ )
         {
            koPt = new Point( );
            kdRNum = koRand.NextDouble( );
            if( kdRNum < 0.5 ) koPt.X = ( int )( koRand.NextDouble( ) * kdStdDevX3 / 2 + kdMeanX3 );
            else               koPt.X = ( int )( -1 * koRand.NextDouble( ) * kdStdDevX3 / 2 + kdMeanX3 );
            if( kdRNum < 0.5 ) koPt.Y = ( int )( koRand.NextDouble( ) * kdStdDevY3 / 2 + kdMeanY3 );       
            else               koPt.Y = ( int )( -1 * koRand.NextDouble( ) * kdStdDevY3 / 2 + kdMeanY3 );
            kiIndex++;                 
            this.voPList.Add( koPt );            
         }
      }

      private void voBtnKMedoid_Click( object sender, EventArgs e )
      {
         try             
         {
            // define distance function
            Func< Point, Point, double > koEuclidean = ( a, b ) => Math.Sqrt( Math.Pow( ( a.X - b.X ), 2 ) + Math.Pow( ( a.Y - b.Y ), 2 ) ); 
            this.voKM = new KMedoid< Point >( koEuclidean );
            int kiK = int.Parse( this.voTbK.Text );
            this.voKM.MCompute( kiK, this.voPList ); 
            Visualization.MDrawClusters( this.voPB, this.voPList, this.voKM.VoClusters, kiK, 
                                         this.voKM.VdMedoids.ToList( ), 0.7 );
            this.voTbResult.Text = mComputeAndShowVarianceResults( kiK );
         }
         catch( Exception koEx )
         {
            MessageBox.Show( koEx.Message );
         } 
      }

      private void voBtnRedraw_Click( object sender, EventArgs e )
      {
         Visualization.MDrawClusters( this.voPB, this.voPList, this.voKM.VoClusters,
                                      int.Parse( this.voTbK.Text), this.voKM.VdMedoids.ToList( ), 0.5 );
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
         foreach( int kiClusterNum in this.voKM.VoClusters )
            kiCCount[ kiClusterNum ] += 1;             
         
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
