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
        UrunModel UrunModel;
        public Anasayfa()
        {
            InitializeComponent();
            List<string> ReklamCarouseItems = new List<string>()
            {
                "https://cdn.bynogame.com/site-images/banners/bdo_ramazan_etkinlikleri.jpg",
                "https://cdn.bynogame.com/site-images/banners/tinder.jpg",
                "https://cdn.bynogame.com/site-images/banners/blutv_2.jpg",
                "https://cdn.bynogame.com/site-images/banners/buyuk_cekilis.jpg",
                "https://cdn.bynogame.com/site-images/banners/pubg_royale_pass_13.jpg"

            };
            ReklamCarousel.ItemsSource = ReklamCarouseItems;
            UrunModel = new UrunModel(this);
            BindingContext = UrunModel;
        }
    }
}