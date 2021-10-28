using System;
using System.Collections.Generic;
using System.Text;

namespace DND.Character.Inventories
{
    public static class Adder
    {
        public static void ItemAdder(string itemName, bool debugMode)
        {
            List<Item> items;
            try
            {
                bool existsAlready = false;
                items = new Items().AllItems;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Name == itemName) existsAlready = true;
                }
                if (!existsAlready)
                {
                    Item item = new Item() { Id = items.Count + 1 , Amount = 0, Name = itemName};
                    items.Add(item);
                }
            }
            catch (Exception)
            {
                items = new List<Item>()
                {
                    new Item(){Id = 1, Name = itemName, Amount = 0}
                };
            }
            Items.SaveItems(items, debugMode);
        }
        public static void WeaponAdder(Weapon weapon)
        {


        }
        public static void ArmorAdder(Armor armor)
        {
            List<Armor> armors = new Armors().AllArmors;
            armors.Add(armor);
            Armors.SaveArmors(armors);
        }
    }
}
