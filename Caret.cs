using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyPaint
{
    public class Caret
    {
        [DllImport("user32.dll")]
        public static extern int CreateCaret(IntPtr hwnd, IntPtr m_Bitmap, int nWidth, int nHeight);
        [DllImport("user32.dll")]
        public static extern int DestroyCaret();
        [DllImport("user32.dll")]
        public static extern int SetCaretPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern int ShowCaret(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern int HideCaret(IntPtr hwnd);

        //[StructLayout(LayoutKind.Sequential)]
        //public struct Point { 
        //                 public int x;
        //                 public int y;
        //                     }
        //[DllImport("user32.dll")]
        //public static extern int GetCaretPos(ref Point coordCaret);

        private Control ctrl;
        private Size size;
        private Point ptPoint;
        private bool bVisible;

        public Caret()
        {

        }

        public Caret(Control ctrl, Point point, int height)
        {
            this.ctrl = ctrl;
            Position = point;
            m_Size = new Size(1, height);
            Control.GotFocus += OnGotFocusControl;
            Control.LostFocus += OnLostFocusControl;

            if (Control.Focused)
                OnGotFocusControl(Control, new EventArgs());
        }
        public Control Control
        {

            get
            {

                return this.ctrl;
            }
            set
            {

                this.ctrl = value;
            }
        }
        public Size m_Size
        {

            get
            {

                return this.size;
            }
            set
            {

                this.size = value;
            }
        }
        public Point Position
        {

            get
            {

                return this.ptPoint;
            }
            set
            {

                this.ptPoint = value;
                SetCaretPos(ptPoint.X, ptPoint.Y);
            }
        }
        public bool Visible
        {

            get
            {

                return this.bVisible;
            }
            set
            {

                if (this.bVisible = value)
                    ShowCaret(Control.Handle);
                else
                    HideCaret(Control.Handle);

            }
        }
        public void Show()
        {

            Visible = true;
        }
        public void Hide()
        {
            Visible = false;
        }
        public void Dispose()
        {

            if (Control.Focused)
                OnLostFocusControl(Control, new EventArgs());

            Control.GotFocus -= OnGotFocusControl;
            Control.LostFocus -= OnLostFocusControl;
        }
        protected void OnGotFocusControl(object sender, EventArgs e)
        {

            CreateCaret(Control.Handle, IntPtr.Zero, m_Size.Width, m_Size.Height);
            SetCaretPos(Position.X, Position.Y);
            Show();
        }
        protected void OnLostFocusControl(object sender, EventArgs e)
        {

            Hide();
            DestroyCaret();
        }

    }
}

