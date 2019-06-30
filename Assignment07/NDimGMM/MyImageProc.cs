using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Windows.Forms;

using Mapack;

namespace GMM
{
    public class MyImageProc
    {
        public static bool DrawX(Graphics g, Point pt1)
        {
            Brush br = new SolidBrush(Color.Red);
            Point p1a = new Point(pt1.X - 4, pt1.Y - 4);
            Point p2a = new Point(pt1.X + 4, pt1.Y + 4);
            g.DrawLine(new Pen(Color.Red, 2), p1a, p2a);
            Point p3a = new Point(pt1.X + 4, pt1.Y - 4);
            Point p4a = new Point(pt1.X - 4, pt1.Y + 4);
            g.DrawLine(new Pen(Color.Red, 2), p3a, p4a);
            return true;
        }

      public static bool DrawCluster( PictureBox aoPan, List< MyPoint > aoPList, ref Bitmap aoBmp, double scale, int aiCnum )
      {
         for( int y = 0; y < aoBmp.Height; y++ )
         {
            for( int x = 0; x < aoBmp.Width; x++ )
            {
               if( aoPList[ ( y * aoBmp.Width ) + x ].ClusterId != aiCnum )
               {
                  aoBmp.SetPixel( x, y, Color.FromArgb( 255, 255, 255 ) );
               }
            }
         }

         aoPan.Image = aoBmp;

         return( true );
      }

        public static bool DrawClusters(PictureBox pan, List<MyPoint> PList, double scale, int clusterCount)
        {
            Graphics g = pan.CreateGraphics();

            g.Clear(Color.White);
            
            // set cluster colors
            Color[] CColors = new Color[clusterCount];
            for (int i = 0; i < clusterCount; i++)
            {
                if (i == 0)
                    CColors[i] = Color.Red;
                else if (i == 1)
                    CColors[i] = Color.Green;
                else if (i == 2)
                    CColors[i] = Color.Purple;
                else if (i == 3)
                    CColors[i] = Color.Aqua;
                else if (i == 4)
                    CColors[i] = Color.Black;
                else if (i == 5)
                    CColors[i] = Color.Orange;
                else if (i == 6)
                    CColors[i] = Color.Salmon;
                else if (i == 7)
                    CColors[i] = Color.Yellow;
                else if (i == 8)
                    CColors[i] = Color.Pink;
                else if (i == 9)
                    CColors[i] = Color.LightBlue;
                else if (i == 10)
                    CColors[i] = Color.Lavender;
                else if (i == 11)
                    CColors[i] = Color.LightGreen;
                else if (i == 12)
                    CColors[i] = Color.LightSeaGreen;
                else if (i == 13)
                    CColors[i] = Color.LightSteelBlue;
                else if (i == 14)
                    CColors[i] = Color.Lime;
                else if (i == 15)
                    CColors[i] = Color.Magenta;
                else if (i == 16)
                    CColors[i] = Color.MediumAquamarine;
                else if (i == 17)
                    CColors[i] = Color.PaleVioletRed;
                else if (i == 18)
                    CColors[i] = Color.Firebrick;
                else if (i == 19)
                    CColors[i] = Color.DodgerBlue;
                else if (i == 20)
                    CColors[i] = Color.HotPink;
                else if (i == 21)
                    CColors[i] = Color.Orchid;
                else if (i == 22)
                    CColors[i] = Color.Sienna;
                else if (i == 23)
                    CColors[i] = Color.Turquoise;
                else if (i == 24)
                    CColors[i] = Color.YellowGreen;
                else if (i == 25)
                    CColors[i] = Color.Tomato;
                else if (i == 26)
                    CColors[i] = Color.Indigo;
                else if (i == 27)
                    CColors[i] = Color.PaleVioletRed;
                else if (i == 28)
                    CColors[i] = Color.Peru;
                else if (i == 29)
                    CColors[i] = Color.Plum;
                else if ((i % 2) == 0)
                    CColors[i] = Color.FromArgb(255, 180 - (i * 2), 100 + (i * 2));
                else
                    CColors[i] = Color.FromArgb(100 + i * 2, 180 - (i * 2), 255);
            }


            Graphics dc = pan.CreateGraphics();
            Brush br = new SolidBrush(Color.Red);

            Point p1 = new Point { X = (int)PList[0].X, Y = (int)PList[0].Y };
            Point p1a = new Point((int)(p1.X * scale) - 2, (int)(p1.Y * scale) - 2);
            Point p2a = new Point((int)(p1.X * scale) + 2, (int)(p1.Y * scale) + 2);
            dc.DrawLine(new Pen(CColors[PList[0].ClusterId], 1), p1a, p2a);
            Point p3a = new Point((int)(p1.X * scale) + 2, (int)(p1.Y * scale) - 2);
            Point p4a = new Point((int)(p1.X * scale) - 2, (int)(p1.Y * scale) + 2);
            dc.DrawLine(new Pen(CColors[PList[0].ClusterId], 1), p3a, p4a);
            Point pstart = new Point(p1.X, p1.Y);

            Point p2;
            for (int i = 1; i < PList.Count; i++)
            {
                p2 = new Point { X = (int)PList[i].X, Y = (int) PList[i].Y };
                p1a = new Point((int)(p2.X * scale) - 2, (int)(p2.Y * scale) - 2);
                p2a = new Point((int)(p2.X * scale) + 2, (int)(p2.Y * scale) + 2);
                dc.DrawLine(new Pen(CColors[PList[i].ClusterId], 1), p1a, p2a);
                p3a = new Point((int)(p2.X * scale) + 2, (int)(p2.Y * scale) - 2);
                p4a = new Point((int)(p2.X * scale) - 2, (int)(p2.Y * scale) + 2);
                dc.DrawLine(new Pen(CColors[PList[i].ClusterId]), p3a, p4a);
            }
            return true;
        }
    }
}
