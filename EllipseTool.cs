using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyPaint
{
    public class EllipseTool : AllTools
    {
        public EllipseTool(PictureBox form) : base(form)
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

                            graphics.DrawEllipse(curPen, cr.pointA.X, cr.pointA.Y, cr.pointB.X, cr.pointB.Y);


                        }

                        //graphics.DrawEllipse(curPen, pointA.X, pointB.Y, pointB.X, pointB.Y);
                    }
                else
                {

                    foreach (Coordinates cr in coor_list)
                    {

                        grph.DrawEllipse(curPen, cr.pointA.X, cr.pointA.Y, cr.pointB.X, cr.pointB.Y);

                    }

                    grph.DrawEllipse(curPen, pointA.X, pointA.Y, pointB.X, pointB.Y);

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
