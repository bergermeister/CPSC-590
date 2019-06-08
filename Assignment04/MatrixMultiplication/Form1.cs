using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixMultiplication
{
   public partial class Form1 : Form
   {
      const int xiSize = 1000;

      private double[ , ] vdA = null;
      private double[ , ] vdB = null;
      private double[ , ] vdC = null;
      private Random      voR = new Random( );

      public Form1( )
      {
         InitializeComponent( );
      }

      private void voBtnInit_Click( object sender, EventArgs e )
      {
         vdA = new double[ xiSize, xiSize ];
         vdB = new double[ xiSize, xiSize ];
         vdC = new double[ xiSize, xiSize ];

         for( int kiI = 0; kiI < xiSize; kiI++ )
         {
            for( int kiJ = 0; kiJ < xiSize; kiJ++ )
            {
               vdA[ kiI, kiJ ] = voR.NextDouble( ) * 100;
               vdB[ kiI, kiJ ] = voR.NextDouble( ) * 50;
            }
         }
      }

      private void voBtnMult_Click( object sender, EventArgs e )
      {
         Stopwatch koSW = new Stopwatch( );

         koSW.Start( );
         vdC = this.mMatrixMultiply( this.vdA, this.vdB );
         koSW.Stop( );

         MessageBox.Show( "Time Taken = " + koSW.ElapsedMilliseconds.ToString( ) );
      }

      private double[ , ] mMatrixMultiply( double[ , ] adX, double[ , ] adY )
      {
         double[ , ] kdRes = new double[ adX.GetLength( 0 ), adX.GetLength( 0 ) ];
         int         kiSize = adX.GetLength( 0 );

         Parallel.For( 0, kiSize, ( kiI ) =>
         {
            //for( int kiJ = 0; kiJ < kiSize; kiJ++ )
            for( int kiK = 0; kiK < kiSize; kiK++ )
            {
               //for( int kiK = 0; kiK < kiSize; kiK++ )
               for( int kiJ = 0; kiJ < kiSize; kiJ++ )
               {
                  kdRes[ kiI, kiJ ] = kdRes[ kiI, kiJ ] + ( adX[ kiI, kiK ] * adY[ kiK, kiJ ] );
               }
            }
         } );

         return( kdRes );
      }
   }
}
