namespace pr_11
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pictureBox.Visible = false;
            imageMenuItem.Visible = false;
        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Изображения(*.bmp;*.jpeg;*.jpg)|*.bmp;*.jpeg;*.jpg";
            openFileDialog.ShowDialog();
            _sourceImage = new Bitmap(openFileDialog.FileName);
            pictureBox.Size = _sourceImage.Size;
            this.Width = pictureBox.Width + 40;
            this.Height = pictureBox.Height + 77;
            this.CenterToScreen();
            pictureBox.Image = _sourceImage;
            pictureBox.Visible = true;
            imageMenuItem.Visible = true;
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Изображение BMP|*.bmp|" +
                "Изображение JPEG | *.jpeg | Изображение JPG | *.jpg";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                System.IO.FileStream fs =
                (System.IO.FileStream)saveFileDialog.OpenFile();
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        pictureBox.Image.Save(fs,
                       System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 2:
                        pictureBox.Image.Save(fs,
                       System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 3:
                        pictureBox.Image.Save(fs,
                       System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }
                fs.Close();
            }
        }

        private void TakeSnapshot()
        {
            _undoStack.Push(new Bitmap(pictureBox.Image));
            _redoStack.Clear();
        }

        private void filterMenuItem_Click(object sender, EventArgs e)
        {
            var resultBitmap = ImageProcess.FilterImage(_sourceImage);
            pictureBox.Image = resultBitmap;
        }

        private void матрицаЛапласаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeSnapshot();
            var resultBitmap = ImageProcess.SharpenEdges((Bitmap)pictureBox.Image);
            pictureBox.Image = resultBitmap;
        }

        private void матрицаГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeSnapshot();
            var resultBitmap = ImageProcess.BlurImage((Bitmap)pictureBox.Image);
            pictureBox.Image = resultBitmap;
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_undoStack.Count > 0)
            {

                _redoStack.Push(new Bitmap(pictureBox.Image));

                pictureBox.Image = _undoStack.Pop();
            }
            else
            {
                MessageBox.Show("Больше нечего отменять!");
            }
        }

        private void вернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push(new Bitmap(pictureBox.Image));

                pictureBox.Image = _redoStack.Pop();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                pictureBox.Image.Save(openFileDialog.FileName);
                MessageBox.Show("Сохранено!");
            }
        }
    }
}
