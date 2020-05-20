using BynogameMobil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace BynogameMobil.ViewModels
{
    public class UrunModel : BindableObject
    {
        private Page Page;

        public UrunModel(Page mainPage)
        {
            this.Page = mainPage;
            AddItems();
        }

        private void AddItems()
        {
            for (int i = 0; i < 8; i++)
            {
                UrunItem urunitem = new UrunItem()
                {
                    ImageSource = "https://cdn.bynogame.com/site-images/pazar/gorsel/oyun_parasi/knight_online_steam_ko_gb.jpg",
                    Urunismi = string.Format("Urunismi {0}", i),
                    UrunFiyati= string.Format("UrunFiyati {0}", i)
                };
                Items.Add(urunitem);
            }

        }

        private ObservableCollection<UrunItem> _items = new ObservableCollection<UrunItem>();
        public ObservableCollection<UrunItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        public Command ItemTappedCommand
        {
            get
            {
                return new Command((data) =>
                {
                    Page.DisplayAlert("FlowListView", data + "", "Ok");
                });
            }
        }
    }
}
