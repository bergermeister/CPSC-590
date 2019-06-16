using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelLUDecomposition
{
   public partial class Form1 : Form
   {
      public Form1( )
      {
         InitializeComponent( );
      }

      private void voBtnSequential_Click( object aoSender, EventArgs aoArgs )
      {
         int         kiSize = 8;
         double[ , ] kdL  = new double[ kiSize, kiSize ];
         double[ , ] kdU  = new double[ kiSize, kiSize ];
         Matrix      koM = new Matrix( kiSize, kiSize );
         double      kdErr = 0.0;
         string      koOut = "";
         int         kiBlockSize;

         if( !Int32.TryParse( this.voTbSize.Text, out kiBlockSize ) )
         {
            kiBlockSize = 2;
         }

         /// -# Initialize Matrix
         koM[  0, 0 ] = 0.50; koM[  0, 1 ] = 2; koM[  0, 2 ] = 1.0; koM[  0, 3 ] =  4.0; koM[  0, 4 ] = 0.50; koM[  0, 5 ] = 2; koM[  0, 6 ] = 1.0; koM[  0, 7 ] =  4.0; //koM[  0, 8 ] = 0.50; koM[  0, 9 ] = 2; koM[  0, 10 ] = 1.0; koM[  0, 11 ] =  4.0; //koM[  0, 12 ] = 0.50; koM[  0, 13 ] = 2; koM[ 0, 14 ] = 1.0; koM[  0, 15 ] =  4.0;
         koM[  1, 0 ] = 1.25; koM[  1, 1 ] = 7; koM[  1, 2 ] = 3.5; koM[  1, 3 ] = 13.0; koM[  1, 4 ] = 1.25; koM[  1, 5 ] = 7; koM[  1, 6 ] = 3.5; koM[  1, 7 ] = 13.0; //koM[  1, 8 ] = 1.25; koM[  1, 9 ] = 7; koM[  1, 10 ] = 3.5; koM[  1, 11 ] = 13.0; //koM[  1, 12 ] = 1.25; koM[  1, 13 ] = 7; koM[ 1, 14 ] = 3.5; koM[  1, 15 ] = 13.0;
         koM[  2, 0 ] = 0.50; koM[  2, 1 ] = 5; koM[  2, 2 ] = 3.5; koM[  2, 3 ] = 10.5; koM[  2, 4 ] = 0.50; koM[  2, 5 ] = 5; koM[  2, 6 ] = 3.5; koM[  2, 7 ] = 10.5; //koM[  2, 8 ] = 0.50; koM[  2, 9 ] = 5; koM[  2, 10 ] = 3.5; koM[  2, 11 ] = 10.5; //koM[  2, 12 ] = 0.50; koM[  2, 13 ] = 5; koM[ 2, 14 ] = 3.5; koM[  2, 15 ] = 10.5;
         koM[  3, 0 ] = 0.50; koM[  3, 1 ] = 6; koM[  3, 2 ] = 6.0; koM[  3, 3 ] = 19.0; koM[  3, 4 ] = 0.50; koM[  3, 5 ] = 6; koM[  3, 6 ] = 6.0; koM[  3, 7 ] = 19.0; //koM[  3, 8 ] = 0.50; koM[  3, 9 ] = 6; koM[  3, 10 ] = 6.0; koM[  3, 11 ] = 19.0; //koM[  3, 12 ] = 0.50; koM[  3, 13 ] = 6; koM[ 3, 14 ] = 6.0; koM[  3, 15 ] = 19.0;
         koM[  4, 0 ] = 0.50; koM[  4, 1 ] = 2; koM[  4, 2 ] = 1.0; koM[  4, 3 ] =  4.0; koM[  4, 4 ] = 0.50; koM[  4, 5 ] = 2; koM[  4, 6 ] = 1.0; koM[  4, 7 ] =  4.0; //koM[  4, 8 ] = 0.50; koM[  4, 9 ] = 2; koM[  4, 10 ] = 1.0; koM[  4, 11 ] =  4.0; //koM[  4, 12 ] = 0.50; koM[  4, 13 ] = 2; koM[ 0, 14 ] = 1.0; koM[  4, 15 ] =  4.0;
         koM[  5, 0 ] = 1.25; koM[  5, 1 ] = 7; koM[  5, 2 ] = 3.5; koM[  5, 3 ] = 13.0; koM[  5, 4 ] = 1.25; koM[  5, 5 ] = 7; koM[  5, 6 ] = 3.5; koM[  5, 7 ] = 13.0; //koM[  5, 8 ] = 1.25; koM[  5, 9 ] = 7; koM[  5, 10 ] = 3.5; koM[  5, 11 ] = 13.0; //koM[  5, 12 ] = 1.25; koM[  5, 13 ] = 7; koM[ 1, 14 ] = 3.5; koM[  5, 15 ] = 13.0;
         koM[  6, 0 ] = 0.50; koM[  6, 1 ] = 5; koM[  6, 2 ] = 3.5; koM[  6, 3 ] = 10.5; koM[  6, 4 ] = 0.50; koM[  6, 5 ] = 5; koM[  6, 6 ] = 3.5; koM[  6, 7 ] = 10.5; //koM[  6, 8 ] = 0.50; koM[  6, 9 ] = 5; koM[  6, 10 ] = 3.5; koM[  6, 11 ] = 10.5; //koM[  6, 12 ] = 0.50; koM[  6, 13 ] = 5; koM[ 2, 14 ] = 3.5; koM[  6, 15 ] = 10.5;
         koM[  7, 0 ] = 0.50; koM[  7, 1 ] = 6; koM[  7, 2 ] = 6.0; koM[  7, 3 ] = 19.0; koM[  7, 4 ] = 0.50; koM[  7, 5 ] = 6; koM[  7, 6 ] = 6.0; koM[  7, 7 ] = 19.0; //koM[  7, 8 ] = 0.50; koM[  7, 9 ] = 6; koM[  7, 10 ] = 6.0; koM[  7, 11 ] = 19.0; //koM[  7, 12 ] = 0.50; koM[  7, 13 ] = 6; koM[ 3, 14 ] = 6.0; koM[  7, 15 ] = 19.0;
         //koM[  8, 0 ] = 0.50; koM[  8, 1 ] = 2; koM[  8, 2 ] = 1.0; koM[  8, 3 ] =  4.0; koM[  8, 4 ] = 0.50; koM[  8, 5 ] = 2; koM[  8, 6 ] = 1.0; koM[  8, 7 ] =  4.0; koM[  8, 8 ] = 0.50; koM[  8, 9 ] = 2; koM[  8, 10 ] = 1.0; koM[  8, 11 ] =  4.0; //koM[  8, 12 ] = 0.50; koM[  8, 13 ] = 2; koM[ 0, 14 ] = 1.0; koM[  8, 15 ] =  4.0;
         //koM[  9, 0 ] = 1.25; koM[  9, 1 ] = 7; koM[  9, 2 ] = 3.5; koM[  9, 3 ] = 13.0; koM[  9, 4 ] = 1.25; koM[  9, 5 ] = 7; koM[  9, 6 ] = 3.5; koM[  9, 7 ] = 13.0; koM[  9, 8 ] = 1.25; koM[  9, 9 ] = 7; koM[  9, 10 ] = 3.5; koM[  9, 11 ] = 13.0; //koM[  9, 12 ] = 1.25; koM[  9, 13 ] = 7; koM[ 1, 14 ] = 3.5; koM[  9, 15 ] = 13.0;
         //koM[ 10, 0 ] = 0.50; koM[ 10, 1 ] = 5; koM[ 10, 2 ] = 3.5; koM[ 10, 3 ] = 10.5; koM[ 10, 4 ] = 0.50; koM[ 10, 5 ] = 5; koM[ 10, 6 ] = 3.5; koM[ 10, 7 ] = 10.5; koM[ 10, 8 ] = 0.50; koM[ 10, 9 ] = 5; koM[ 10, 10 ] = 3.5; koM[ 10, 11 ] = 10.5; //koM[ 10, 12 ] = 0.50; koM[ 10, 13 ] = 5; koM[ 2, 14 ] = 3.5; koM[ 10, 15 ] = 10.5;
         //koM[ 11, 0 ] = 0.50; koM[ 11, 1 ] = 6; koM[ 11, 2 ] = 6.0; koM[ 11, 3 ] = 19.0; koM[ 11, 4 ] = 0.50; koM[ 11, 5 ] = 6; koM[ 11, 6 ] = 6.0; koM[ 11, 7 ] = 19.0; koM[ 11, 8 ] = 0.50; koM[ 11, 9 ] = 6; koM[ 11, 10 ] = 6.0; koM[ 11, 11 ] = 19.0; //koM[ 11, 12 ] = 0.50; koM[ 11, 13 ] = 6; koM[ 3, 14 ] = 6.0; koM[ 11, 15 ] = 19.0;
         //koM[ 12, 0 ] = 0.50; koM[ 12, 1 ] = 2; koM[ 12, 2 ] = 1.0; koM[ 12, 3 ] =  4.0; koM[ 12, 4 ] = 0.50; koM[ 12, 5 ] = 2; koM[ 12, 6 ] = 1.0; koM[ 12, 7 ] =  4.0; koM[ 12, 8 ] = 0.50; koM[ 12, 9 ] = 2; koM[ 12, 10 ] = 1.0; koM[ 12, 11 ] =  4.0; koM[ 12, 12 ] = 0.50; koM[ 12, 13 ] = 2; koM[ 0, 14 ] = 1.0; koM[ 12, 15 ] =  4.0;
         //koM[ 13, 0 ] = 1.25; koM[ 13, 1 ] = 7; koM[ 13, 2 ] = 3.5; koM[ 13, 3 ] = 13.0; koM[ 13, 4 ] = 1.25; koM[ 13, 5 ] = 7; koM[ 13, 6 ] = 3.5; koM[ 13, 7 ] = 13.0; koM[ 13, 8 ] = 1.25; koM[ 13, 9 ] = 7; koM[ 13, 10 ] = 3.5; koM[ 13, 11 ] = 13.0; koM[ 13, 12 ] = 1.25; koM[ 13, 13 ] = 7; koM[ 1, 14 ] = 3.5; koM[ 13, 15 ] = 13.0;
         //koM[ 14, 0 ] = 0.50; koM[ 14, 1 ] = 5; koM[ 14, 2 ] = 3.5; koM[ 14, 3 ] = 10.5; koM[ 14, 4 ] = 0.50; koM[ 14, 5 ] = 5; koM[ 14, 6 ] = 3.5; koM[ 14, 7 ] = 10.5; koM[ 14, 8 ] = 0.50; koM[ 14, 9 ] = 5; koM[ 14, 10 ] = 3.5; koM[ 14, 11 ] = 10.5; koM[ 14, 12 ] = 0.50; koM[ 14, 13 ] = 5; koM[ 2, 14 ] = 3.5; koM[ 14, 15 ] = 10.5;
         //koM[ 15, 0 ] = 0.50; koM[ 15, 1 ] = 6; koM[ 15, 2 ] = 6.0; koM[ 15, 3 ] = 19.0; koM[ 15, 4 ] = 0.50; koM[ 15, 5 ] = 6; koM[ 15, 6 ] = 6.0; koM[ 15, 7 ] = 19.0; koM[ 15, 8 ] = 0.50; koM[ 15, 9 ] = 6; koM[ 15, 10 ] = 6.0; koM[ 15, 11 ] = 19.0; koM[ 15, 12 ] = 0.50; koM[ 15, 13 ] = 6; koM[ 3, 14 ] = 6.0; koM[ 15, 15 ] = 19.0;

         /// -# Perform LU Decomposition
         koM.MLUDecomposeBlock( kdL, kdU, kiBlockSize, ref kdErr );
         //koM.MLUDecompose( kdL, kdU, ref kdErr );

         /// -# Print the error
         MessageBox.Show( "Error = " + kdErr.ToString( ) );
         
         for( int kiI = 0; kiI < kiSize; kiI++ )
         {
            for( int kiJ = 0; kiJ < kiSize; kiJ++ )
            {
               koOut += String.Format( "{0:f2}", kdL[ kiI, kiJ ] ) + " ";
            }
            koOut += Environment.NewLine;
         }
         MessageBox.Show( koOut );

         koOut = "";
         for (int kiI = 0; kiI < kiSize; kiI++ )
         {
            for( int kiJ = 0; kiJ < kiSize; kiJ++ )
            {
               koOut += String.Format( "{0:f2}", kdU[ kiI, kiJ ] ) + " ";
            }
            koOut += "\n";
         }
         MessageBox.Show( koOut );

         MessageBox.Show( koM.ToString( ) );
      }
   }
}
