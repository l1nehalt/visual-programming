namespace pr_12
{
    partial class ToasterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBoxBreadType = new ComboBox();
            radioOneSlice = new RadioButton();
            radioTwoSlices = new RadioButton();
            numericTime = new NumericUpDown();
            btnStart = new Button();
            lblTimerDisplay = new Label();
            toasterTimer = new System.Windows.Forms.Timer(components);
            typeBread = new Label();
            timeCooking = new Label();
            progressBarCooking = new ProgressBar();
            btnStop = new Button();
            ((System.ComponentModel.ISupportInitialize)numericTime).BeginInit();
            SuspendLayout();
            // 
            // comboBoxBreadType
            // 
            comboBoxBreadType.Font = new Font("Segoe UI", 12F);
            comboBoxBreadType.FormattingEnabled = true;
            comboBoxBreadType.Items.AddRange(new object[] { "Белый", "Черный" });
            comboBoxBreadType.Location = new Point(23, 60);
            comboBoxBreadType.Margin = new Padding(3, 4, 3, 4);
            comboBoxBreadType.Name = "comboBoxBreadType";
            comboBoxBreadType.Size = new Size(228, 36);
            comboBoxBreadType.TabIndex = 0;
            // 
            // radioOneSlice
            // 
            radioOneSlice.AutoSize = true;
            radioOneSlice.Checked = true;
            radioOneSlice.Font = new Font("Segoe UI", 12F);
            radioOneSlice.Location = new Point(22, 104);
            radioOneSlice.Margin = new Padding(3, 4, 3, 4);
            radioOneSlice.Name = "radioOneSlice";
            radioOneSlice.Size = new Size(116, 32);
            radioOneSlice.TabIndex = 1;
            radioOneSlice.TabStop = true;
            radioOneSlice.Text = "1 ломтик";
            radioOneSlice.UseVisualStyleBackColor = true;
            // 
            // radioTwoSlices
            // 
            radioTwoSlices.AutoSize = true;
            radioTwoSlices.Font = new Font("Segoe UI", 12F);
            radioTwoSlices.Location = new Point(22, 144);
            radioTwoSlices.Margin = new Padding(3, 4, 3, 4);
            radioTwoSlices.Name = "radioTwoSlices";
            radioTwoSlices.Size = new Size(126, 32);
            radioTwoSlices.TabIndex = 2;
            radioTwoSlices.TabStop = true;
            radioTwoSlices.Text = "2 ломтика";
            radioTwoSlices.UseVisualStyleBackColor = true;
            // 
            // numericTime
            // 
            numericTime.Font = new Font("Segoe UI", 12F);
            numericTime.Location = new Point(23, 220);
            numericTime.Margin = new Padding(3, 4, 3, 4);
            numericTime.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericTime.Name = "numericTime";
            numericTime.Size = new Size(229, 34);
            numericTime.TabIndex = 3;
            numericTime.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnStart.Location = new Point(22, 262);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(229, 40);
            btnStart.TabIndex = 4;
            btnStart.Text = "Поджарить";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblTimerDisplay
            // 
            lblTimerDisplay.AutoSize = true;
            lblTimerDisplay.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblTimerDisplay.Location = new Point(23, 420);
            lblTimerDisplay.Name = "lblTimerDisplay";
            lblTimerDisplay.Size = new Size(237, 28);
            lblTimerDisplay.TabIndex = 5;
            lblTimerDisplay.Text = "Тостер готов к работе";
            // 
            // toasterTimer
            // 
            toasterTimer.Interval = 1000;
            toasterTimer.Tick += toasterTimer_Tick;
            // 
            // typeBread
            // 
            typeBread.AutoSize = true;
            typeBread.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            typeBread.Location = new Point(22, 28);
            typeBread.Name = "typeBread";
            typeBread.Size = new Size(107, 28);
            typeBread.TabIndex = 6;
            typeBread.Text = "Вид хлеба:";
            // 
            // timeCooking
            // 
            timeCooking.AutoSize = true;
            timeCooking.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            timeCooking.Location = new Point(23, 188);
            timeCooking.Name = "timeCooking";
            timeCooking.Size = new Size(199, 28);
            timeCooking.TabIndex = 7;
            timeCooking.Text = "Время прожарки (с):";
            // 
            // progressBarCooking
            // 
            progressBarCooking.Location = new Point(23, 367);
            progressBarCooking.Margin = new Padding(3, 4, 3, 4);
            progressBarCooking.Name = "progressBarCooking";
            progressBarCooking.Size = new Size(228, 33);
            progressBarCooking.TabIndex = 8;
            progressBarCooking.Visible = false;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.MistyRose;
            btnStop.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnStop.Location = new Point(23, 310);
            btnStop.Margin = new Padding(3, 4, 3, 4);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(229, 40);
            btnStop.TabIndex = 9;
            btnStop.Text = "Остановить";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // ToasterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 493);
            Controls.Add(btnStop);
            Controls.Add(progressBarCooking);
            Controls.Add(timeCooking);
            Controls.Add(typeBread);
            Controls.Add(lblTimerDisplay);
            Controls.Add(btnStart);
            Controls.Add(numericTime);
            Controls.Add(radioTwoSlices);
            Controls.Add(radioOneSlice);
            Controls.Add(comboBoxBreadType);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ToasterForm";
            Text = "Имитатор Тостера";
            ((System.ComponentModel.ISupportInitialize)numericTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxBreadType;
        private RadioButton radioOneSlice;
        private RadioButton radioTwoSlices;
        private NumericUpDown numericTime;
        private Button btnStart;
        private Label lblTimerDisplay;
        private System.Windows.Forms.Timer toasterTimer;
        private Label typeBread;
        private Label timeCooking;
        private ProgressBar progressBarCooking;
        private Button btnStop;
    }
}