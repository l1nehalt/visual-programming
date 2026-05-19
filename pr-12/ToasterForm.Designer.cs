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
            ((System.ComponentModel.ISupportInitialize)numericTime).BeginInit();
            SuspendLayout();
            // 
            // comboBoxBreadType
            // 
            comboBoxBreadType.Font = new Font("Segoe UI", 12F);
            comboBoxBreadType.FormattingEnabled = true;
            comboBoxBreadType.Items.AddRange(new object[] { "Белый", "Ржаной", "Цельнозерновой" });
            comboBoxBreadType.Location = new Point(20, 45);
            comboBoxBreadType.Name = "comboBoxBreadType";
            comboBoxBreadType.Size = new Size(200, 29);
            comboBoxBreadType.TabIndex = 0;
            // 
            // radioOneSlice
            // 
            radioOneSlice.AutoSize = true;
            radioOneSlice.Checked = true;
            radioOneSlice.Font = new Font("Segoe UI", 12F);
            radioOneSlice.Location = new Point(20, 95);
            radioOneSlice.Name = "radioOneSlice";
            radioOneSlice.Size = new Size(93, 25);
            radioOneSlice.TabIndex = 1;
            radioOneSlice.TabStop = true;
            radioOneSlice.Text = "1 ломтик";
            radioOneSlice.UseVisualStyleBackColor = true;
            // 
            // radioTwoSlices
            // 
            radioTwoSlices.AutoSize = true;
            radioTwoSlices.Font = new Font("Segoe UI", 12F);
            radioTwoSlices.Location = new Point(140, 95);
            radioTwoSlices.Name = "radioTwoSlices";
            radioTwoSlices.Size = new Size(101, 25);
            radioTwoSlices.TabIndex = 2;
            radioTwoSlices.TabStop = true;
            radioTwoSlices.Text = "2 ломтика";
            radioTwoSlices.UseVisualStyleBackColor = true;
            // 
            // numericTime
            // 
            numericTime.Font = new Font("Segoe UI", 12F);
            numericTime.Location = new Point(20, 165);
            numericTime.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericTime.Name = "numericTime";
            numericTime.Size = new Size(200, 29);
            numericTime.TabIndex = 3;
            numericTime.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnStart.Location = new Point(20, 215);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(200, 40);
            btnStart.TabIndex = 4;
            btnStart.Text = "Поджарить";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblTimerDisplay
            // 
            lblTimerDisplay.AutoSize = true;
            lblTimerDisplay.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblTimerDisplay.Location = new Point(20, 315);
            lblTimerDisplay.Name = "lblTimerDisplay";
            lblTimerDisplay.Size = new Size(190, 21);
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
            typeBread.Location = new Point(20, 20);
            typeBread.Name = "typeBread";
            typeBread.Size = new Size(84, 21);
            typeBread.TabIndex = 6;
            typeBread.Text = "Вид хлеба:";
            // 
            // timeCooking
            // 
            timeCooking.AutoSize = true;
            timeCooking.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            timeCooking.Location = new Point(20, 140);
            timeCooking.Name = "timeCooking";
            timeCooking.Size = new Size(156, 21);
            timeCooking.TabIndex = 7;
            timeCooking.Text = "Время прожарки (с):";
            // 
            // progressBarCooking
            // 
            progressBarCooking.Location = new Point(20, 275);
            progressBarCooking.Name = "progressBarCooking";
            progressBarCooking.Size = new Size(250, 25);
            progressBarCooking.TabIndex = 8;
            progressBarCooking.Visible = false;
            // 
            // ToasterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 370);
            Controls.Add(progressBarCooking);
            Controls.Add(timeCooking);
            Controls.Add(typeBread);
            Controls.Add(lblTimerDisplay);
            Controls.Add(btnStart);
            Controls.Add(numericTime);
            Controls.Add(radioTwoSlices);
            Controls.Add(radioOneSlice);
            Controls.Add(comboBoxBreadType);
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
    }
}