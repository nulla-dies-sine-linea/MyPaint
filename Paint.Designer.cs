namespace MyPaint
{
    partial class Paint
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateNew = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseCanva = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeSizeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.расположениеРисунковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CascadeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.TileHorizontalButton = new System.Windows.Forms.ToolStripMenuItem();
            this.TileVerticalButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterButton = new System.Windows.Forms.ToolStripMenuItem();
            this.QButton = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.ZoomInButton = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.PalleteButton = new System.Windows.Forms.ToolStripButton();
            this.PipButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearButton = new System.Windows.Forms.ToolStripButton();
            this.EraserButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PencilButton = new System.Windows.Forms.ToolStripButton();
            this.LineButton = new System.Windows.Forms.ToolStripButton();
            this.EllipseButton = new System.Windows.Forms.ToolStripButton();
            this.RectangleButton = new System.Windows.Forms.ToolStripButton();
            this.StarButton = new System.Windows.Forms.ToolStripButton();
            this.StarLabel = new System.Windows.Forms.ToolStripLabel();
            this.VertexNumber = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.StyleLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.красныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.синийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зелёныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.другойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileButton,
            this.PictureButton,
            this.WindowsButton,
            this.FilterButton,
            this.QButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.WindowsButton;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1017, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileButton
            // 
            this.FileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNew,
            this.Open,
            this.Save,
            this.SaveAs,
            this.CloseCanva});
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(59, 24);
            this.FileButton.Text = "Файл";
            // 
            // CreateNew
            // 
            this.CreateNew.Name = "CreateNew";
            this.CreateNew.Size = new System.Drawing.Size(201, 26);
            this.CreateNew.Text = "Новый";
            this.CreateNew.Click += new System.EventHandler(this.CreateNew_Click);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(201, 26);
            this.Open.Text = "Открыть...";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(201, 26);
            this.Save.Text = "Сохранить";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(201, 26);
            this.SaveAs.Text = "Сохранить как...";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // CloseCanva
            // 
            this.CloseCanva.Name = "CloseCanva";
            this.CloseCanva.Size = new System.Drawing.Size(201, 26);
            this.CloseCanva.Text = "Удалить";
            this.CloseCanva.Click += new System.EventHandler(this.CloseCanva_Click);
            // 
            // PictureButton
            // 
            this.PictureButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeSizeButton,
            this.расположениеРисунковToolStripMenuItem});
            this.PictureButton.Name = "PictureButton";
            this.PictureButton.Size = new System.Drawing.Size(79, 24);
            this.PictureButton.Text = "Рисунок";
            // 
            // ChangeSizeButton
            // 
            this.ChangeSizeButton.Name = "ChangeSizeButton";
            this.ChangeSizeButton.Size = new System.Drawing.Size(264, 26);
            this.ChangeSizeButton.Text = "Размер холста...";
            this.ChangeSizeButton.Click += new System.EventHandler(this.ChangeSizeButton_Click);
            // 
            // расположениеРисунковToolStripMenuItem
            // 
            this.расположениеРисунковToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CascadeButton,
            this.TileHorizontalButton,
            this.TileVerticalButton,
            this.ArrangeIcons});
            this.расположениеРисунковToolStripMenuItem.Name = "расположениеРисунковToolStripMenuItem";
            this.расположениеРисунковToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.расположениеРисунковToolStripMenuItem.Text = "Расположение рисунков";
            // 
            // CascadeButton
            // 
            this.CascadeButton.Name = "CascadeButton";
            this.CascadeButton.Size = new System.Drawing.Size(236, 26);
            this.CascadeButton.Text = "Каскадом";
            this.CascadeButton.Click += new System.EventHandler(this.CascadeButton_Click);
            // 
            // TileHorizontalButton
            // 
            this.TileHorizontalButton.Name = "TileHorizontalButton";
            this.TileHorizontalButton.Size = new System.Drawing.Size(236, 26);
            this.TileHorizontalButton.Text = "Слева направо";
            this.TileHorizontalButton.Click += new System.EventHandler(this.TileHorizontalButton_Click);
            // 
            // TileVerticalButton
            // 
            this.TileVerticalButton.Name = "TileVerticalButton";
            this.TileVerticalButton.Size = new System.Drawing.Size(236, 26);
            this.TileVerticalButton.Text = "Сверху вниз";
            this.TileVerticalButton.Click += new System.EventHandler(this.TileVerticalButton_Click);
            // 
            // ArrangeIcons
            // 
            this.ArrangeIcons.Name = "ArrangeIcons";
            this.ArrangeIcons.Size = new System.Drawing.Size(236, 26);
            this.ArrangeIcons.Text = "Упорядочить значки";
            this.ArrangeIcons.Click += new System.EventHandler(this.ArrangeIcons_Click);
            // 
            // WindowsButton
            // 
            this.WindowsButton.Name = "WindowsButton";
            this.WindowsButton.Size = new System.Drawing.Size(59, 24);
            this.WindowsButton.Text = "Окно";
            // 
            // FilterButton
            // 
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(85, 24);
            this.FilterButton.Text = "Фильтры";
            this.FilterButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.FilterButton_DropDownItemClicked);
            // 
            // QButton
            // 
            this.QButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About});
            this.QButton.Name = "QButton";
            this.QButton.Size = new System.Drawing.Size(81, 24);
            this.QButton.Text = "Справка";
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(196, 26);
            this.About.Text = "О программе...";
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomInButton,
            this.ZoomOutButton,
            this.toolStripSeparator5,
            this.PalleteButton,
            this.PipButton,
            this.toolStripSeparator3,
            this.ClearButton,
            this.EraserButton,
            this.toolStripSeparator2,
            this.PencilButton,
            this.LineButton,
            this.EllipseButton,
            this.RectangleButton,
            this.StarButton,
            this.StarLabel,
            this.VertexNumber,
            this.toolStripSeparator4,
            this.StyleLabel});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1017, 33);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInButton.Image = global::MyPaint.Properties.Resources.icons8_zoom_in_40;
            this.ZoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.Size = new System.Drawing.Size(29, 30);
            this.ZoomInButton.Text = "toolStripButton1";
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOutButton.Image = global::MyPaint.Properties.Resources.icons8_zoom_out_40;
            this.ZoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.Size = new System.Drawing.Size(29, 30);
            this.ZoomOutButton.Text = "toolStripButton2";
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 33);
            // 
            // PalleteButton
            // 
            this.PalleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PalleteButton.Image = global::MyPaint.Properties.Resources.icons8_paint_palette_30;
            this.PalleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PalleteButton.Name = "PalleteButton";
            this.PalleteButton.Size = new System.Drawing.Size(29, 30);
            this.PalleteButton.Text = "Палитра";
            this.PalleteButton.Click += new System.EventHandler(this.PalleteButton_Click);
            // 
            // PipButton
            // 
            this.PipButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PipButton.Image = global::MyPaint.Properties.Resources.icons8_color_dropper_64;
            this.PipButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PipButton.Name = "PipButton";
            this.PipButton.Size = new System.Drawing.Size(29, 30);
            this.PipButton.Text = "Пипетка";
            this.PipButton.Click += new System.EventHandler(this.PipButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // ClearButton
            // 
            this.ClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearButton.Image = global::MyPaint.Properties.Resources.icons8_broom_128;
            this.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(29, 30);
            this.ClearButton.Text = "Очистить";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // EraserButton
            // 
            this.EraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EraserButton.Image = global::MyPaint.Properties.Resources.icons8_eraser_64;
            this.EraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EraserButton.Name = "EraserButton";
            this.EraserButton.Size = new System.Drawing.Size(29, 30);
            this.EraserButton.Text = "Ластик";
            this.EraserButton.Click += new System.EventHandler(this.EraserButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // PencilButton
            // 
            this.PencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PencilButton.Image = global::MyPaint.Properties.Resources.icons8_pencil_16;
            this.PencilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PencilButton.Name = "PencilButton";
            this.PencilButton.Size = new System.Drawing.Size(29, 30);
            this.PencilButton.Text = "Карандаш";
            this.PencilButton.Click += new System.EventHandler(this.PencilButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineButton.Image = global::MyPaint.Properties.Resources.icons8_line_64;
            this.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(29, 30);
            this.LineButton.Text = "Линия";
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // EllipseButton
            // 
            this.EllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EllipseButton.Image = global::MyPaint.Properties.Resources.icons8_ellipse_40;
            this.EllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(29, 30);
            this.EllipseButton.Text = "Эллипс";
            this.EllipseButton.Click += new System.EventHandler(this.EllipseButton_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RectangleButton.Image = global::MyPaint.Properties.Resources.icons8_rectangle_40;
            this.RectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(29, 30);
            this.RectangleButton.Text = "Прямоугольник";
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // StarButton
            // 
            this.StarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StarButton.Image = global::MyPaint.Properties.Resources.icons8_star_filled_40;
            this.StarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StarButton.Name = "StarButton";
            this.StarButton.Size = new System.Drawing.Size(29, 30);
            this.StarButton.Text = "Звезда";
            this.StarButton.Click += new System.EventHandler(this.StarButton_Click);
            // 
            // StarLabel
            // 
            this.StarLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StarLabel.Name = "StarLabel";
            this.StarLabel.Size = new System.Drawing.Size(120, 30);
            this.StarLabel.Text = "Кол-во вершин:";
            // 
            // VertexNumber
            // 
            this.VertexNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.VertexNumber.Margin = new System.Windows.Forms.Padding(0, 2, 6, 4);
            this.VertexNumber.Name = "VertexNumber";
            this.VertexNumber.Size = new System.Drawing.Size(55, 27);
            this.VertexNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VertexNumber_KeyPress);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 33);
            // 
            // StyleLabel
            // 
            this.StyleLabel.Name = "StyleLabel";
            this.StyleLabel.Size = new System.Drawing.Size(111, 30);
            this.StyleLabel.Text = "Стиль контура:";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Red;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(14, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // красныйToolStripMenuItem
            // 
            this.красныйToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.красныйToolStripMenuItem.Name = "красныйToolStripMenuItem";
            this.красныйToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.красныйToolStripMenuItem.Text = "Красный";
            // 
            // синийToolStripMenuItem
            // 
            this.синийToolStripMenuItem.Name = "синийToolStripMenuItem";
            this.синийToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.синийToolStripMenuItem.Text = "Синий";
            // 
            // зелёныйToolStripMenuItem
            // 
            this.зелёныйToolStripMenuItem.Name = "зелёныйToolStripMenuItem";
            this.зелёныйToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.зелёныйToolStripMenuItem.Text = "Зелёный";
            // 
            // другойToolStripMenuItem
            // 
            this.другойToolStripMenuItem.Name = "другойToolStripMenuItem";
            this.другойToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.другойToolStripMenuItem.Text = "Другой...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(51, 24);
            this.toolStripLabel1.Text = "Кисть:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 606);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Paint";
            this.Text = "My Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Paint_FormClosing);
            this.Load += new System.EventHandler(this.Paint_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileButton;
        private System.Windows.Forms.ToolStripMenuItem CreateNew;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.ToolStripMenuItem PictureButton;
        private System.Windows.Forms.ToolStripMenuItem ChangeSizeButton;
        private System.Windows.Forms.ToolStripMenuItem WindowsButton;
        private System.Windows.Forms.ToolStripMenuItem QButton;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem красныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem синийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зелёныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem другойToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton PencilButton;
        private System.Windows.Forms.ToolStripButton EraserButton;
        private System.Windows.Forms.ToolStripButton LineButton;
        private System.Windows.Forms.ToolStripButton PalleteButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripButton ClearButton;
        private System.Windows.Forms.ToolStripButton EllipseButton;
        private System.Windows.Forms.ToolStripButton RectangleButton;
        private System.Windows.Forms.ToolStripButton PipButton;
        private System.Windows.Forms.ToolStripMenuItem CloseCanva;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton StarButton;
        private System.Windows.Forms.ToolStripLabel StarLabel;
        private System.Windows.Forms.ToolStripTextBox VertexNumber;
        private System.Windows.Forms.ToolStripMenuItem FilterButton;
        private System.Windows.Forms.ToolStripMenuItem расположениеРисунковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CascadeButton;
        private System.Windows.Forms.ToolStripMenuItem TileHorizontalButton;
        private System.Windows.Forms.ToolStripMenuItem TileVerticalButton;
        private System.Windows.Forms.ToolStripMenuItem ArrangeIcons;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel StyleLabel;
        private System.Windows.Forms.ToolStripButton ZoomInButton;
        private System.Windows.Forms.ToolStripButton ZoomOutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}

