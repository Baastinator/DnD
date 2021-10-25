using System;
using System.Collections.Generic;
using System.Text;

namespace DND
{
    public class Character
    {
        private Statblock stats;
        private Inventory inventory;
        private Psychology psychology;

        public Statblock Stats { get => stats;  set { stats = value; } }
        public Inventory Inventory { get => inventory; set { inventory = value; } }
        public Psychology Psychology { get => psychology; set { psychology = value; } }

        public Character()
        {
            Stats = new Statblock();
        }
    }
}
