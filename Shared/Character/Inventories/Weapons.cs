using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace DND.Character.Inventories
{
    public class Weapons
    {
        readonly List<Weapon> weapons;

        public Weapons()
        {
             weapons = GetAllWeapons();
        }
        public List<Weapon> AllWeapons { get => weapons; }
        public Weapon GetWeapon(int id)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].Id == id) return weapons[i];
            }
            throw new Exception("weapon not found");
        }

        public static void SaveWeapons(List<Weapon> weapons)
        {
            XMLDataProc.WriteList("Character\\Inventories\\Weapons", weapons);
        }

        private List<Weapon> GetAllWeapons()
        {
            return (List<Weapon>)XMLDataProc.ReadList("Character\\Inventories\\Weapons",new List<Weapon>());
        }
    }
}
