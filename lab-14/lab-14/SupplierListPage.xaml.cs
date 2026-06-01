using lab_14.Entities;
using System;
using Xamarin.Forms;

namespace lab_14
{
    public partial class SupplierListPage : ContentPage
    {
        public SupplierListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            supplierList.ItemsSource = App.Database.GetSuppliers();
            base.OnAppearing();
        }

        private async void OnSupplierSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var selected = (Supplier)e.SelectedItem;

            var page = new SupplierPage();
            page.BindingContext = selected;
            await Navigation.PushAsync(page);
            ((ListView)sender).SelectedItem = null;
        }

        private async void CreateSupplier(object sender, EventArgs e)
        {
            var page = new SupplierPage();
            page.BindingContext = new Supplier();
            await Navigation.PushAsync(page);
        }
    }
}