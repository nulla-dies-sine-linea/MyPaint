using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Configuration;

namespace MyPaint
{
    public partial class Paint : Form
    {
        private Canvas curCanva;
        private ComboBox lineStylesComboBox = new ComboBox();
        private StringDictionary filenames;
        private String Filter = @"All files (*.*)|*.*| File jpg (*.jpg)|*.jpg| File bmp (*.bmp)|*.bmp| File gif (*.gif)|*.gif| File png (*.png)|*.png";
        private AllTools tool;
        private object[] arraylines;
        private Timer timer;
        Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();

        #region Draw main form
        public Paint()
        {
            InitializeComponent();
        }
        private void Paint_Load(object sender, EventArgs e)
        {
            filenames = new StringDictionary();
            arraylines = new object[] { 0, 1, 2, 3, 4 };

            VertexNumber.Text = "5";

            lineStylesComboBox.Size = new System.Drawing.Size(55, 30);
            lineStylesComboBox.Margin = new System.Windows.Forms.Padding(0, 2, 5, 4); 
            lineStylesComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            lineStylesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            lineStylesComboBox.FormattingEnabled = true;
            lineStylesComboBox.DrawItem += OnDrawItem;
            lineStylesComboBox.SelectedIndexChanged += OnSelectChange;
            lineStylesComboBox.Items.AddRange(arraylines);
            lineStylesComboBox.SelectedIndex = 0;

            ToolStripControlHost combo = new ToolStripControlHost(lineStylesComboBox);
            toolStrip.Items.Add(combo);
            toolStrip.Items.Add(new ToolStripSeparator());

            Label l = new Label();
            l.Text = "Размер кисти: ";
            l.TextAlign = ContentAlignment.MiddleCenter;
            ToolStripControlHost t = new ToolStripControlHost(l);
            toolStrip.Items.Add(t);

            NumericUpDown penSize = new NumericUpDown();
            penSize.Size = new System.Drawing.Size(55, 35);
            penSize.Padding = new System.Windows.Forms.Padding(0, 2, 6, 4);
            penSize.ValueChanged += OnValueChanged;
            penSize.Minimum = 1;
            ToolStripControlHost m_toolhost = new ToolStripControlHost(penSize);
            toolStrip.Items.Add(m_toolhost);

            curCanva = new Canvas();
            curCanva.MdiParent = this;
            curCanva.Show();
            curCanva.Name = "1New";
            curCanva.Location = new Point(0, 0);
            WindowsButton.DropDownItems[0].Text = "1 Новый";
            WindowsButton.DropDownItems[0].Name = "1New";
            (WindowsButton.DropDownItems[0] as ToolStripMenuItem).Checked = true;
            filenames.Add(curCanva.Name, "New");
            WindowsButton.DropDownItemClicked += WinDropDownItemClick;

            AllTools.MainPict = Color.Black;

            tool = new PencilTool(curCanva.Controls[0] as PictureBox);
            curCanva.tool = tool;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += OnTimer;

            this.LayoutMdi(MdiLayout.TileHorizontal);

            FindPlugins();
            CreatePluginsMenu();
        }
        
        private void CreatePluginsMenu()
        {
            //FilterButton.DropDownItems.Clear();
            foreach (var plugin in plugins)
            {
                FilterButton.DropDownItems.Add(plugin.Key);
            }           
        }

