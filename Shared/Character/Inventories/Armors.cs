using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace DND.Character.Inventories
{
    public class Armors
    {
        readonly List<Armor> armors;

        public Armors()
        {
             armors = GetAllArmors();
        }
        public List<Armor> AllArmors { get => armors; }
        public Armor GetArmor(int id)
        {
            for (int i = 0; i < armors.Count; i++)
            {
                if (armors[i].Id == id) return armors[i];
            }
            throw new Exception("item not found");
        }

        public static void SaveArmors(List<Armor> armors)
        {
            XMLDataProc.WriteList("Character\\Inventories\\Armors", armors);
        }
        
        private List<Armor> GetAllArmors()
        {
            return (List<Armor>)XMLDataProc.ReadList("Character\\Inventories\\Armors",new List<Armor>());
        }
    }
}
