using Model;
using SQLite;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lab_12
{
    public partial class AddSupplierForm : Form
    {
        private readonly string _dbPath = @"D:\Projects\Visual-Programming\lab-12\supply.db";

        public AddSupplierForm()
        {
            InitializeComponent();
            txtPhone.Mask = "8 (000) 000-00-00";
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        public AddSupplierForm(Supplier supplier) : this()
        {
            txtId.Text = supplier.ID.ToString();
            txtName.Text = supplier.Name;
            txtAddress.Text = supplier.Address;
            txtPhone.Text = supplier.Phone;

            txtId.ReadOnly = true;

            btnAdd.Text = "Сохранить";
            this.Text = "Редактировать поставщика";
        }


        private void txtId_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtId.Text, out _))
            {
                errorProvider.SetError(txtId, "ID должен быть числом!");
                e.Cancel = true;
            }
            else { errorProvider.SetError(txtId, ""); }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Введите наименование!");
                e.Cancel = true;
            }
            else { errorProvider.SetError(txtName, ""); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    using (var db = new SQLiteConnection(_dbPath))
                    {
                        db.Insert(new Supplier
                        {
                            ID = int.Parse(txtId.Text),
                            Name = txtName.Text,
                            Address = txtAddress.Text,
                            Phone = txtPhone.Text
                        });
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка! Возможно, такой ID уже есть.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
