using Model;
using SQLite;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace lab_12
{
    public partial class AddSupplyForm : Form
    {
        private readonly string _dbPath = @"C:\PROJECTS\C#Projects\visual-programming\lab-12\supply.db";
        private readonly Supply _editableSupply = null;

        public AddSupplyForm()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            LoadDictionaries();
        }

        public AddSupplyForm(Supply supply) : this()
        {
            _editableSupply = supply;

            cmbSuppliers.SelectedValue = supply.SupplierID;
            cmbItems.SelectedValue = supply.ItemID;
            dtpDate.Value = supply.Date;
            numVolume.Value = supply.Volume ?? 0;
            btnAdd.Text = "Сохранить";
            this.Text = "Редактировать поставку";
        }

        private void LoadDictionaries()
        {
            using (var db = new SQLiteConnection(_dbPath))
            {
                var items = db.Table<Item>().ToList();
                cmbItems.DataSource = items;
                cmbItems.DisplayMember = "Name"; 
                cmbItems.ValueMember = "ID";    

                var suppliers = db.Table<Supplier>().ToList();
                cmbSuppliers.DataSource = suppliers;
                cmbSuppliers.DisplayMember = "Name";
                cmbSuppliers.ValueMember = "ID";
            }
        }

        private void numVolume_Validating(object sender, CancelEventArgs e)
        {
            if (numVolume.Value <= 0)
            {
                errorProvider.SetError(numVolume, "Объем должен быть больше нуля!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(numVolume, "");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    using (var db = new SQLiteConnection(_dbPath, storeDateTimeAsTicks: false))
                    {
                        var supply = new Supply
                        {
                            SupplierID = (long)cmbSuppliers.SelectedValue,
                            ItemID = (long)cmbItems.SelectedValue,
                            Date = dtpDate.Value,
                            Volume = (long)numVolume.Value
                        };

                        if (_editableSupply == null)
                        {
                            db.Insert(supply);
                        }
                        else
                        {
                           
                            string sql = @"UPDATE Supply 
                                 SET SupplierID = ?, ItemID = ?, Date = ?, Volume = ? 
                                 WHERE SupplierID = ? AND ItemID = ? AND Date = ?";

                            db.Execute(sql,
                                supply.SupplierID,  
                                supply.ItemID,        
                                supply.Date,         
                                supply.Volume,        
                                _editableSupply.SupplierID, 
                                _editableSupply.ItemID,     
                                _editableSupply.Date       
                            );
                        }
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