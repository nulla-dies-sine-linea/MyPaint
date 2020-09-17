using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyPaint
{
    public class PencilTool : AllTools
    {

        public PencilTool(PictureBox form) : base(form)
        {

        }

        public override void Draw(List<Coordinates> coor_list, Point pointA, Point pointB, Graphics grph)
        {
            Pen curPen = null;

            try
            {
                curPen = new Pen(AllTools.MainPict, (float)SelectedValue);
                curPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                curPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                curPen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
                curPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

                using (var graphics = Graphics.FromImage(form.Image))
                {
                    curPen.DashStyle = (DashStyle)SelectedItem;
                    graphics.DrawLine(curPen, pointA, pointB);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                curPen.Dispose();
            }

        }



    }
}
