namespace TheBestPaintInTheWorld
{
    partial class PaintWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(PaintWindow));
            Header = new Panel();
            ButtonPanel = new Panel();
            SizeBitton = new Button();
            HideButton = new Button();
            CloseButton = new Button();
            menuStrip = new MenuStrip();
            ToolStripShapeSelection = new ToolStripMenuItem();
            ToolStripCircle = new ToolStripMenuItem();
            ToolStripElips = new ToolStripMenuItem();
            ToolStripRectangle = new ToolStripMenuItem();
            ToolStripFill = new ToolStripMenuItem();
            ToolStripErase = new ToolStripMenuItem();
            ToolStripOutlineСolor = new ToolStripMenuItem();
            ToolStripFillColor = new ToolStripMenuItem();
            ToolStripBackgroundColor = new ToolStripMenuItem();
            OutlineColorDialog = new ColorDialog();
            FillColorDialog = new ColorDialog();
            BackgroundColorDialog = new ColorDialog();
            Header.SuspendLayout();
            ButtonPanel.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // Header
            // 
            Header.BackColor = Color.FromArgb(45, 62, 64);
            Header.Controls.Add(ButtonPanel);
            Header.Controls.Add(menuStrip);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(800, 50);
            Header.TabIndex = 0;
            Header.MouseDown += OnMouseDown;
            // 
            // ButtonPanel
            // 
            ButtonPanel.BackColor = Color.FromArgb(45, 62, 64);
            ButtonPanel.Controls.Add(SizeBitton);
            ButtonPanel.Controls.Add(HideButton);
            ButtonPanel.Controls.Add(CloseButton);
            ButtonPanel.Dock = DockStyle.Right;
            ButtonPanel.Location = new Point(625, 0);
            ButtonPanel.Name = "ButtonPanel";
            ButtonPanel.Size = new Size(175, 50);
            ButtonPanel.TabIndex = 0;
            // 
            // SizeBitton
            // 
            SizeBitton.BackColor = Color.FromArgb(39, 89, 80);
            SizeBitton.BackgroundImage = (Image)resources.GetObject("SizeBitton.BackgroundImage");
            SizeBitton.BackgroundImageLayout = ImageLayout.Stretch;
            SizeBitton.FlatAppearance.BorderSize = 0;
            SizeBitton.FlatStyle = FlatStyle.Flat;
            SizeBitton.Location = new Point(67, 3);
            SizeBitton.Name = "SizeBitton";
            SizeBitton.Size = new Size(42, 40);
            SizeBitton.TabIndex = 2;
            SizeBitton.UseVisualStyleBackColor = false;
            SizeBitton.Click += SizeBitton_Click;
            // 
            // HideButton
            // 
            HideButton.BackColor = Color.FromArgb(151, 166, 160);
            HideButton.BackgroundImage = (Image)resources.GetObject("HideButton.BackgroundImage");
            HideButton.BackgroundImageLayout = ImageLayout.Stretch;
            HideButton.FlatAppearance.BorderSize = 0;
            HideButton.FlatStyle = FlatStyle.Flat;
            HideButton.Location = new Point(13, 3);
            HideButton.Name = "HideButton";
            HideButton.Size = new Size(42, 40);
            HideButton.TabIndex = 1;
            HideButton.UseVisualStyleBackColor = false;
            HideButton.Click += HideButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.FromArgb(147, 191, 183);
            CloseButton.BackgroundImage = (Image)resources.GetObject("CloseButton.BackgroundImage");
            CloseButton.BackgroundImageLayout = ImageLayout.Stretch;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Location = new Point(120, 3);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(42, 40);
            CloseButton.TabIndex = 0;
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // menuStrip
            // 
            menuStrip.Dock = DockStyle.None;
            menuStrip.Items.AddRange(new ToolStripItem[] { ToolStripShapeSelection, ToolStripFill, ToolStripErase, ToolStripOutlineСolor, ToolStripFillColor, ToolStripBackgroundColor });
            menuStrip.Location = new Point(0, 19);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(454, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // ToolStripShapeSelection
            // 
            ToolStripShapeSelection.DropDownItems.AddRange(new ToolStripItem[] { ToolStripCircle, ToolStripElips, ToolStripRectangle });
            ToolStripShapeSelection.Name = "ToolStripShapeSelection";
            ToolStripShapeSelection.Size = new Size(59, 20);
            ToolStripShapeSelection.Text = "Фигура";
            // 
            // ToolStripCircle
            // 
            ToolStripCircle.Name = "ToolStripCircle";
            ToolStripCircle.Size = new Size(163, 22);
            ToolStripCircle.Text = "Круг";
            ToolStripCircle.Click += ToolStripCircle_Click;
            // 
            // ToolStripElips
            // 
            ToolStripElips.Name = "ToolStripElips";
            ToolStripElips.Size = new Size(163, 22);
            ToolStripElips.Text = "Элепс";
            ToolStripElips.Click += ToolStripElips_Click;
            // 
            // ToolStripRectangle
            // 
            ToolStripRectangle.Name = "ToolStripRectangle";
            ToolStripRectangle.Size = new Size(163, 22);
            ToolStripRectangle.Text = "Прямоугольник";
            ToolStripRectangle.Click += ToolStripRectangle_Click;
            // 
            // ToolStripFill
            // 
            ToolStripFill.Name = "ToolStripFill";
            ToolStripFill.Size = new Size(64, 20);
            ToolStripFill.Text = "Заливка";
            ToolStripFill.Click += ToolStripFill_Click;
            // 
            // ToolStripErase
            // 
            ToolStripErase.BackColor = Color.FromArgb(45, 62, 64);
            ToolStripErase.Name = "ToolStripErase";
            ToolStripErase.Size = new Size(62, 20);
            ToolStripErase.Text = "Стереть";
            ToolStripErase.Click += ToolStripErase_Click;
            // 
            // ToolStripOutlineСolor
            // 
            ToolStripOutlineСolor.Name = "ToolStripOutlineСolor";
            ToolStripOutlineСolor.Size = new Size(92, 20);
            ToolStripOutlineСolor.Text = "Цвет контура";
            ToolStripOutlineСolor.Click += ToolStripOutlineСolor_Click;
            // 
            // ToolStripFillColor
            // 
            ToolStripFillColor.Name = "ToolStripFillColor";
            ToolStripFillColor.Size = new Size(92, 20);
            ToolStripFillColor.Text = "Цвет заливки";
            ToolStripFillColor.Click += ToolStripFillColor_Click;
            // 
            // ToolStripBackgroundColor
            // 
            ToolStripBackgroundColor.Name = "ToolStripBackgroundColor";
            ToolStripBackgroundColor.Size = new Size(77, 20);
            ToolStripBackgroundColor.Text = "Цвет фона";
            ToolStripBackgroundColor.Click += ToolStripBackgroundColor_Click;
            // 
            // PaintWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip;
            Name = "PaintWindow";
            Text = "The best Paint";
            MouseDown += PaintWindow_MouseDown;
            MouseUp += PaintWindow_MouseUp;
            Header.ResumeLayout(false);
            Header.PerformLayout();
            ButtonPanel.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Header;
        private Panel ButtonPanel;
        private Button CloseButton;
        private Button SizeBitton;
        private Button HideButton;
        private MenuStrip menuStrip;
        private ToolStripMenuItem ToolStripFill;
        private ToolStripMenuItem ToolStripErase;
        private ToolStripMenuItem ToolStripOutlineСolor;
        private ToolStripMenuItem ToolStripFillColor;
        private ColorDialog OutlineColorDialog;
        private ColorDialog FillColorDialog;
        private ToolStripMenuItem ToolStripBackgroundColor;
        private ColorDialog BackgroundColorDialog;
        private ToolStripMenuItem ToolStripShapeSelection;
        private ToolStripMenuItem ToolStripCircle;
        private ToolStripMenuItem ToolStripElips;
        private ToolStripMenuItem ToolStripRectangle;
    }
}
