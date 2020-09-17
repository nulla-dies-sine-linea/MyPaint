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
    public partial class CanvasSize : Form
    {
        public CanvasSize(int width, int height)
        {
            InitializeComponent();
            CanvasWidth.Value = width;
            CanvasHeight.Value = height;
        }

        public int SizeHeight 
        {
            get
            {

                return (int)CanvasHeight.Value;
            }
            set 
            {
            }
        }
        public int SizeWidth 
        {
            get
            {

                return (int)CanvasWidth.Value;
            }
            set
            {
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            SizeHeight = (int)CanvasHeight.Value;
            SizeWidth = (int)CanvasWidth.Value;
        }
    }
}
