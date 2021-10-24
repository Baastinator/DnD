using System;
using System.Collections.Generic;
using System.Text;

namespace DND
{
    class Item
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }




    }
    static class Items
    {
        public static Item Empty = new Item() { Name = "empty"; };
    }
}
