using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

      private int viK = 2; // Number of clusters
      private int viDataSize = 20;
      private double[ ] vdMu;
      private Random  voRand = new Random( );
      double[ ]   vdSigma = null; // Standard deviation for cluter k
      double[ , ] vdPDF   = null; // Calculated pdf for each data point based on mean and var for cluster k
      double[ , ] vdGamma = null; // probability matrix for each data point (i.e. probability that a data point belongs to cluster)
      double[ ]   vdPHI   = null; // Prior probabilities for each cluster

      public Form1( )
      {
         InitializeComponent( );
      }

      private void voBtnTestGMM_Click( object sender, EventArgs e )
      {
         double[ ] kdX1 = new double[ 10 ];
         double[ ] kdX2 = new double[ 10 ];
         double[ ] kdX;

         this.vdMu    = new double[ this.viK ];
         this.vdSigma = new double[ this.viK ];
         this.vdPHI   = new double[ this.viK ];
         this.vdGamma = new double[ this.viDataSize, this.viK ];
         this.vdPDF   = new double[ this.viDataSize, this.viK ];

         this.vdMu   [ 0 ] = 10; this.vdMu   [ 1 ] = 15;
         this.vdSigma[ 0 ] = 1;  this.vdSigma[ 1 ] = 3;

         for( int i = 0; i < 10; i++ )
         {
            kdX1[ i ] = ( this.voRand.NextDouble( ) * this.vdSigma[ 0 ] ) + this.vdMu[ 0 ];
            kdX2[ i ] = ( this.voRand.NextDouble( ) * this.vdSigma[ 1 ] ) + this.vdMu[ 1 ];
         }

         kdX = kdX1.Concat( kdX2 ).ToArray< double >( );

         /// -# Step: Initialization - Randomly select k data points to act as means
         List< int > koRList = new List< int >( );
         for( int i = 0; i < this.viK; i++ )
         {
            int kiRPos = this.voRand.Next( kdX.Length );
            if( koRList.Contains( kiRPos ) )
            {
               kiRPos = this.voRand.Next( kdX.Length );
            }
            this.vdMu[ i ] = kdX[ kiRPos ];
         }

         double kdVarianceOfData = this.MComputeVariance( kdX );
         for( int i = 0; i < this.viK; i++ )
         {
            this.vdSigma[ i ] = Math.Sqrt( kdVarianceOfData );
         }

         // Set prior probabilities of each cluster to be uniform.
         for( int i = 0; i < this.viK; i++ )
         {
            this.vdPHI[ i ] = 1.0 / this.viK;
         }

         /// -# Expectation Maximization
         for( int n = 0; n < 1000; n++ )
         {
            /// -# Step: Expectation
            for( int i = 0; i < kdX.Length; i++ )
            {
               for( int kk = 0; kk < this.viK; kk++ )
               {
                  this.vdPDF[ i, kk ] = this.MGaussian( kdX[ i ], this.vdMu[ kk ], this.vdSigma[ kk ] );
               }
            }
            double[ ] kdGdenom = new double[ kdX.Length ];
            for( int i = 0; i < kdX.Length; i++ )
            {
               double kdSum = 0.0;
               for( int kk = 0; kk < this.viK; kk++ )
               {
                  kdSum += this.vdPHI[ kk ] * this.vdPDF[ i, kk ];
               }
               kdGdenom[ i ] = kdSum;
            }

            for( int i = 0; i < kdX.Length; i++ )
            {
               for( int kk = 0; kk < this.viK; kk++ )
               {
                  this.vdGamma[ i, kk ] = ( this.vdPHI[ kk ] * this.vdPDF[ i, kk ] ) / kdGdenom[ i ];
               }
            }

            /// -# Step: Maximization
            for( int kk = 0; kk < this.viK; kk++ )
            {
               double kdSum = 0.0;
               for( int i = 0; i < kdX.Length; i++ )
               {
                  kdSum += this.vdGamma[ i, kk ];
               }
               this.vdPHI[ kk ] = kdSum / kdX.Length;
            }

            double[ ] kdMuNum = new double[ kdX.Length ];
            for( int kk = 0; kk < this.viK; kk++ )
            {
               double kdSum = 0.0;
               for( int i = 0; i < kdX.Length; i++ )
               {
                  kdSum += this.vdGamma[ i, kk ] * kdX[ i ];
               }
               kdMuNum[ kk ] = kdSum;
            }

            double[ ] kdMuDen = new double[ kdX.Length ];
            for( int kk = 0; kk < this.viK; kk++ )
            {
               double kdSum = 0.0;
               for( int i = 0; i < kdX.Length; i++ )
               {
                  kdSum += this.vdGamma[ i, kk ];
               }
               kdMuDen[ kk ] = kdSum;
            }

            for( int i = 0; i < this.viK; i++ )
            {
               this.vdMu[ i ] = kdMuNum[ i ] / kdMuDen[ i ];
            }

            double[ ] kdVarNum = new double[ kdX.Length ];
            for( int kk = 0; kk < this.viK; kk++ )
            {
               double kdSum = 0.0;
               for( int i = 0; i < kdX.Length; i++ )
               {
                  kdSum += this.vdGamma[ i, kk ] * ( kdX[ i ] - this.vdMu[ kk ] ) * ( kdX[ i ] - this.vdMu[ kk ] );
               }
               kdVarNum[ kk ] = kdSum;
            }
            for( int i = 0; i < this.viK; i++ )
            {
               this.vdSigma[ i ] = Math.Sqrt( kdVarNum[ i ] / kdMuDen[ i ] );
            }
         }
      }

      private void voBtnTestClass_Click( object sender, EventArgs e )
      {
         string    koOut = "";
         int       kiCnum = 0;
         double[ ] kdC = new double[ this.viK ];   // p(Ci|x)  - probablity x belongs to cluster Ci  
         double    kdNum = double.Parse( this.voTxtNum.Text );             
         double    kdDen = 0.0;  
         for( int i = 0; i < this.viK; i++ )
         {
            kdDen += this.vdPHI[ i ] * this.MGaussian( kdNum, this.vdMu[ i ], this.vdSigma[ i ] );
         }
    
         for( int i = 0; i < this.viK; i++ )
         {
            kdC[ i ] = this.vdPHI[ i ] * this.MGaussian( kdNum, this.vdMu[ i ], this.vdSigma[ i ] ) / kdDen;
         }
         
         foreach( double kdP in kdC )
         {
            koOut += "Cluster " + kiCnum.ToString( ) + " Probab. = " + kdP.ToString( ) + "\n";
            kiCnum++;
         }      
         MessageBox.Show( koOut );
      }

      public double MComputeVariance( double[ ] adData )
      {
         double kdAvg = adData.Average( );
         double kdSum = 0.0;
         
         foreach( double kdNum in adData )
         {
            kdSum += ( kdNum - kdAvg ) * ( kdNum - kdAvg );
         }
         
         return( kdSum / adData.Length );
      } 
 
      public double MGaussian( double adNum, double adMean, double adStdDev ) // 1-D gaussian
      {
         double kdRes = ( 1.0 / ( adStdDev * Math.Sqrt( 2.0 * Math.PI ) ) ) * 
                        Math.Exp( ( -1.0 * ( adNum - adMean ) * ( adNum - adMean ) ) / ( 2.0 * adStdDev * adStdDev ) );
         return( kdRes );
      } 
   }
}
