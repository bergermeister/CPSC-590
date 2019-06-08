using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelQuickSort
{
   public partial class Form1 : Form
   {
      public Form1( )
      {
         InitializeComponent( );
      }

      private void voBtnSortSeqS_Click( object sender, EventArgs e )
      {
         string koOut = "";
         double[ ] koData = { 3, 9, 15, 7, 8, 4, 11 };

         QuicksortAlgorithms.MQuicksort< double >( koData, 0, koData.Length - 1 );
         
         foreach( int kiN in koData )
         {
            koOut += kiN.ToString( ) + " " + Environment.NewLine;
         }

         MessageBox.Show( koOut );
      }

      private void voBtnSortSeqL_Click( object sender, EventArgs e )
      {
         int       kiSize = 10000000;
         double[ ] kdData = new double[ kiSize ];
         Stopwatch koSW   = new Stopwatch( );

         this.mInitData( kdData );

         koSW.Start( );             
         QuicksortAlgorithms.MQuicksort< double >( kdData, 0, kdData.Length - 1 );
         koSW.Stop( ); 

         MessageBox.Show( "Sequential: Time taken = " +
                          koSW.ElapsedMilliseconds.ToString( ) );
      }

      private void vobtnSortParL_Click( object sender, EventArgs e )
      {
         int       kiSize = 10000000;
         double[ ] kdData = new double[ kiSize ];
         Stopwatch koSW   = new Stopwatch( );

         this.mInitData( kdData );

         koSW.Start( );             
         QuicksortAlgorithms.MQuicksortParallel< double >( kdData, 0, kdData.Length - 1 );
         koSW.Stop( ); 

         MessageBox.Show( "Sequential: Time taken = " +
                          koSW.ElapsedMilliseconds.ToString( ) );
      }

      private void mInitData( double[ ] aoData )
      {
         Random koRand = new Random( );
         for( int kiI = 0; kiI < aoData.Length; kiI++ )
         {
            aoData[ kiI ] = ( koRand.NextDouble( ) * 1000 ) + 5;
         }
      }
   }
}
