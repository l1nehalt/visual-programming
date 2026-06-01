using lab_14.Entities;
using System;
using Xamarin.Forms;

namespace lab_14
{
    public partial class SupplierPage : ContentPage
    {
        public SupplierPage()
        {
            InitializeComponent();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            var supplier = (Supplier)BindingContext;
            if (!string.IsNullOrEmpty(supplier.Name))
            {
                App.Database.SaveSupplier(supplier);
            }
            await Navigation.PopAsync();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var supplier = (Supplier)BindingContext;
            if (supplier.Id != 0)
            {
                try
                {
                    App.Database.DeleteSupplier(supplier.Id);
                }
                catch
                {
                    await DisplayAlert("Ошибка", "Нельзя удалить поставщика, у которого есть активные поставки!", "OK");
                    return;
                }
            }
            await Navigation.PopAsync();
        }
    }
}