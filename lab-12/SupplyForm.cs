using Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq; // Не забудь добавить для ToList()
using System.Windows.Forms;

namespace lab_12
{
    public partial class SupplyForm : Form
    {
        private readonly string _dbPath = @"D:\Projects\Visual-Programming\lab-12\supply.db";

        public SupplyForm()
        {
            InitializeComponent();
            Load += SupplyForm_Load;
        }

        public List<Item> GetItems()
        {
            using (var db = new SQLiteConnection(_dbPath))
            {
                return db.Table<Item>().ToList();
            }
        }

        public List<Supplier> GetSuppliers()
        {
            using (var db = new SQLiteConnection(_dbPath))
            {
                return db.Table<Supplier>().ToList();
            }
        }

        public object GetSuppliesExtended()
        {
            using (var db = new SQLiteConnection(_dbPath))
            {
                var query = from s in db.Table<Supply>()
                            join item in db.Table<Item>() on s.ItemID equals item.ID
                            join supp in db.Table<Supplier>() on s.SupplierID equals supp.ID
                            select new
                            {
                                Дата_поставки = s.Date.ToShortDateString(),
                                Поставщик = supp.Name,
                                Артикул = s.ItemID,
                                Товар = item.Name,
                                Объем = s.Volume,
                                Общая_стоимость = (s.Volume ?? 0) * item.Price
                            };

                return query.ToList();
            }
        }

        private void RefreshData()
        {
            if (itemGrid == null || suppliersGrid == null || supplyGrid == null) return;

            itemGrid.DataSource = GetItems();
            suppliersGrid.DataSource = GetSuppliers();
            supplyGrid.DataSource = GetSuppliesExtended();
        }

        private void SupplyForm_Load(object sender, System.EventArgs e)
        {
            RefreshData();
        }

        private void refreshItem_Click(object sender, System.EventArgs e)
        {
            RefreshData(); 
        }

        private void addItem_Click(object sender, System.EventArgs e)
        {
            AddItemForm addForm = new AddItemForm();

            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshData();
            }
        }

        private void addSupplier_Click(object sender, EventArgs e)
        {
            AddSupplierForm add = new AddSupplierForm();
            if (add.ShowDialog(this) == DialogResult.OK) RefreshData();
        }

        private void refreshSupplier_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void updateItem_Click(object sender, EventArgs e)
        {
            if (itemGrid.SelectedCells.Count > 0)
            {
                int rowIndex = itemGrid.SelectedCells[0].RowIndex;

                var selectedItem = itemGrid.Rows[rowIndex].DataBoundItem as Item;

                if (selectedItem != null)
                {
                    AddItemForm editForm = new AddItemForm(selectedItem);
                    if (editForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования!", "Внимание");
            }
        }

        private void removeItem_Click(object sender, EventArgs e)
        {
            if (itemGrid.SelectedCells.Count > 0)
            {
                int rowIndex = itemGrid.SelectedCells[0].RowIndex;
                var item = itemGrid.Rows[rowIndex].DataBoundItem as Item;

                if (item != null)
                {
                    var result = MessageBox.Show($"Удалить товар '{item.Name}'?", "Удаление",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using (var db = new SQLiteConnection(_dbPath))
                        {
                            db.Delete(item);
                        }
                        RefreshData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления!", "Внимание");
            }
        }

        private void updateSupplier_Click(object sender, EventArgs e)
        {
            if (suppliersGrid.SelectedCells.Count > 0)
            {
                int rowIndex = suppliersGrid.SelectedCells[0].RowIndex;
                var selectedSupplier = suppliersGrid.Rows[rowIndex].DataBoundItem as Supplier;

                if (selectedSupplier != null)
                {
                    AddSupplierForm editForm = new AddSupplierForm(selectedSupplier);

                    if (editForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите поставщика для редактирования!", "Внимание");
            }
        }

        private void removeSupplier_Click(object sender, EventArgs e)
        {
            if (suppliersGrid.SelectedCells.Count > 0)
            {
                int rowIndex = suppliersGrid.SelectedCells[0].RowIndex;
                var selectedSupplier = suppliersGrid.Rows[rowIndex].DataBoundItem as Supplier;

                if (selectedSupplier != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"Вы уверены, что хотите удалить поставщика '{selectedSupplier.Name}'?",
                        "Удаление",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            using (var db = new SQLiteConnection(_dbPath))
                            {
                                db.Delete(selectedSupplier);
                            }
                            RefreshData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при удалении: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите поставщика для удаления!", "Внимание");
            }
        }

    }
}
