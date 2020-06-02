using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BynogameMobil.Models
{
    public class UrunItem
    {
        private string image;
        private string urunismi;
        private string urunFiyati;
        private string urundetay;
        public string ImageSource
        {
            get { return image; }
            set { image = value; }
        }
        public string UrunDetayi
        {
            get { return urundetay; }
            set { urundetay = value; }
        }
        public string Urunismi
        {
            get { return urunismi; }
            set { urunismi = value; }
        }
        public string UrunFiyati
        {
            get { return urunFiyati; }
            set { urunFiyati = value; }
        }
    }
}
