using System;
using System.Collections.Generic;
using System.Text;

namespace DND.Character.Inventories
{
    public class Weapon
    {
        public int Id { get; set; }
        public int DiceSize { get; set; }
        public int DiceAmount { get; set; }
        public string Name { get; set; }
        public string Dice { get => DiceAmount + "d" + DiceSize; }

    }
}
    