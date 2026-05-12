using Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lab_12
{
    public partial class AddItemForm : Form
    {
        private int _id;
        private string _name;
        private string _manufacturer;
        private decimal _price;
        private readonly string _dbPath = @"C:\PROJECTS\C#Projects\visual-programming\lab-12\supply.db";

        public AddItemForm()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        public AddItemForm(Item item) : this()
        {
            txtId.Text = item.ID.ToString();
            txtName.Text = item.Name;
            txtManufacturer.Text = item.Manufacturer;
            txtPrice.Text = item.Price.ToString();

            txtId.ReadOnly = true;

            btnAdd.Text = "Сохранить";
            this.Text = "Редактировать товар";
        }

        private void txtId_Validating(object sender, CancelEventArgs e)
        {
            string input = txtId.Text.Trim();
            if (Regex.IsMatch(input, @"^\d+$"))
            {
                errorProvider.SetError(txtId, String.Empty);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtId, "Введите числовой артикул!");
                e.Cancel = true;
            }
        }

        private void txtId_Validated(object sender, EventArgs e) => _id = Convert.ToInt32(txtId.Text.Trim());

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, string.Empty);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtName, "Наименование не может быть пустым!");
                e.Cancel = true;
            }
        }

        private void txtName_Validated(object sender, EventArgs e) => _name = txtName.Text.Trim();

        private void txtManufacturer_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtManufacturer.Text))
            {
                errorProvider.SetError(txtManufacturer, string.Empty);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtManufacturer, "Укажите производителя!");
                e.Cancel = true;
            }
        }

        private void txtManufacturer_Validated(object sender, EventArgs e) => _manufacturer = txtManufacturer.Text.Trim();

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text, out decimal res) && res >= 0)
            {
                errorProvider.SetError(txtPrice, string.Empty);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtPrice, "Введите корректную цену!");
                e.Cancel = true;
            }
        }

        private void txtPrice_Validated(object sender, EventArgs e) => _price = Convert.ToDecimal(txtPrice.Text.Trim());

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                SaveItem();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveItem()
        {
            try
            {
                using (var db = new SQLiteConnection(_dbPath))
                {
                    db.InsertOrReplace(new Item
                    {
                        ID = _id,
                        Name = _name,
                        Manufacturer = _manufacturer,
                        Price = _price
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }
    }
}
