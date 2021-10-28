using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using DND.Character.Inventories;

namespace DND.Character
{
    public class Inventory
    {
        public List<Item> Items { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armor { get; set; }

        public Inventory()
        {
            Items = new List<Item>();
            Weapons = new List<Weapon>();
            Armor = new List<Armor>();
        }
    }
}
