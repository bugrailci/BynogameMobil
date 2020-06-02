using BynogameMobil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using BynogameMobil.Data;
using BynogameMobil.Views;
using Xamarin.Forms;

namespace BynogameMobil.ViewModels
{
    public class UrunModel : BindableObject
    {
        private Page Page;
        RestAPI RestAPI;
        public UrunModel(Page mainPage)
        {
            this.Page = mainPage;
            RestAPI = new RestAPI();
            //AddItems();
        }

        public UrunItem FindÜrünItemWithName(string Name)
        {
            UrunItem urunItem = new UrunItem();
            foreach (var item in RestAPI.GetProducts())
            {
                if (Name == item.Name)
                {
                    urunItem = new UrunItem()
                    {
                        ImageSource = item.Url,
                        Urunismi = item.Name,
                        UrunDetayi = item.Info,
                        UrunFiyati = item.Cost.ToString()

                    };
                    break;
                }
            }
            return urunItem;
        }
        public ObservableCollection<UrunItem> GetItems(int numberOfItem)
        {
            ObservableCollection<UrunItem> Items = new ObservableCollection<UrunItem>();
            foreach (var item in RestAPI.GetProducts())
            {

                UrunItem urunItem = new UrunItem()
                {
                    ImageSource = item.Url,
                    Urunismi = item.Name,
                    UrunDetayi = item.Info,
                    UrunFiyati = item.Cost.ToString()

                };
                Items.Add(urunItem);
                if (Items.Count == numberOfItem)
                {
                    break;
                }

            }
            return Items;
        }

        public ObservableCollection<UrunItem> GetAllItems()
        {
            ObservableCollection<UrunItem> Items = new ObservableCollection<UrunItem>();

            foreach (var item in RestAPI.GetProducts())
            {

                UrunItem urunItem = new UrunItem()
                {
                    ImageSource = item.Url,
                    Urunismi = item.Name,
                    UrunDetayi = item.Info,
                    UrunFiyati = item.Cost.ToString()

                };
                Items.Add(urunItem);

            }
            return Items;
        }
    }
}
