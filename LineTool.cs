using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyPaint
{
    public class LineTool : AllTools
    {

        public LineTool(PictureBox form) : base(form)
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

                            graphics.DrawLine(curPen, cr.pointA, cr.pointB);

                        }

                        graphics.DrawLine(curPen, pointA, pointB);
                    }

                else
                {

                    foreach (Coordinates cr in coor_list)
                    {

                        grph.DrawLine(curPen, cr.pointA, cr.pointB);

                    }

                    grph.DrawLine(curPen, pointA, pointB);

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