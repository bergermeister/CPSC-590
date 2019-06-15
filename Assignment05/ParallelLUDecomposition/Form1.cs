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
         double[ , ] kdL  = new double[ 4, 4 ];
         double[ , ] kdU  = new double[ 4, 4 ];
         Matrix      koM = new Matrix( 4, 4 );
         double      kdErr = 0.0;
         string      koOut = "";
         int         kiBlockSize;

         //Matrix koA = new Matrix( 3, 3 );
         //Matrix koB = new Matrix( 3, 3 );
         //koA[ 0, 0 ] = 1.0; koA[ 0, 1 ] = 2.0; koA[ 0, 2 ] = 3.0;
         //koA[ 1, 0 ] = 4.0; koA[ 1, 1 ] = 5.0; koA[ 1, 2 ] = 6.0;
         //koA[ 2, 0 ] = 7.0; koA[ 2, 1 ] = 8.0; koA[ 2, 2 ] = 9.0;
         //koB[ 0, 0 ] = 7.0; koB[ 0, 1 ] = 9.0; koB[ 0, 2 ] = 8.0;
         //koB[ 1, 0 ] = 1.0; koB[ 1, 1 ] = 2.0; koB[ 1, 2 ] = 3.0;
         //koB[ 2, 0 ] = 4.0; koB[ 2, 1 ] = 6.0; koB[ 2, 2 ] = 5.0;
         //Matrix koR = koA * koB;
         //MessageBox.Show( koR.ToString( ) );

         if( !Int32.TryParse( this.voTbSize.Text, out kiBlockSize ) )
         {
            kiBlockSize = 2;
         }

         /// -# Initialize Matrix
         koM[ 0, 0 ] = 0.50; koM[ 0, 1 ] = 2; koM[ 0, 2 ] = 1.0; koM[ 0, 3 ] =  4.0;
         koM[ 1, 0 ] = 1.25; koM[ 1, 1 ] = 7; koM[ 1, 2 ] = 3.5; koM[ 1, 3 ] = 13.0;
         koM[ 2, 0 ] = 0.50; koM[ 2, 1 ] = 5; koM[ 2, 2 ] = 3.5; koM[ 2, 3 ] = 10.5;
         koM[ 3, 0 ] = 0.50; koM[ 3, 1 ] = 6; koM[ 3, 2 ] = 6.0; koM[ 3, 3 ] = 19.0;
         
         /// -# Perform LU Decomposition
         koM.MLUDecomposeBlock( kdL, kdU, kiBlockSize, ref kdErr );
         //koM.MLUDecompose( kdL, kdU, ref kdErr );

         /// -# Print the error
         MessageBox.Show( "Error = " + kdErr.ToString( ) );
         
         for( int kiI = 0; kiI < 4; kiI++ )
         {
            for( int kiJ = 0; kiJ < 4; kiJ++ )
            {
               koOut += String.Format( "{0:f2}", kdL[ kiI, kiJ ] ) + " ";
            }
            koOut += Environment.NewLine;
         }
         MessageBox.Show( koOut );

         koOut = "";
         for (int kiI = 0; kiI < 4; kiI++ )
         {
            for( int kiJ = 0; kiJ < 4; kiJ++ )
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
