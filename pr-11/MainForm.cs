namespace pr_11
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pictureBox.Visible = false;
            imageMenuItem.Visible = false;
            UpdateUndoRedoButtons();
            SetupShortcuts();
            SetSaveButtonsEnabled(false);
        }

        private void SetupShortcuts()
        {
            отменитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            отменитьToolStripMenuItem.ShowShortcutKeys = true;

            вернутьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            вернутьToolStripMenuItem.ShowShortcutKeys = true;

            openFileMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openFileMenuItem.ShowShortcutKeys = true;

            сохранитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            сохранитьToolStripMenuItem.ShowShortcutKeys = true;
        }

        private void UpdateUndoRedoButtons()
        {

            отменитьToolStripMenuItem.Enabled = _undoStack != null && _undoStack.Count > 0;
            вернутьToolStripMenuItem.Enabled = _redoStack != null && _redoStack.Count > 0;
        }

        private void SetSaveButtonsEnabled(bool state)
        {
            сохранитьToolStripMenuItem.Enabled = state;
            saveAsMenuItem.Enabled = state;
        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Изображения(*.bmp;*.jpeg;*.jpg)|*.bmp;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var tempImage = new Bitmap(openFileDialog.FileName))
                {
                    _sourceImage = new Bitmap(tempImage);
                }

                pictureBox.Image = _sourceImage;
                pictureBox.Size = _sourceImage.Size;

                this.Width = pictureBox.Width + 40;
                this.Height = pictureBox.Height + 77;
                this.CenterToScreen();

                pictureBox.Visible = true;
                imageMenuItem.Visible = true;

                _undoStack.Clear();
                _redoStack.Clear();
                SetSaveButtonsEnabled(true);
                UpdateUndoRedoButtons();
            }
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
            UpdateUndoRedoButtons();
        }

        private void filterMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null) return;

            TakeSnapshot();

            var resultBitmap = ImageProcess.SharpenImage((Bitmap)pictureBox.Image);
            pictureBox.Image = resultBitmap;

            UpdateUndoRedoButtons();
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
                UpdateUndoRedoButtons();
            }
        }

        private void вернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push(new Bitmap(pictureBox.Image));
                pictureBox.Image = _redoStack.Pop();

                UpdateUndoRedoButtons();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(openFileDialog.FileName) && pictureBox.Image != null)
            {
                try
                {
                    string path = openFileDialog.FileName;
                    pictureBox.Image.Save(path);
                    MessageBox.Show("Изменения успешно сохранены!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                }
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
