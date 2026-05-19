using System;
using System.Windows.Forms;

namespace pr_12
{
    public partial class ToasterForm : Form
    {
        private int secondsRemaining;
        private int totalCookingTime;

        public ToasterForm()
        {
            InitializeComponent();

            if (comboBoxBreadType.Items.Count > 0)
            {
                comboBoxBreadType.SelectedIndex = 0;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            totalCookingTime = Convert.ToInt32(numericTime.Value);
            secondsRemaining = totalCookingTime;

            progressBarCooking.Maximum = totalCookingTime;
            progressBarCooking.Value = 0;
            progressBarCooking.Visible = true;

            btnStart.Enabled = false;
            comboBoxBreadType.Enabled = false;
            radioOneSlice.Enabled = false;
            radioTwoSlices.Enabled = false;
            numericTime.Enabled = false;

            lblTimerDisplay.Text = $"Жарим... Осталось секунд: {secondsRemaining}";

            toasterTimer.Start();
        }

        private void toasterTimer_Tick(object sender, EventArgs e)
        {
            secondsRemaining--;

            progressBarCooking.Value = totalCookingTime - secondsRemaining;

            if (secondsRemaining > 0)
            {
                lblTimerDisplay.Text = $"Жарим... Осталось секунд: {secondsRemaining}";
            }
            else
            {
                toasterTimer.Stop();
                lblTimerDisplay.Text = "Тостер готов к работе";
                progressBarCooking.Visible = false;
                progressBarCooking.Value = 0;

                ShowResult();
                ResetInterface();
            }
        }

        private void ShowResult()
        {
            string slicesCount = radioOneSlice.Checked ? "1 ломтик" : "2 ломтика";
            string breadType = comboBoxBreadType.SelectedItem.ToString();

            string doneness;
            if (totalCookingTime < 5)
            {
                doneness = "Слегка теплый";
            }
            else if (totalCookingTime <= 10)
            {
                doneness = "Идеальный золотистый тост";
            }
            else
            {
                doneness = "Уголек (";
            }

            string message = $"Ваш хлеб готов!\n\n" +
                             $"Тип хлеба: {breadType}\n" +
                             $"Количество: {slicesCount}\n" +
                             $"Время жарки: {totalCookingTime} сек.\n" +
                             $"Результат: {doneness}";

            MessageBox.Show(message, "Тостер завершил работу", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ResetInterface()
        {
            btnStart.Enabled = true;
            comboBoxBreadType.Enabled = true;
            radioOneSlice.Enabled = true;
            radioTwoSlices.Enabled = true;
            numericTime.Enabled = true;
        }
    }
}