        private void FindPlugins()
        {
            try
            {
                string value = ConfigurationManager.AppSettings["plugin"];
                string[] fileNames = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string folder = System.AppDomain.CurrentDomain.BaseDirectory;

                string info = "Список загруженных плагинов:\n\n";

                foreach (string fileName in fileNames)
                {
                    try
                    {
                        string file = $"{folder}{fileName}.dll";

                        Assembly assembly = Assembly.LoadFile(file);

                        foreach (Type type in assembly.GetTypes())
                        {
                            Type iface = type.GetInterface("MyPaint.IPlugin");
                            string v = "неуказана";
                            
                            if (iface != null)
                            {
                                MyPaint.VersionAttribute version = (VersionAttribute)type.GetCustomAttributes(false).FirstOrDefault();

                                if (version != null)
                                {
                                    v = version.Major.ToString() + "," + version.Minor.ToString();
                                }

                                IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                                plugins.Add(plugin.Name, plugin);
                                info += $"Название: {plugin.Name}\n";
                                info += $"Автор: {plugin.Author}\n";
                                info += $"Версия: {v}\n\n";
                            }
                        }

                        MessageBox.Show(info);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки плагина:\n" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                string folder = System.AppDomain.CurrentDomain.BaseDirectory;
                string[] files = Directory.GetFiles(folder, "*.dll");

                foreach (string file in files)
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(file);

                        foreach (Type type in assembly.GetTypes())
                        {
                            Type iface = type.GetInterface("MyPaint.IPlugin");

                            if (iface != null)
                            {
                                IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                                plugins.Add(plugin.Name, plugin);
                            }
                        }
                    }
                    catch (Exception exс)
                    {
                        MessageBox.Show("Ошибка загрузки плагина:\n" + exс.Message);
                    }

                //MessageBox.Show("Rонфигурационный файл отсутствует " +
                //    "или в нем установлен автоматический режим. " +
                //    "Загружены все планы из директории приложения");
            }
        }

        protected void OnDrawItem(object sender, DrawItemEventArgs e)
        {

            e.DrawBackground();

            using (var pen = new Pen(e.ForeColor, 2.0f))
            {

                pen.DashStyle = (DashStyle)e.Index;
                int y = (e.Bounds.Top + e.Bounds.Bottom) / 2;
                e.Graphics.DrawLine(pen, e.Bounds.Left, y, e.Bounds.Right, y);
            }

            e.DrawFocusRectangle();
        }

        #endregion Draw main form

        #region Main functions

        private void CreateNew_Click(object sender, EventArgs e)
        {
            Canvas canva = new Canvas();
            canva.MdiParent = this;
            canva.Show();
            canva.Name = MdiChildren.Length + "New";

            for (int i = 0; i < WindowsButton.DropDownItems.Count; i++)
            {
                (WindowsButton.DropDownItems[i] as ToolStripMenuItem).Checked = false;
            }

            (WindowsButton.DropDownItems[WindowsButton.DropDownItems.Count - 1] as ToolStripMenuItem).Name = canva.Name;
            (WindowsButton.DropDownItems[WindowsButton.DropDownItems.Count - 1] as ToolStripMenuItem).Checked = true;
            filenames.Add(canva.Name, "New");
            lineStylesComboBox.SelectedItem = 0;

            //LayoutMdi(MdiLayout.Cascade);
            //LayoutMdi(MdiLayout.ArrangeIcons);
            //LayoutMdi(MdiLayout.TileHorizontal);
            //LayoutMdi(MdiLayout.TileVertical)
        }
        private void Open_Click(object sender, EventArgs e)
        {
            var m_OpenFileDialog = new OpenFileDialog();

            m_OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            m_OpenFileDialog.Filter = Filter;

            if (m_OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                var filename = m_OpenFileDialog.FileName;
                var bitmap = new Bitmap(filename);

                if ((ActiveMdiChild as Canvas).curimage != null)
                {
                    (ActiveMdiChild as Canvas).curimage.Dispose();
                }

                (ActiveMdiChild as Canvas).curimage = bitmap;
                filenames[ActiveMdiChild.Name] = filename;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (filenames[ActiveMdiChild.Name] == "New")
            {
                var m_SaveFileDialog = new SaveFileDialog();
                m_SaveFileDialog.Filter = @"*.bmp|*.bmp|*.jpg|*.jpg|*.png|*.png|*.gif|*.gif";
                m_SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                if (m_SaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    string filename = m_SaveFileDialog.FileName;

                    if ((ActiveMdiChild as Canvas).curimage != null)
                    {
                        (ActiveMdiChild as Canvas).curimage.Save(filename);
                        (ActiveMdiChild as Canvas).Saved = true;
                    }

                    filenames[ActiveMdiChild.Name] = filename;
                }
            }
            else
            {
                (ActiveMdiChild as Canvas).curimage.Save(filenames[ActiveMdiChild.Name]);
                (ActiveMdiChild as Canvas).Saved = true;
            }
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            var m_SaveFileDialog = new SaveFileDialog();
            m_SaveFileDialog.Filter = @"*.bmp|*.bmp|*.jpg|*.jpg|*.png|*.png|*.gif|*.gif";
            m_SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (m_SaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string filename = m_SaveFileDialog.FileName;

                if ((ActiveMdiChild as Canvas).curimage != null)
                {
                    (ActiveMdiChild as Canvas).curimage.Save(filename);
                    (ActiveMdiChild as Canvas).Saved = true;
                }

                filenames[ActiveMdiChild.Name] = filename;
            }
        }
        private void CloseCanva_Click(object sender, EventArgs e)
        {
            if ((ActiveMdiChild as Canvas).Saved == false)
            {
                DialogResult result = MessageBox.Show($"Вы хотите сохранить изменения в файле {(ActiveMdiChild as Canvas).Name}?",
                    "My Paint", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    var m_SaveFileDialog = new SaveFileDialog();
                    m_SaveFileDialog.Filter = @"*.bmp|*.bmp|*.jpg|*.jpg|*.png|*.png|*.gif|*.gif";
                    m_SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    if (m_SaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        string filename = m_SaveFileDialog.FileName;

                        if ((ActiveMdiChild as Canvas).curimage != null)
                        {
                            (ActiveMdiChild as Canvas).curimage.Save(filename);
                            (ActiveMdiChild as Canvas).Saved = true;
                        }

                        filenames[ActiveMdiChild.Name] = filename;
                    }

                    for (int i = 0; i < WindowsButton.DropDownItems.Count; i++)
                    {

                        if (WindowsButton.DropDownItems[i].Name == ActiveMdiChild.Name)
                            WindowsButton.DropDownItems[i].Dispose();
                    }
                    if (filenames.ContainsKey(ActiveMdiChild.Name))
                        filenames.Remove(ActiveMdiChild.Name);
                    ActiveMdiChild.Close();
                }
            }
            else
            {
                for (int i = 0; i < WindowsButton.DropDownItems.Count; i++)
                {

                    if (WindowsButton.DropDownItems[i].Name == ActiveMdiChild.Name)
                        WindowsButton.DropDownItems[i].Dispose();
                }
                if (filenames.ContainsKey(ActiveMdiChild.Name))
                    filenames.Remove(ActiveMdiChild.Name);
                ActiveMdiChild.Close();
            }
            
        }
        private void ChangeSizeButton_Click(object sender, EventArgs e)
        {
            CanvasSize form = new CanvasSize(ActiveMdiChild.Size.Width, ActiveMdiChild.Size.Height);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                ActiveMdiChild.Size = new Size(form.SizeWidth, form.SizeHeight);
                (ActiveMdiChild.Controls[0] as PictureBox).Size = new Size(form.SizeWidth, form.SizeHeight);
                Bitmap image = new Bitmap(form.SizeWidth, form.SizeHeight);
                using (var graphics = Graphics.FromImage(image))
                {
                    graphics.Clear(Color.White);
                    //graphics.DrawImage((ActiveMdiChild.Controls[0] as PictureBox).Image, 
                    //    new Rectangle(new Point(0, 0), new Size((ActiveMdiChild.Controls[0] as PictureBox).Image.Width,
                    //    (ActiveMdiChild.Controls[0] as PictureBox).Image.Height)));
                }
                (ActiveMdiChild.Controls[0] as PictureBox).Image = image;
            }
        }

        private void Paint_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < filenames.Count; i++)
            {
                if ((ActiveMdiChild as Canvas).Saved == false)
                {
                    DialogResult result = MessageBox.Show($"Вы хотите сохранить изменения в файле {(ActiveMdiChild as Canvas).Name}?",
                       "My Paint", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        var m_SaveFileDialog = new SaveFileDialog();
                        m_SaveFileDialog.Filter = @"*.bmp|*.bmp|*.jpg|*.jpg|*.png|*.png|*.gif|*.gif";
                        m_SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                        if (m_SaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {

                            string filename = m_SaveFileDialog.FileName;

                            if ((ActiveMdiChild as Canvas).curimage != null)
                            {
                                (ActiveMdiChild as Canvas).curimage.Save(filename);
                                (ActiveMdiChild as Canvas).Saved = true;
                            }

                            filenames[ActiveMdiChild.Name] = filename;
                        }

                        for (int j = 0; j < WindowsButton.DropDownItems.Count; j++)
                        {

                            if (WindowsButton.DropDownItems[j].Name == ActiveMdiChild.Name)
                                WindowsButton.DropDownItems[j].Dispose();
                        }
                        if (filenames.ContainsKey(ActiveMdiChild.Name))
                            filenames.Remove(ActiveMdiChild.Name);
                        ActiveMdiChild.Close();
                    }
                    else
                    {
                        for (int j = 0; j < WindowsButton.DropDownItems.Count; j++)
                        {

                            if (WindowsButton.DropDownItems[j].Name == ActiveMdiChild.Name)
                                WindowsButton.DropDownItems[j].Dispose();
                        }
                        if (filenames.ContainsKey(ActiveMdiChild.Name))
                            filenames.Remove(ActiveMdiChild.Name);
                        ActiveMdiChild.Close();
                    }
                }
                else
                {
                    for (int j = 0; j < WindowsButton.DropDownItems.Count; j++)
                    {

                        if (WindowsButton.DropDownItems[j].Name == ActiveMdiChild.Name)
                            WindowsButton.DropDownItems[j].Dispose();
                    }
                    if (filenames.ContainsKey(ActiveMdiChild.Name))
                        filenames.Remove(ActiveMdiChild.Name);
                    ActiveMdiChild.Close();
                }
            }
        }

