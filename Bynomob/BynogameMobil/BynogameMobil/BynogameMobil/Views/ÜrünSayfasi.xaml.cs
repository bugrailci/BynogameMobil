using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BynogameMobil.Models;
using BynogameMobil.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BynogameMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ÜrünSayfasi : ContentPage
    {
        UrunItem ÜrünBilgileri;
        public ÜrünSayfasi(UrunItem urunItem)
        {
            InitializeComponent();
            ÜrünBilgileri = urunItem;
            Image.Source = urunItem.ImageSource;
            Name.Text = urunItem.Urunismi;
            Detail.Text = urunItem.UrunDetayi;
            Cost.Text = urunItem.UrunFiyati;
        }
    }
}