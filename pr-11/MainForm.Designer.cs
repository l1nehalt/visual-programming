namespace pr_11
{
    partial class MainForm
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
            menuStrip = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            openFileMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            saveAsMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            imageMenuItem = new ToolStripMenuItem();
            filterMenuItem = new ToolStripMenuItem();
            матрицаЛапласаToolStripMenuItem = new ToolStripMenuItem();
            матрицаГауссаToolStripMenuItem = new ToolStripMenuItem();
            отменитьToolStripMenuItem = new ToolStripMenuItem();
            вернутьToolStripMenuItem = new ToolStripMenuItem();
            pictureBox = new PictureBox();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenuItem, imageMenuItem, отменитьToolStripMenuItem, вернутьToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 3, 0, 3);
            menuStrip.Size = new Size(741, 30);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFileMenuItem, сохранитьToolStripMenuItem, saveAsMenuItem, exitMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(59, 24);
            fileMenuItem.Text = "Файл";
            // 
            // openFileMenuItem
            // 
            openFileMenuItem.Name = "openFileMenuItem";
            openFileMenuItem.Size = new Size(224, 26);
            openFileMenuItem.Text = "Открыть";
            openFileMenuItem.Click += openFileMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.ShowShortcutKeys = false;
            сохранитьToolStripMenuItem.Size = new Size(224, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // saveAsMenuItem
            // 
            saveAsMenuItem.Name = "saveAsMenuItem";
            saveAsMenuItem.Size = new Size(224, 26);
            saveAsMenuItem.Text = "Сохранить как";
            saveAsMenuItem.Click += saveAsMenuItem_Click;
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(224, 26);
            exitMenuItem.Text = "Выход";
            exitMenuItem.Click += exitMenuItem_Click;
            // 
            // imageMenuItem
            // 
            imageMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filterMenuItem, матрицаЛапласаToolStripMenuItem, матрицаГауссаToolStripMenuItem });
            imageMenuItem.Name = "imageMenuItem";
            imageMenuItem.Size = new Size(121, 24);
            imageMenuItem.Text = "Изображение";
            // 
            // filterMenuItem
            // 
            filterMenuItem.Name = "filterMenuItem";
            filterMenuItem.Size = new Size(216, 26);
            filterMenuItem.Text = "Обработать";
            filterMenuItem.Click += filterMenuItem_Click;
            // 
            // матрицаЛапласаToolStripMenuItem
            // 
            матрицаЛапласаToolStripMenuItem.Name = "матрицаЛапласаToolStripMenuItem";
            матрицаЛапласаToolStripMenuItem.Size = new Size(216, 26);
            матрицаЛапласаToolStripMenuItem.Text = "Матрица Лапласа";
            матрицаЛапласаToolStripMenuItem.Click += матрицаЛапласаToolStripMenuItem_Click;
            // 
            // матрицаГауссаToolStripMenuItem
            // 
            матрицаГауссаToolStripMenuItem.Name = "матрицаГауссаToolStripMenuItem";
            матрицаГауссаToolStripMenuItem.Size = new Size(216, 26);
            матрицаГауссаToolStripMenuItem.Text = "Матрица Гаусса";
            матрицаГауссаToolStripMenuItem.Click += матрицаГауссаToolStripMenuItem_Click;
            // 
            // отменитьToolStripMenuItem
            // 
            отменитьToolStripMenuItem.Enabled = false;
            отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            отменитьToolStripMenuItem.Size = new Size(91, 24);
            отменитьToolStripMenuItem.Text = "Отменить";
            отменитьToolStripMenuItem.Click += отменитьToolStripMenuItem_Click;
            // 
            // вернутьToolStripMenuItem
            // 
            вернутьToolStripMenuItem.Enabled = false;
            вернутьToolStripMenuItem.Name = "вернутьToolStripMenuItem";
            вернутьToolStripMenuItem.Size = new Size(79, 24);
            вернутьToolStripMenuItem.Text = "Вернуть";
            вернутьToolStripMenuItem.Click += вернутьToolStripMenuItem_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(14, 36);
            pictureBox.Margin = new Padding(3, 4, 3, 4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(713, 493);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 545);
            Controls.Add(pictureBox);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "MainForm";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem imageMenuItem;
        private ToolStripMenuItem filterMenuItem;
        private ToolStripMenuItem openFileMenuItem;
        private ToolStripMenuItem saveAsMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private PictureBox pictureBox;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private Bitmap _sourceImage;
        private Stack<Bitmap> _undoStack = new Stack<Bitmap>();
        private Stack<Bitmap> _redoStack = new Stack<Bitmap>();
        private string _currentFilePath = string.Empty;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem матрицаЛапласаToolStripMenuItem;
        private ToolStripMenuItem матрицаГауссаToolStripMenuItem;
        private ToolStripMenuItem отменитьToolStripMenuItem;
        private ToolStripMenuItem вернутьToolStripMenuItem;
    }
}
