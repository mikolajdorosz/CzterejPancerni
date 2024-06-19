using System;

namespace CzterejPancerni
{
    internal class Item : ObjectToGather
    {
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
        }
    }
}
