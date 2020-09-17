using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    public abstract class AllTools
    {
        protected PictureBox form;
        protected ToolStrip toolBar;
        public static object SelectedItem { get; set; }
        public static int SelectedValue { get; set; }
        public static MouseButtons mouseDown = MouseButtons.None;
        //public static Color mainColor { get; set; }
        //public static Color backColor { get; set; }
        public static Color MainPict { get; set; }
        //public static Color AnotherPict { get; set; }
        //public static string SelectedFont = "Arial";
        //public static string strText { get; set; }
        //public static string strTextPrev { get; set; }
        //public static bool ShiftKey { get; set; }


        public AllTools(PictureBox form)
        {

            this.form = form;
        }

        public abstract void Draw(List<Coordinates> coor_list, Point pointA, Point pointB, Graphics e = null);
    }
}
