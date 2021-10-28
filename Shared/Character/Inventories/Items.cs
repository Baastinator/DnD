using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace DND.Character.Inventories
{
    public class Items
    {
        readonly List<Item> items;
        public Items()
        {
             items = GetAllItems();
        }
        public List<Item> AllItems { get => items; }
        public Item GetItem(int id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id) return items[i];
            }
            throw new Exception("item not found");
        }

        public static void SaveItems(List<Item> items, bool srcMode = false)
        {
            string path = "Character\\Inventories\\Items";
            string srcPath = "..\\..\\..\\..\\Shared\\Character\\Inventories\\Items";
            if (srcMode)
            {
                XMLDataProc.WriteList(srcPath, items);
            }
            XMLDataProc.WriteList(path, items);
        }

        private List<Item> GetAllItems()
        {
            return (List<Item>)XMLDataProc.ReadList("Character\\Inventories\\Items",new List<Item>());
        }
    }
}
