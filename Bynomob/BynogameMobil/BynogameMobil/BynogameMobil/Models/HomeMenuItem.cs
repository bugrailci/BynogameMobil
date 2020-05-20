using System;
using System.Collections.Generic;
using System.Text;

namespace BynogameMobil.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Oyunlar,
        KnightOnline,
        ItemSkin,
        Steam,
        Pazar,
        Destekle
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
