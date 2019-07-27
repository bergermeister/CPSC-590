using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;

namespace TSGAMT2010
{
    public class MyImageProc
    {
        public static bool DrawX(Image img, ref Bitmap bm, Point pt1)
        {
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            Brush br = new SolidBrush(Color.Red);
            Point p1a = new Point(pt1.X - 4, pt1.Y - 4);
            Point p2a = new Point(pt1.X + 4, pt1.Y + 4);
            dc.DrawLine(new Pen(Color.Red, 2), p1a, p2a);
            Point p3a = new Point(pt1.X + 4, pt1.Y - 4);
            Point p4a = new Point(pt1.X - 4, pt1.Y + 4);
            dc.DrawLine(new Pen(Color.Red, 2), p3a, p4a);
            //	dc.DrawString("x",new Font(FontFamily.GenericSansSerif,10),
            //		br,pt);
            return true;
        }

        public static bool DrawTour(Image img, ref Bitmap bm, ArrayList ptsList)
        {
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            Brush br = new SolidBrush(Color.Red);
            Point p1 = (Point)ptsList[0];
            Point p1a = new Point(p1.X - 4, p1.Y - 4);
            Point p2a = new Point(p1.X + 4, p1.Y + 4);
            dc.DrawLine(new Pen(Color.FloralWhite, 2), p1a, p2a);
            Point p3a = new Point(p1.X + 4, p1.Y - 4);
            Point p4a = new Point(p1.X - 4, p1.Y + 4);
            dc.DrawLine(new Pen(Color.FloralWhite, 2), p3a, p4a);
            Point pstart = new Point(p1.X, p1.Y);


            Point p2;
            for (int i = 1; i < ptsList.Count; i++)
            {
                p2 = (Point)ptsList[i];
                p1a = new Point(p2.X - 4, p2.Y - 4);
                p2a = new Point(p2.X + 4, p2.Y + 4);
                dc.DrawLine(new Pen(Color.Red, 2), p1a, p2a);
                p3a = new Point(p2.X + 4, p2.Y - 4);
                p4a = new Point(p2.X - 4, p2.Y + 4);
                dc.DrawLine(new Pen(Color.Red, 2), p3a, p4a);

                dc.DrawLine(new Pen(Color.Blue, 1), p1, p2);
                //	dc.DrawString("x",new Font(FontFamily.GenericSansSerif,10),
                //		br,pt);
                p1 = p2;

            }
            dc.DrawLine(new Pen(Color.Blue, 1), p1, pstart); // back home
            return true;
        }


        public static bool DrawBestTour(Image img, ref Bitmap bm, ArrayList ptsList, int[] tour)
        {
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            Brush br = new SolidBrush(Color.Red);
            Point p1 = (Point)ptsList[0];
            Point p1a = new Point(p1.X - 4, p1.Y - 4);
            Point p2a = new Point(p1.X + 4, p1.Y + 4);
            dc.DrawLine(new Pen(Color.FloralWhite, 2), p1a, p2a);
            Point p3a = new Point(p1.X + 4, p1.Y - 4);
            Point p4a = new Point(p1.X - 4, p1.Y + 4);
            dc.DrawLine(new Pen(Color.FloralWhite, 2), p3a, p4a);
            Point pstart = new Point(p1.X, p1.Y);


            Point p2;
            for (int i = 1; i < ptsList.Count; i++)
            {
                p2 = (Point)ptsList[tour[i]];
                p1a = new Point(p2.X - 4, p2.Y - 4);
                p2a = new Point(p2.X + 4, p2.Y + 4);
                dc.DrawLine(new Pen(Color.Red, 2), p1a, p2a);
                p3a = new Point(p2.X + 4, p2.Y - 4);
                p4a = new Point(p2.X - 4, p2.Y + 4);
                dc.DrawLine(new Pen(Color.Red, 2), p3a, p4a);

                dc.DrawLine(new Pen(Color.Blue, 1), p1, p2);
                //	dc.DrawString("x",new Font(FontFamily.GenericSansSerif,10),
                //		br,pt);
                p1 = p2;

            }
            dc.DrawLine(new Pen(Color.Blue, 1), p1, pstart); // back home
            return true;
        }

        public static bool ResizeImage(Image img, ref Bitmap bm, Rectangle rect)
        {
            bm = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, rect);
            return true;
        }
    }
}
