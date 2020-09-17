//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace MyPaint
//{
//    public class Filters
//    {
//        private static Bitmap bmap;
//        private static Random rand = new Random();
//        public static void BWFilter(object sender, EventArgs e, PictureBox picturebox)
//        {
//            bmap = new Bitmap(picturebox.Image);
//            picturebox.Image = bmap;
//            Bitmap tmpbmp = new Bitmap(picturebox.Image);

//            int red, blue, green;
//            int DispX = 1;
//            int DispY = 1;

//            for (int i = 0; i < tmpbmp.Height - 1; i++)
//            {
//                for (int j = 0; j < tmpbmp.Width - 1; j++)
//                {
//                    Color pixel1 = tmpbmp.GetPixel(j, i);
//                    Color pixel2 = tmpbmp.GetPixel(j + DispX, i + DispY);
//                    red = Math.Min(Math.Abs(pixel1.R - pixel2.R) + 128, 255);
//                    green = Math.Min(Math.Abs(pixel1.G - pixel2.G) + 128, 255);
//                    blue = Math.Min(Math.Abs(pixel1.B - pixel2.B) + 128, 255);
//                    bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
//                }

//                if (i % 10 == 0)
//                {
//                    picturebox.Invalidate();
//                    picturebox.Refresh();
//                }
//            }

//            picturebox.Refresh();
//        }

//        public static void SharpFilter(object sender, EventArgs e, PictureBox pictureBox1)
//        {
//            bmap = new Bitmap(pictureBox1.Image);
//            pictureBox1.Image = bmap;
//            var tmpbmp = new Bitmap(pictureBox1.Image);

//            int DX = 1;
//            int DY = 1;
//            int red, green, blue;

//            for (int i = DX; i <= tmpbmp.Height - DX - 1; i++)
//            {
//                for (int j = DY; j <= tmpbmp.Width - DY - 1; j++)
//                {
//                    red = Convert.ToInt32((double)Convert.ToInt32(tmpbmp.GetPixel(j, i).R) 
//                        + 0.5 * (double)Convert.ToInt32(tmpbmp.GetPixel(j, i).R 
//                        - Convert.ToInt32(tmpbmp.GetPixel(j - DX, i - DY).R))); ;
//                    green = Convert.ToInt32((double)Convert.ToInt32(tmpbmp.GetPixel(j, i).G) 
//                        + 0.7 * (double)Convert.ToInt32(tmpbmp.GetPixel(j, i).G 
//                        - Convert.ToInt32(tmpbmp.GetPixel(j - DX, i - DY).G))); ;
//                    blue = Convert.ToInt32((double)Convert.ToInt32(tmpbmp.GetPixel(j, i).B) 
//                        + 0.5 * (double)Convert.ToInt32(tmpbmp.GetPixel(j, i).B 
//                        - Convert.ToInt32(tmpbmp.GetPixel(j - DX, i - DY).B))); ;
//                    red = Math.Min(Math.Max(red, 0), 255);
//                    green = Math.Min(Math.Max(green, 0), 255);
//                    blue = Math.Min(Math.Max(blue, 0), 255);
//                    bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
//                }
//                if (i % 10 == 0)
//                {
//                    pictureBox1.Invalidate();
//                    pictureBox1.Refresh();
//                }
//            }
//            pictureBox1.Refresh();
//        }

//        public static void BlurFilter(object sender, EventArgs e, PictureBox pictureBox1)
//        {
//            bmap = new Bitmap(pictureBox1.Image);
//            pictureBox1.Image = bmap;
//            var tempbmp = new Bitmap(pictureBox1.Image);
//            int DX = 1;
//            int DY = 1;
//            int red, green, blue;

//            int i, j;
//            {
//                var withBlock = tempbmp;
//                var loopTo = withBlock.Height - DX - 1;
//                for (i = DX; i <= loopTo; i++)
//                {
//                    var loopTo1 = withBlock.Width - DY - 1;
//                    for (j = DY; j <= loopTo1; j++)
//                    {
//                        red = Convert.ToInt32((double)(Convert.ToInt32(withBlock.GetPixel(j - 1, i - 1).R) 
//                            + Convert.ToInt32(withBlock.GetPixel(j - 1, i).R) 
//                            + Convert.ToInt32(withBlock.GetPixel(j - 1, i + 1).R) 
//                            + Convert.ToInt32(withBlock.GetPixel(j, i - 1).R) 
//                            + Convert.ToInt32(withBlock.GetPixel(j, i).R) 
//                            + Convert.ToInt32(withBlock.GetPixel(j, i + 1).R) 
//                            + Convert.ToInt32(withBlock.GetPixel(j + 1, i - 1).R) 
//                            + Convert.ToInt32(withBlock.GetPixel(j + 1, i).R) 
//                            + Convert.ToInt32(withBlock.GetPixel(j + 1, i + 1).R)) / (double)9);

