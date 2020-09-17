using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MyPaint
{
    public class ClearTool : AllTools
    {
        public ClearTool(PictureBox form) : base(form)
        {

        }

        public override void Draw(List<Coordinates> coor_list, Point point1, Point point2, Graphics e)
        {
            try
            {
                using (var graphics = Graphics.FromImage(form.Image))
                {

                    graphics.Clear(Color.White);
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
