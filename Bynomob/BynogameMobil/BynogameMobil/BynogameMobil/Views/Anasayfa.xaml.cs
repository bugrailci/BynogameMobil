using BynogameMobil.Models;
using BynogameMobil.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BynogameMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Anasayfa : ContentPage
    {
        public Anasayfa()
        {
            InitializeComponent();
            UrunModel UrunModel;
            List<string> ReklamCarouseItems = new List<string>()
            {
                "https://cdn.bynogame.com/site-images/banners/csgo_bize_sat_6.jpg",
                "https://cdn.bynogame.com/site-images/banners/bdo_ramazan_etkinlikleri.jpg",
                "https://cdn.bynogame.com/site-images/banners/tinder.jpg",
                "https://cdn.bynogame.com/site-images/banners/blutv_2.jpg",
                "https://cdn.bynogame.com/site-images/banners/buyuk_cekilis.jpg",
                "https://cdn.bynogame.com/site-images/banners/pubg_royale_pass_13.jpg"
            };
            UrunModel = new UrunModel(this);
            ReklamCarousel.ItemsSource = ReklamCarouseItems;
            ItemshopV.FlowItemsSource = new UrunModel(this).GetItems(10);
            BindableLayout.SetItemsSource(ItemshopH, new UrunModel(this).GetItems(15));
            BindingContext = UrunModel;
        }

        private async void ÜrünTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as UrunItem;
            await Navigation.PushAsync(new ÜrünSayfasi(content));
        }
        private async void ÜrünTapped2(object sender, EventArgs e)
        {
            var tappedItem = (StackLayout)sender;
            string ProductName = (tappedItem.Children[1] as Label).Text;
            await Navigation.PushAsync(new ÜrünSayfasi(new UrunModel(this).FindÜrünItemWithName(ProductName)));
        }
    }
}