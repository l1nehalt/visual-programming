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
            comboBoxBreadType.DropDownStyle = ComboBoxStyle.DropDownList;
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

            string dots = getDots(secondsRemaining);

            lblTimerDisplay.Text = $"Жарим" + dots + $" \nОсталось секунд: {secondsRemaining}";

            toasterTimer.Start();
        }

        private void toasterTimer_Tick(object sender, EventArgs e)
        {
            secondsRemaining--;

            string dots = getDots(secondsRemaining);

            progressBarCooking.Value = totalCookingTime - secondsRemaining;

            if (secondsRemaining > 0)
            {
                lblTimerDisplay.Text = $"Жарим" + dots + $" \nОсталось секунд: {secondsRemaining}";
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

        private string getDots(int seconds)
        {
            int dotsAmnt = seconds % 3;
            if (dotsAmnt == 0)
            {
                return "...";
            }
            else if (dotsAmnt == 1)
            {
                return "..";
            }
            else
                return ".";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (secondsRemaining > 0)
            {

                ResetInterface();
                toasterTimer.Stop();

                lblTimerDisplay.Text = "Тостер готов к работе";
                progressBarCooking.Visible = false;
                progressBarCooking.Value = 0;
                secondsRemaining = 0;

                string message = "Остановка";

                MessageBox.Show(message, "Тостер завершил работу", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                return;
            }
        }
    }
}