using lab_14.Entities;
using System;
using Xamarin.Forms;

namespace lab_14
{
    public partial class ItemListPage : ContentPage
    {
        public ItemListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            itemList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            Item selectedItem = (Item)e.SelectedItem;
            ItemPage itemPage = new ItemPage();
            itemPage.BindingContext = selectedItem;
            await Navigation.PushAsync(itemPage);

            ((ListView)sender).SelectedItem = null;
        }

        private async void CreateItem(object sender, EventArgs e)
        {
            Item item = new Item();
            ItemPage itemPage = new ItemPage();
            itemPage.BindingContext = item;
            await Navigation.PushAsync(itemPage);
        }
    }
}