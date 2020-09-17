using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyPaint
{
    public class StarTool : AllTools
    {
        public static int vertex;
        public StarTool(int vertexNumber, PictureBox form) : base(form)
        {
            vertex = vertexNumber;
        }

        public override void Draw(List<Coordinates> coor_list, Point pointA, Point pointB, Graphics grph)
        {
            Pen curPen = null;

            double r = 25, R = 50;
            double alpha = 0;

            curPen = new Pen(AllTools.MainPict, (float)SelectedValue);

            curPen.DashStyle = (DashStyle)SelectedItem;

            PointF[] points = new PointF[2 * vertex + 1];
            double a = alpha, da = Math.PI / vertex, l;

            for (int k = 0; k < 2 * vertex + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(pointA.X + l * Math.Cos(a)), (float)(pointA.Y + l * Math.Sin(a)));
                a += da;
            }

            try
            {
                if (!Canvas.can_write)
                    using (var graphics = Graphics.FromImage(form.Image))
                    {
                        foreach (Coordinates cr in coor_list)
                        {
                            graphics.DrawLines(curPen, points);
                        }
                        graphics.DrawLines(curPen, points);
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
