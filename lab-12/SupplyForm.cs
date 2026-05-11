using lab_12.Data;

namespace lab_12
{
    public partial class SupplyForm : Form
    {
        private readonly SupplyContext _db = new SupplyContext();

        public SupplyForm()
        {
            InitializeComponent();
            LoadData();
            LoadSupplyData();
        }

        private void LoadData()
        {
            itemGrid.DataSource = _db.Items.ToList();

            if (itemGrid.Columns.Count > 0)
            {
                itemGrid.Columns["Id"].HeaderText = "Артикул";
                itemGrid.Columns["Name"].HeaderText = "Наименование";
                itemGrid.Columns["Manufacturer"].HeaderText = "Производитель";
                itemGrid.Columns["Price"].HeaderText = "Стоимость";
            }
        }

        private void LoadSupplyData()
        {
            using (var db = new SupplyContext())
            {
                supplyGrid.DataSource = db.Supplies
                    .Select(s => new
                    {
                        Дата = s.Date,
                        Поставщик = s.Supplier.Name,
                        Артикул = s.ItemId,
                        Товар = s.Item.Name,
                        Объем = s.Volume,
                        Итого = (s.Volume ?? 0) * s.Item.Price
                    }).ToList();
            }
        }

        private void refreshItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddItemForm addForm = new AddItemForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void removeItem_Click(object sender, EventArgs e)
        {
            if (itemGrid.SelectedCells.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот элемент?",
                    "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var rowIndex = itemGrid.SelectedCells[0].RowIndex;
                        int itemId = (int)itemGrid["Id", rowIndex].Value;

                        using (var db = new SupplyContext())
                        {
                            var item = db.Items.FirstOrDefault(x => x.Id == itemId);
                            if (item != null)
                            {
                                db.Items.Remove(item);
                                db.SaveChanges();
                            }
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении!");
                    }
                }
            }
        }

    }
}
