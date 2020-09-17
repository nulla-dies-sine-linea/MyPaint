using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        void Transform(PictureBox pictureBox1);
    }
}