//                        green = Convert.ToInt32((double)(Convert.ToInt32(withBlock.GetPixel(j - 1, i - 1).G) 
//                            + Convert.ToInt32(withBlock.GetPixel(j - 1, i).G) 
//                            + Convert.ToInt32(withBlock.GetPixel(j - 1, i + 1).G) 
//                            + Convert.ToInt32(withBlock.GetPixel(j, i - 1).G) 
//                            + Convert.ToInt32(withBlock.GetPixel(j, i).G) 
//                            + Convert.ToInt32(withBlock.GetPixel(j, i + 1).G) 
//                            + Convert.ToInt32(withBlock.GetPixel(j + 1, i - 1).G) 
//                            + Convert.ToInt32(withBlock.GetPixel(j + 1, i).G) 
//                            + Convert.ToInt32(withBlock.GetPixel(j + 1, i + 1).G)) / (double)9);

//                        blue = Convert.ToInt32((double)(Convert.ToInt32(withBlock.GetPixel(j - 1, i - 1).B) 
//                            + Convert.ToInt32(withBlock.GetPixel(j - 1, i).B) 
//                            + Convert.ToInt32(withBlock.GetPixel(j - 1, i + 1).B) 
//                            + Convert.ToInt32(withBlock.GetPixel(j, i - 1).B) 
//                            + Convert.ToInt32(withBlock.GetPixel(j, i).B)
//                            + Convert.ToInt32(withBlock.GetPixel(j, i + 1).B) 
//                            + Convert.ToInt32(withBlock.GetPixel(j + 1, i - 1).B) 
//                            + Convert.ToInt32(withBlock.GetPixel(j + 1, i).B) 
//                            + Convert.ToInt32(withBlock.GetPixel(j + 1, i + 1).B)) / (double)9);
//                        red = Math.Min(Math.Max(red, 0), 255);
//                        green = Math.Min(Math.Max(green, 0), 255);
//                        blue = Math.Min(Math.Max(blue, 0), 255);
//                        bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
//                    }
//                    if (i % 10 == 0)
//                    {
//                        pictureBox1.Invalidate();
//                        pictureBox1.Refresh();
//                    }
//                }
//            }
//            pictureBox1.Refresh();
//        }

//        public static void SprayFilter(object sender, EventArgs e, PictureBox pictureBox1)
//        {
//            bmap = new Bitmap(pictureBox1.Image);
//            pictureBox1.Image = bmap;
//            var tempbmp = new Bitmap(pictureBox1.Image);
//            int i;
//            int j;
//            int DX;
//            int DY;
//            int red;
//            int green;
//            int blue;
//            {
//                var withBlock = tempbmp;
//                var loopTo = withBlock.Height - 3;
//                for (i = 3; i <= loopTo; i++)
//                {
//                    var loopTo1 = withBlock.Width - 3;
//                    for (j = 3; j <= loopTo1; j++)
//                    {
//                        DX = Convert.ToInt32(rand.NextDouble() * 4 - 2);
//                        DY = Convert.ToInt32(rand.NextDouble() * 4 - 2);
//                        red = withBlock.GetPixel(j + DX, i + DY).R;
//                        green = withBlock.GetPixel(j + DX, i + DY).G;
//                        blue = withBlock.GetPixel(j + DX, i + DY).B;
//                        bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
//                    }
//                    if (i % 10 == 0)
//                    {
//                        pictureBox1.Invalidate();
//                        pictureBox1.Refresh();
//                    }
//                }
//            }
//            pictureBox1.Refresh();
//        }

//        public static void FlipYFilter(object sender, EventArgs e, PictureBox pictureBox1)
//        {
//            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
//            pictureBox1.Refresh();
//        }

//        public static void FlipXFilter(object sender, EventArgs e, PictureBox pictureBox1)
//        {
//            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
//            pictureBox1.Refresh();
//        }
//    }
//}
