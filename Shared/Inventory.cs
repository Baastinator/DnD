using System;
using System.Collections.Generic;
using System.Text;

namespace DND
{
    public class Inventory
    {
        private List<Item> _items;
        private List<Weapon> _weapons;
        private List<Armor> _armor;
        public List<Item> Items { get => _items; set { _items = value; } }
        public List<Weapon> Weapons { get => _weapons; set { _weapons = value; } }
        public List<Armor> Armor { get => _armor; set { _armor = value; } }
    }
}
