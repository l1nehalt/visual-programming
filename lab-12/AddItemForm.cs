using lab_12.Data;
using lab_12.Data.Entities;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace lab_12
{
    public partial class AddItemForm : Form
    {
        private int _id;
        private string _name;
        private string _manufacturer;
        private decimal _price;

        public AddItemForm()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        private void txtId_Validating(object sender, CancelEventArgs e)
        {
            string input = txtId.Text.Trim();
            if (Regex.IsMatch(input, @"^\d+$"))
            {
                errorProvider.SetError(txtId, string.Empty);
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
                errorProvider.SetError(txtName, "Заполните наименование!");
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
            if (decimal.TryParse(txtPrice.Text.Trim(), out _))
            {
                errorProvider.SetError(txtPrice, string.Empty);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtPrice, "Некорректная цена!");
                e.Cancel = true;
            }
        }

        private void txtPrice_Validated(object sender, EventArgs e) => _price = Convert.ToDecimal(txtPrice.Text.Trim());

        private void btnAdd_Click(object sender, EventArgs e)
        {
          
            if (ValidateChildren())
            {
                AddItem();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AddItem()
        {
            try
            {
                using (var db = new SupplyContext())
                {
                    db.Items.Add(new Item
                    {
                        Id = _id,
                        Name = _name,
                        Manufacturer = _manufacturer,
                        Price = _price
                    });
                    db.SaveChanges();
                }
                MessageBox.Show("Данные добавлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении (возможно, такой ID уже есть)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
