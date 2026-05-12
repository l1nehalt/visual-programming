using Model;
using SQLite;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace lab_12
{
    public partial class AddSupplierForm : Form
    {
        private readonly string _dbPath = @"C:\PROJECTS\C#Projects\visual-programming\lab-12\supply.db";
        private Supplier _editableSupplier = null;

        public AddSupplierForm()
        {
            InitializeComponent();
            txtPhone.Mask = "8 (000) 000-00-00";
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        public AddSupplierForm(Supplier supplier) : this()
        {
            _editableSupplier = supplier;

            txtId.Text = _editableSupplier.ID.ToString();
            txtName.Text = _editableSupplier.Name;
            txtAddress.Text = _editableSupplier.Address;
            txtPhone.Text = _editableSupplier.Phone;

            txtId.ReadOnly = true;
            btnAdd.Text = "Сохранить";
            this.Text = "Редактировать поставщика";
        }

        private void txtId_Validating(object sender, CancelEventArgs e)
        {
            if (!long.TryParse(txtId.Text, out long idValue))
            {
                errorProvider.SetError(txtId, "ID должен быть целым числом!");
                e.Cancel = true; 
            }
            else if (idValue <= 0)
            {
                errorProvider.SetError(txtId, "ID должен быть больше нуля!");
                e.Cancel = true; 
            }
            else
            {
                errorProvider.SetError(txtId, "");
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Введите ФИО!");
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
                        db.InsertOrReplace(new Supplier
                        {
                            ID = long.Parse(txtId.Text),
                            Name = txtName.Text,
                            Address = txtAddress.Text,
                            Phone = txtPhone.Text
                        });
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
