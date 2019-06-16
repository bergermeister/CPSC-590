using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondWCFClient
{
   public partial class Form1 : Form
   {
      public Form1( )
      {
         InitializeComponent( );
      }

      private void voBtnGetEmp_Click( object sender, EventArgs e )
      {
         ES.EmployeeServiceClient esc = new ES.EmployeeServiceClient( );
         dataGridView1.DataSource = esc.GetAllEmployees( );
         dataGridView1.Refresh( );  
      }

      private void voBtnMatMult_Click( object sender, EventArgs e )
      {
         MM2.MyMath2Client mmc = new MM2.MyMath2Client( );
         MM2.Matrix        A = mmc.InitMatrix( 2, 2 );
         MM2.Matrix        B = mmc.InitMatrix( 2, 2 );
         MM2.Matrix        C;
         string            koOut = "";

         A.Data[ 0 ][ 0 ] = 5; A.Data[ 0 ][ 1 ] = 7; A.Data[ 1 ][ 0 ] = 3; A.Data[ 1 ][ 1 ] = 4;
         B.Data[ 0 ][ 0 ] = 3; B.Data[ 0 ][ 1 ] = 5; B.Data[ 1 ][ 0 ] = 1; B.Data[ 1 ][ 1 ] = 6;
         C = mmc.MultiplyMatrix( A, B );
         for( int i = 0; i < C.Rows; i++ )
         {
            for( int j = 0; j < C.Cols; j++ )
            {
               koOut += "C[" + i.ToString( ) + "][" + j.ToString( ) + "]=";
               koOut += C.Data[ i ][ j ].ToString( ) + " ";
            }
            koOut += Environment.NewLine;
         }
         MessageBox.Show( koOut );
      }
   }
}
