using System;
using System.Collections.Generic;

namespace CzterejPancerni
{
    internal class Equipment
    {
        public Dictionary<string, Item> Items { get; set; }
        public Equipment()
        {
            Items = new Dictionary<string, Item>()
            {
                { "Łopata", new Item("Łopata") },
                { "Karabin", new Item("Karabin") },
                { "Pistolet", new Item("Pistolet") },
                { "Mapa", new Item("Mapa") },
                { "Apteczka", new Item("Apteczka") },
            };
        }
        public void AddItem(Item item)
        {
            Items.Add(item.Name, item);
            Events.Add("+Item", item.Name);
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item.Name);
            Events.Add("-Item", item.Name);
        }
    }
}