        private void About_Click(object sender, EventArgs e)
        {
            AboutPaint frmAbout = new AboutPaint();
            frmAbout.ShowDialog();
        }

        #endregion Main functions

        #region Tools
        private void PencilButton_Click(object sender, EventArgs e)
        {
            try
            {
                tool = new PencilTool((ActiveMdiChild as Canvas).Controls[0] as PictureBox);
                (ActiveMdiChild as Canvas).tool = tool;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void EraserButton_Click(object sender, EventArgs e)
        {
            try
            {
                tool = new EraseTool((ActiveMdiChild as Canvas).Controls[0] as PictureBox);
                (ActiveMdiChild as Canvas).tool = tool;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void LineButton_Click(object sender, EventArgs e)
        {
            try
            {
                tool = new LineTool((ActiveMdiChild as Canvas).Controls[0] as PictureBox);
                (ActiveMdiChild as Canvas).tool = tool;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                tool = new ClearTool((ActiveMdiChild as Canvas).Controls[0] as PictureBox);
                (ActiveMdiChild as Canvas).tool = tool;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void PalleteButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            using (var graphics = Graphics.FromImage((ActiveMdiChild.Controls[0] as PictureBox).Image))
            {
                AllTools.MainPict = colorDialog.Color;
            }
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            try
            {
                tool = new EllipseTool((ActiveMdiChild as Canvas).Controls[0] as PictureBox);
                (ActiveMdiChild as Canvas).tool = tool;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void RectangleButton_Click(object sender, EventArgs e)
        {
            try
            {
                tool = new RectangleTool((ActiveMdiChild as Canvas).Controls[0] as PictureBox);
                (ActiveMdiChild as Canvas).tool = tool;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void PipButton_Click(object sender, EventArgs e)
        {
            try
            {
                tool = new PipTool((ActiveMdiChild as Canvas).Controls[0] as PictureBox);
                (ActiveMdiChild as Canvas).tool = tool;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        #endregion Tools

        #region Behaviors

        protected void OnSelectChange(object sender, EventArgs e)
        {

            var item = (sender as ComboBox).SelectedItem;
            AllTools.SelectedItem = item;

        }
        protected void OnValueChanged(object sender, EventArgs e)
        {
            var item = (sender as NumericUpDown).Value;
            AllTools.SelectedValue = (int)item;
        }
        protected void WinDropDownItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            for (int i = 0; i < WindowsButton.DropDownItems.Count; i++)
            {
                (WindowsButton.DropDownItems[i] as ToolStripMenuItem).Name = (i+1).ToString() + "New";
            }

            var item = (e.ClickedItem as ToolStripMenuItem).Checked;

            if (item != true)
                (e.ClickedItem as ToolStripMenuItem).Checked = true;

            for (int j = 0; j < MdiChildren.Length; j++)
            {

                if (MdiChildren[j].Name == e.ClickedItem.Name) MdiChildren[j].Activate();
                    
            }
        }

        private void CascadeButton_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileHorizontalButton_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void TileVerticalButton_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void ArrangeIcons_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void OnTimer(Object sender, EventArgs e)
        {

            //if (AllTools.mouseDown == System.Windows.Forms.MouseButtons.Left)
            //{
            //    using (var graphics = Graphics.FromImage((ActiveMdiChild.Controls[0] as PictureBox).Image))
            //    {

            //        graphics.Clear(AllTools.mainColor);
            //        AllTools.MainPict = AllTools.mainColor;
            //    }
            //}
            //else if (AllTools.mouseDown == System.Windows.Forms.MouseButtons.Right)
            //{
            //    using (var graphics = Graphics.FromImage((ActiveMdiChild.Controls[0] as PictureBox).Image))
            //    {
            //        graphics.Clear(AllTools.backColor);
            //        AllTools.AnotherPict = AllTools.backColor;
            //    }
            //}
        }
        private void PictureButton_Click(object sender, EventArgs e)
        {
            ChangeSizeButton.Enabled = !(ActiveMdiChild == null);
        }
        private void StarButton_Click(object sender, EventArgs e)
        {
            try
            {
                tool = new StarTool(Int32.Parse(VertexNumber.Text), (ActiveMdiChild as Canvas).Controls[0] as PictureBox);
                (ActiveMdiChild as Canvas).tool = tool;
            }
            catch (Exception)
            {
                MessageBox.Show("Количество вершин звезды должно быть" +
                    " в пределах от 3 до 1000", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void VertexNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        //private void BWButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Filters.BWFilter(sender, e, (ActiveMdiChild.Controls[0] as PictureBox));
        //        curCanva.curimage = (ActiveMdiChild.Controls[0] as PictureBox).Image;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //}

        //private void SharpnessButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Filters.SharpFilter(sender, e, (ActiveMdiChild.Controls[0] as PictureBox));
        //        curCanva.curimage = (ActiveMdiChild.Controls[0] as PictureBox).Image;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //}

        //private void BlurButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Filters.BlurFilter(sender, e, (ActiveMdiChild.Controls[0] as PictureBox));
        //        curCanva.curimage = (ActiveMdiChild.Controls[0] as PictureBox).Image;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //}

        //private void SprayButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Filters.SprayFilter(sender, e, (ActiveMdiChild.Controls[0] as PictureBox));
        //        curCanva.curimage = (ActiveMdiChild.Controls[0] as PictureBox).Image;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //}

        //private void FlipYButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Filters.FlipYFilter(sender, e, (ActiveMdiChild.Controls[0] as PictureBox));
        //        curCanva.curimage = (ActiveMdiChild.Controls[0] as PictureBox).Image;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //}

        //private void FlipXButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Filters.FlipXFilter(sender, e, (ActiveMdiChild.Controls[0] as PictureBox));
        //        curCanva.curimage = (ActiveMdiChild.Controls[0] as PictureBox).Image;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //}

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            Image myBitmap = (ActiveMdiChild.Controls[0] as PictureBox).Image;

            (ActiveMdiChild.Controls[0] as PictureBox).Size = new Size(myBitmap.Width, myBitmap.Height);
            Size nSize = new Size((int)((ActiveMdiChild.Controls[0] as PictureBox).Image.Width * 1.1),
                (int)((ActiveMdiChild.Controls[0] as PictureBox).Image.Height * 1.1));

            Image gdi = new Bitmap(nSize.Width, nSize.Height);
            Graphics ZoomInGraphics = Graphics.FromImage(gdi);
            ZoomInGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            ZoomInGraphics.DrawImage((ActiveMdiChild.Controls[0] as PictureBox).Image,
                new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0),
                (ActiveMdiChild.Controls[0] as PictureBox).Image.Size), GraphicsUnit.Pixel);
            ZoomInGraphics.Dispose();

            ActiveMdiChild.Size = new Size((int)((ActiveMdiChild.Controls[0] as PictureBox).Image.Width * 0.9),
                (int)((ActiveMdiChild.Controls[0] as PictureBox).Image.Height * 0.9));
            (ActiveMdiChild.Controls[0] as PictureBox).Image = gdi;
            (ActiveMdiChild.Controls[0] as PictureBox).Size = gdi.Size;
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            Image myBitmap = (ActiveMdiChild.Controls[0] as PictureBox).Image;

            (ActiveMdiChild.Controls[0] as PictureBox).Size = new Size(myBitmap.Width, myBitmap.Height);
            Size nSize = new Size((int)((ActiveMdiChild.Controls[0] as PictureBox).Image.Width * 0.9),
                (int)((ActiveMdiChild.Controls[0] as PictureBox).Image.Height * 0.9));

            Image gdi = new Bitmap(nSize.Width, nSize.Height);
            Graphics ZoomInGraphics = Graphics.FromImage(gdi);
            ZoomInGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            ZoomInGraphics.DrawImage((ActiveMdiChild.Controls[0] as PictureBox).Image,
                new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0),
                (ActiveMdiChild.Controls[0] as PictureBox).Image.Size), GraphicsUnit.Pixel);
            ZoomInGraphics.Dispose();

            ActiveMdiChild.Size = new Size((int)((ActiveMdiChild.Controls[0] as PictureBox).Image.Width * 0.9),
                (int)((ActiveMdiChild.Controls[0] as PictureBox).Image.Height * 0.9));
            (ActiveMdiChild.Controls[0] as PictureBox).Image = gdi;
            (ActiveMdiChild.Controls[0] as PictureBox).Size = gdi.Size;
        }

        private void FilterButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            IPlugin plugin = plugins[e.ClickedItem.Text];
            plugin.Transform(ActiveMdiChild.Controls[0] as PictureBox);
            curCanva.curimage = (ActiveMdiChild.Controls[0] as PictureBox).Image;
        }

        #endregion Behaviors
    }
}
