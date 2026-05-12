using Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab_12
{
    public partial class SupplyForm : Form
    {
        private readonly string _dbPath = @"C:\PROJECTS\C#Projects\visual-programming\lab-12\supply.db";

        public SupplyForm()
        {
            InitializeComponent();
            Load += SupplyForm_Load;
            supplyGrid.ScrollBars = ScrollBars.Vertical;
            supplyGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            supplyGrid.Width = 850;  
            supplyGrid.Height = 170;

            supplyGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            supplyGrid.AllowUserToResizeColumns = true;
            supplyGrid.AllowUserToResizeRows = false;
            supplyGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            itemGrid.ReadOnly = false;
            suppliersGrid.ReadOnly = false;
            itemGrid.CellValueChanged += ItemGrid_CellValueChanged;
            suppliersGrid.CellValueChanged += SuppliersGrid_CellValueChanged;
        }

        private void SuppliersGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = suppliersGrid.Rows[e.RowIndex];

                    var cellValue = row.Cells["ID"].Value;
                    if (cellValue == null || !long.TryParse(cellValue.ToString(), out long id))
                    {
                        return; 
                    }

                    string name = row.Cells["Name"].Value?.ToString();
                    string address = row.Cells["Address"].Value?.ToString();
                    string phone = row.Cells["Phone"].Value?.ToString();

                  
                    using (var db = new SQLite.SQLiteConnection(_dbPath))
                    {
                        var updatedSupplier = new Supplier
                        {
                            ID = id,
                            Name = name,
                            Address = address,
                            Phone = phone
                        };

                        db.Update(updatedSupplier);
                    }

                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении поставщика: " + ex.Message);
                }
            }
        }

        private void ItemGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = itemGrid.Rows[e.RowIndex];

                    var cellValue = row.Cells["ID"].Value;
                    if (cellValue == null || !long.TryParse(cellValue.ToString(), out long id))
                    {
                        return;
                    }

                    string name = row.Cells["Name"].Value?.ToString();
                    string manufacturer = row.Cells["Manufacturer"].Value?.ToString();

                    decimal price = 0;
                    if (row.Cells["Price"].Value != null)
                    {
                        decimal.TryParse(row.Cells["Price"].Value.ToString(), out price);
                    }

                    if (price < 0)
                    {
                        MessageBox.Show("Цена не может быть отрицательной!");
                        return;
                    }

                    using (var db = new SQLite.SQLiteConnection(_dbPath))
                    {
                        var updatedItem = new Item
                        {
                            Name = name,
                            Manufacturer = manufacturer,
                            Price = price
                        };

                        db.Update(updatedItem);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении товара: " + ex.Message);
                }
            }
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
            using (var db = new SQLiteConnection(_dbPath, storeDateTimeAsTicks: false))
            {
                var list = (from s in db.Table<Supply>()
                                 join item in db.Table<Item>() on s.ItemID equals item.ID
                                 join supp in db.Table<Supplier>() on s.SupplierID equals supp.ID
                                 select new
                                 {
                                     RawItemID = s.ItemID,
                                     RawSupplierID = s.SupplierID,
                                     RawDate = s.Date,
                                     Дата_поставки = s.Date.ToShortDateString(),
                                     Поставщик = supp.Name,
                                     Товар = item.Name,
                                     Объем = s.Volume,
                                     Общая_стоимость = (s.Volume ?? 0) * item.Price
                                 }).ToList();

                decimal total = list.Sum(x => x.Общая_стоимость);

                totalSumCost.Text = "Итого: " + total.ToString();

                return list;
            }
        }

        private void RefreshData()
        {
            if (itemGrid == null || suppliersGrid == null || supplyGrid == null) return;

            itemGrid.DataSource = GetItems();
            suppliersGrid.DataSource = GetSuppliers();
            supplyGrid.DataSource = GetSuppliesExtended();

            if (supplyGrid.Columns["RawItemID"] != null) supplyGrid.Columns["RawItemID"].Visible = false;
            if (supplyGrid.Columns["RawSupplierID"] != null) supplyGrid.Columns["RawSupplierID"].Visible = false;
            if (supplyGrid.Columns["RawDate"] != null) supplyGrid.Columns["RawDate"].Visible = false;
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

        private void refreshSupply_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void addSupply_Click(object sender, EventArgs e)
        {
            AddSupplyForm addForm = new AddSupplyForm();

            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshData();
            }
        }

        private void updateSupply_Click(object sender, EventArgs e)
        {
            if (supplyGrid.SelectedCells.Count > 0)
            {
                int rowIndex = supplyGrid.SelectedCells[0].RowIndex;
                var row = supplyGrid.Rows[rowIndex].DataBoundItem;

                if (row != null)
                {
                    long itemId = Convert.ToInt64(row.GetType().GetProperty("RawItemID").GetValue(row, null));
                    long supplierId = Convert.ToInt64(row.GetType().GetProperty("RawSupplierID").GetValue(row, null));
                    DateTime date = (DateTime)row.GetType().GetProperty("RawDate").GetValue(row, null);

                    using (var db = new SQLiteConnection(_dbPath, storeDateTimeAsTicks: false))
                    {
                        var selectedSupply = db.Table<Supply>().ToList().FirstOrDefault(s =>
                            s.ItemID == itemId &&
                            s.SupplierID == supplierId &&
                            s.Date.ToString("g") == date.ToString("g"));

                        if (selectedSupply != null)
                        {
                            AddSupplyForm editForm = new AddSupplyForm(selectedSupply);
                            if (editForm.ShowDialog(this) == DialogResult.OK)
                            {
                                RefreshData();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена в базе данных для редактирования.", "Ошибка поиска");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите поставку для редактирования!", "Внимание");
            }
        }

        private void removeSupply_Click(object sender, EventArgs e)
        {
            if (supplyGrid.SelectedRows.Count > 0 || supplyGrid.SelectedCells.Count > 0)
            {
                int rowIndex = supplyGrid.SelectedCells[0].RowIndex;
                var row = supplyGrid.Rows[rowIndex].DataBoundItem;

                if (row != null)
                {
                    var itemId = (long)row.GetType().GetProperty("RawItemID").GetValue(row, null);
                    var supplierId = (long)row.GetType().GetProperty("RawSupplierID").GetValue(row, null);
                    var date = (DateTime)row.GetType().GetProperty("RawDate").GetValue(row, null);

                    var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using (var db = new SQLiteConnection(_dbPath, storeDateTimeAsTicks: false))
                        {
                            db.Execute("DELETE FROM Supply WHERE ItemID = ? AND SupplierID = ? AND Date = ?",
                                        itemId, supplierId, date);
                        }
                        RefreshData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите поставку для удаления!", "Внимание");
            }
        }

        
    }
}
