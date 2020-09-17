using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyPaint
{
    public class RectangleTool : AllTools
    {
        public RectangleTool(PictureBox form) : base(form)
        {

        }

        public override void Draw(List<Coordinates> coor_list, Point pointA, Point pointB, Graphics grph)
        {
            Pen curPen = null;
            try
            {
                curPen = new Pen(AllTools.MainPict, (float)SelectedValue);
                curPen.DashStyle = (DashStyle)SelectedItem;

                if (!Canvas.can_write)
                    using (var graphics = Graphics.FromImage(form.Image))
                    {
                        foreach (Coordinates cr in coor_list)
                        {

                            graphics.DrawRectangle(curPen, cr.pointA.X, cr.pointA.Y, cr.pointB.X, cr.pointB.Y);

                        }

                        //graphics.DrawRectangle(curPen, pointA.X, pointA.Y, pointB.X, pointB.Y);
                    }
                else
                {

                    foreach (Coordinates cr in coor_list)
                    {

                        grph.DrawRectangle(curPen, cr.pointA.X, cr.pointB.Y, cr.pointA.X, cr.pointB.Y);

                    }

                    grph.DrawRectangle(curPen, pointA.X, pointA.Y, pointB.X, pointB.Y);

                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                curPen.Dispose();
            }
        }
    }
}
