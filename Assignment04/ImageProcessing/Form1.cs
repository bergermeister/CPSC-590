using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
   public partial class Form1 : Form
   {
      private Bitmap voOrig;
      private Bitmap voProc;

      public Form1( )
      {
         InitializeComponent( );
      }

      private void voBtnLoadImage_Click( object sender, EventArgs e )
      {
         OpenFileDialog koDialog = new OpenFileDialog( );
         
         if( koDialog.ShowDialog( ) == DialogResult.OK )
         {
            this.voOrig = new Bitmap( koDialog.FileName );
            this.voPictureBox.Image = this.voOrig;
            this.voLblWidth.Text = this.voOrig.Width.ToString( );
            this.voLblHeight.Text = this.voOrig.Height.ToString( );
         }
      }

      private void voBtnConvertSafe_Click( object sender, EventArgs e )
      {
         Stopwatch koSW = new Stopwatch( );
         Color     koPixel;
         int       kiWidth = this.voOrig.Width;
         int       kiHeight = this.voOrig.Height;
         int       kiX, kiY;
         int       kiR, kiG, kiB;
         int       kiGray;

         this.voProc = new Bitmap( kiWidth, kiHeight );

         koSW.Start( );
         for( kiY = 0; kiY < kiHeight; kiY++ )
         {
            for( kiX = 0; kiX < kiWidth; kiX++ )
            {
               koPixel = this.voOrig.GetPixel( kiX, kiY );
               kiR = koPixel.R;
               kiG = koPixel.G;
               kiB = koPixel.B;
               kiGray = ( int )( ( 0.299 * kiR ) + ( 0.587 * kiG ) + ( 0.114 * kiB ) );
               this.voProc.SetPixel( kiX, kiY, Color.FromArgb( kiGray, kiGray, kiGray ) );
            }
         }
         koSW.Stop( );

         this.voPictureBox.Image = this.voProc;
         MessageBox.Show( "Time Taken = " + koSW.ElapsedMilliseconds.ToString( ) + " milliseconds" );
      }

      private void voBtnConvertUnsafe_Click( object sender, EventArgs e )
      {
         Stopwatch  koSW = new Stopwatch( );

         koSW.Start( );
         unsafe
         {
            
            BitmapData koBmpData;
            int        kiWidth = this.voOrig.Width;
            int        kiHeight = this.voOrig.Height;
            int        kiBPP; // Bit Per Pixel
            int        kiStride;
            int        kiX, kiY;
            int        kiR, kiG, kiB;
            int        kiGray;
            byte*      kcpData;
            byte*      kcpLine;

            this.voProc = new Bitmap( this.voOrig );
            koBmpData = this.voProc.LockBits( new Rectangle( 0, 0, kiWidth, kiHeight ),
                                              ImageLockMode.ReadWrite, this.voProc.PixelFormat );
            kiBPP = Bitmap.GetPixelFormatSize( this.voProc.PixelFormat ) / 8;
            kiStride = kiWidth * kiBPP;
            kcpData = ( byte* )koBmpData.Scan0;
            for( kiY = 0; kiY < kiHeight; kiY++ )
            {
               kcpLine = kcpData + ( kiY * koBmpData.Stride );
               for( kiX = 0; kiX < kiStride; kiX += kiBPP )
               {
                  kiB = kcpLine[ kiX + 0 ];
                  kiG = kcpLine[ kiX + 1 ];
                  kiR = kcpLine[ kiX + 2 ];

                  kiGray = ( int )( ( 0.299 * kiR ) + ( 0.587 * kiG ) + ( 0.114 * kiB ) );

                  kcpLine[ kiX + 0 ] = ( byte )kiGray;
                  kcpLine[ kiX + 1 ] = ( byte )kiGray;
                  kcpLine[ kiX + 2 ] = ( byte )kiGray;
               }
            }
            this.voProc.UnlockBits( koBmpData );
         }
         koSW.Stop( );
         this.voPictureBox.Image = this.voProc;
         MessageBox.Show( "Time Taken = " + koSW.ElapsedMilliseconds.ToString( ) + " milliseconds" );
      }

      private void voBtnConvertParallel_Click( object sender, EventArgs e )
      {
         Stopwatch  koSW = new Stopwatch( );

         koSW.Start( );
         unsafe
         {
            
            BitmapData koBmpData;
            int        kiWidth = this.voOrig.Width;
            int        kiHeight = this.voOrig.Height;
            int        kiBPP; // Bit Per Pixel
            int        kiStride;
            byte*      kcpData;

            this.voProc = new Bitmap( this.voOrig );
            koBmpData = this.voProc.LockBits( new Rectangle( 0, 0, kiWidth, kiHeight ),
                                              ImageLockMode.ReadWrite, this.voProc.PixelFormat );
            kiBPP = Bitmap.GetPixelFormatSize( this.voProc.PixelFormat ) / 8;
            kiStride = kiWidth * kiBPP;
            kcpData = ( byte* )koBmpData.Scan0;
            Parallel.For( 0, kiHeight, ( kiY ) =>
            {
               byte* kcpLine = kcpData + ( kiY * koBmpData.Stride );
               for( int kiX = 0; kiX < kiStride; kiX += kiBPP )
               {
                  int kiB = kcpLine[ kiX + 0 ];
                  int kiG = kcpLine[ kiX + 1 ];
                  int kiR = kcpLine[ kiX + 2 ];

                  int kiGray = ( int )( ( 0.299 * kiR ) + ( 0.587 * kiG ) + ( 0.114 * kiB ) );

                  kcpLine[ kiX + 0 ] = ( byte )kiGray;
                  kcpLine[ kiX + 1 ] = ( byte )kiGray;
                  kcpLine[ kiX + 2 ] = ( byte )kiGray;
               }
            } );
            this.voProc.UnlockBits( koBmpData );
         }
         koSW.Stop( );
         this.voPictureBox.Image = this.voProc;
         MessageBox.Show( "Time Taken = " + koSW.ElapsedMilliseconds.ToString( ) + " milliseconds" );
      }
   }
}
