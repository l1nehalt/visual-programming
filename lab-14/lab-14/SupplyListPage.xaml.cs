using lab_14.Entities;
using System;
using System.Linq;
using Xamarin.Forms;

namespace lab_14
{
    public partial class SupplyListPage : ContentPage
    {
        public SupplyListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var supplies = App.Database.GetSupplies();
            var items = App.Database.GetItems();
            var suppliers = App.Database.GetSuppliers();

            var fullSupplyInfo = supplies.Select(s =>
            {
                var item = items.FirstOrDefault(i => i.Id == s.ItemId);
                var supplier = suppliers.FirstOrDefault(i => i.Id == s.SupplierId);

                decimal totalPrice = item != null ? item.Price * s.Volume : 0;

                return new SupplyDisplayModel
                {
                    OriginalSupply = s,
                    DisplayInfo = $"Поставка от: {supplier.Name}\nТовар: {item.Name}\nОбщая стоимость: {totalPrice} руб."
                };
            }).ToList();

            supplyList.ItemsSource = fullSupplyInfo;
        }

        private async void OnSupplySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            
            if (e.SelectedItem is SupplyDisplayModel clickedModel)
            {
                var page = new SupplyPage();
                page.BindingContext = clickedModel.OriginalSupply;
                await Navigation.PushAsync(page);
            }

            ((ListView)sender).SelectedItem = null;
        }

        private async void CreateSupply(object sender, EventArgs e)
        {
            var page = new SupplyPage();
            page.BindingContext = new Supply();
            await Navigation.PushAsync(page);
        }
    }
}