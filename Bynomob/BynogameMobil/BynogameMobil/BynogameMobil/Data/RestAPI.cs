﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;

namespace BynogameMobil.Data
{
    //Microsoft.AspNet.WebApi.Client nugetini nugetlerden indirmeyi unutmayın!
    public class RestAPI
    {
        HttpClient client;
        HttpResponseMessage response;
        public List<Product> Products;
        public List<Category> Categories;
        public RestAPI()
        {
            client = new HttpClient()
            {
                //Api urlnizi azurede yayınlama profilini aldığınız yerden alıp aşağıda değiştirebilirsiniz. 
                BaseAddress = new Uri("https://bynogamemobil.azurewebsites.net/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            GetData();
        }
        //Products verimi bu şekilde çektim
        public List<Product> GetProducts()
        {
            HttpResponseMessage response = client.GetAsync("api/products").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                Products = items as List<Product>;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Hata!", "Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase, "Tamam");
            }
            return Products;
        }

        public List<Category> GetCategories()
        {
            response = client.GetAsync("api/categories").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
                Categories = items as List<Category>;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Hata!", "Error Code" +
               response.StatusCode + " : Message - " + response.ReasonPhrase, "Tamam");
            }
            return Categories;
        }

        private void GetData()
        {

            GetCategories();
            GetProducts();
        }
        /// <summary>
        /// Aşağıda Apide var olan modelleri birebir aldık ve buraya yapıştırdık, Benim Image için fazladan bir kontrollerim vardı
        /// Onu producta birleştirmek için fazladan bir işlem yaptım,
        /// Ürünün görüntülerken sadece bir image kullanacağım için resim için bir ImageUrl yaptım eğer isterseniz side resimler birden
        /// fazla ise string listesi yazın.
        /// 
        /// </summary>
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public IList<Product> Products { get; set; } = new List<Product>();
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public EMarka Marka { get; set; }
            public double Cost { get; set; }
            public double PreviousCost { get; set; }
            public int CategoryId { get; set; }
            public string Url { get; set; }
            public int NumberInStock { get; set; }
            public string Info { get; set; }
            public double KargoFiyatı { get; set; }
            public Category Category { get; set; }


            public enum EMarka : byte
            {
                [Description("factorynew")]
                factorynew = 1,

                [Description("minimalwear")]
                minimalwear = 2,

                [Description("wellworn")]
                wellworn = 3,

                [Description("fieldtested")]
                fieldtested = 4,

                [Description("battlescarred")]
                battlescarred = 5,
            }
        }
    }
}
