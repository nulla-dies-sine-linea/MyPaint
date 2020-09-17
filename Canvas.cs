using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public struct Coordinates
    {
        public Point pointA;
        public Point pointB;
        public Coordinates(Point pointA, Point pointB)
        {

            this.pointA = pointA;
            this.pointB = pointB;
        }
    }
    public partial class Canvas : Form
    {
        private Bitmap image;
        public AllTools tool { get; set; }

        private Point startpoint;
        private Point endpoint;
        public bool Saved { get; set; } 
        public static bool can_write = false;
        private List<Coordinates> coor_list;
        private string str = string.Empty;
        private Caret caret = new Caret();

        public Canvas()
        {
            InitializeComponent();
        }
        public Image curimage
        {

            get
            {
                return pictureBox.Image;
            }
            set
            {
                pictureBox.Image = value;
            }
        }
        
        private void Canvas_Load(object sender, EventArgs e)
        {
            coor_list = new List<Coordinates>();
            image = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (var graphics = Graphics.FromImage(image))
            {

                graphics.Clear(Color.White);
            }
            Saved = false;
            pictureBox.Image = image;
        }
        private void pictureBox_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (caret.Visible)
                caret.Hide();

            if (e.Button == MouseButtons.Left)
            {
                coor_list.Clear();
                can_write = true;
                startpoint = e.Location;
                pictureBox.Paint += OnPaint;

            }

            if (tool is PipTool)
            {

                AllTools.mouseDown = e.Button;
                startpoint = e.Location;
                tool.Draw(coor_list, startpoint, endpoint);
            }
        }

        private void pictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (tool is LineTool || tool is RectangleTool || tool is EllipseTool)
            {

                if (can_write)
                {

                    endpoint = e.Location;
                    //tool.Draw(m_list, startpoint, endpoint);
                    pictureBox.Invalidate();
                }

            }
            else if (!(tool is PipTool))
            {
                if (can_write)
                {
                    endpoint = e.Location;
                    try
                    {
                        tool.Draw(coor_list, startpoint, endpoint);
                        startpoint = e.Location;
                    }
                    catch
                    {

                    }
                    pictureBox.Invalidate();
                }
            }
        }

        private void pictureBox_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (!(tool is PipTool))
            {
                try
                {
                    pictureBox.Paint -= OnPaint;
                    can_write = false;
                    coor_list.Add(new Coordinates(startpoint, endpoint));
                    tool.Draw(coor_list, startpoint, endpoint);
                    pictureBox.Invalidate();
                }
                catch
                {

                }
            }
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            try
            {
                tool.Draw(coor_list, startpoint, endpoint, e.Graphics);
            }
            catch
            {

            }
        }

        private void pictureBox_Click_1(object sender, EventArgs e)
        {

        }
    }
}
