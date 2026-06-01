using lab_14.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace lab_14
{
    public partial class SupplyPage : ContentPage
    {
        private List<Supplier> _suppliers;
        private List<Item> _items;
        private Supply _currentSupply;

        public SupplyPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _suppliers = App.Database.GetSuppliers().ToList();
            _items = App.Database.GetItems().ToList();

            supplierPicker.ItemsSource = _suppliers;
            itemPicker.ItemsSource = _items;

            _currentSupply = BindingContext as Supply;

            if (_currentSupply == null || _currentSupply.Id == 0)
            {
                _currentSupply = new Supply();
                btnDelete.IsVisible = false; 
            }
            else
            {
                supplierPicker.SelectedItem = _suppliers.FirstOrDefault(s => s.Id == _currentSupply.SupplierId);
                itemPicker.SelectedItem = _items.FirstOrDefault(i => i.Id == _currentSupply.ItemId);
                entryVolume.Text = _currentSupply.Volume.ToString();
                btnDelete.IsVisible = true;
            }
        }

        private async void SaveSupply_Clicked(object sender, EventArgs e)
        {
            var selectedSupplier = (Supplier)supplierPicker.SelectedItem;
            var selectedItem = (Item)itemPicker.SelectedItem;

            if (selectedSupplier == null)
            {
                await DisplayAlert("Внимание", "Выберите поставщика из списка!", "OK");
                return;
            }
            if (selectedItem == null)
            {
                await DisplayAlert("Внимание", "Выберите товар из списка!", "OK");
                return;
            }
            if (!int.TryParse(entryVolume.Text, out int volume) || volume <= 0)
            {
                await DisplayAlert("Внимание", "Введите корректный объем поставки (больше 0)!", "OK");
                return;
            }

            _currentSupply.SupplierId = selectedSupplier.Id;
            _currentSupply.ItemId = selectedItem.Id;
            _currentSupply.Volume = volume;
            _currentSupply.Date = DateTime.Now;

            try
            {
                App.Database.SaveSupply(_currentSupply);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка БД", ex.Message, "OK");
            }
        }

        private async void DeleteSupply_Clicked(object sender, EventArgs e)
        {
            if (_currentSupply != null && _currentSupply.Id != 0)
            {
                App.Database.DeleteSupply(_currentSupply.Id);
            }
            await Navigation.PopAsync();
        }
    }
}