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
    public partial class CSGOSkinPage : ContentPage
    {
        UrunModel UrunModel;
        public CSGOSkinPage()
        {
            InitializeComponent();
            UrunModel = new UrunModel(this);
            ItemshopV.FlowItemsSource = new UrunModel(this).GetItems(50);
            BindingContext = UrunModel;
        }
        private async void ÜrünTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as UrunItem;
            await Navigation.PushAsync(new ÜrünSayfasi(content));
        }
    }
}