using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyPaint
{
    public class EraseTool : AllTools
    {
        public EraseTool(PictureBox form) : base(form)
        {

        }

        public override void Draw(List<Coordinates> coor_list, Point pointA, Point pointB, Graphics grph)
        {
            Pen curPen = new Pen(Color.White, (float)SelectedValue);
            curPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            curPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            curPen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            curPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

            using (var graphics = Graphics.FromImage(form.Image))
            {

                graphics.DrawLine(curPen, pointA, pointB);

            }

            curPen.Dispose();
        }
    }
}
