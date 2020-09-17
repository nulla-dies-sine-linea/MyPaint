using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyPaint
{
    public class PipTool : AllTools
    {
        public PipTool(PictureBox form) : base(form)
        {
        }

        public override void Draw(List<Coordinates> coor_list, Point pointA, Point pointB, Graphics grph)
        {
            try
            {
                var color = (form.Image as Bitmap).GetPixel(pointA.X, pointB.Y);
                MainPict = color;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
