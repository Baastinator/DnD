using System;
using System.Collections.Generic;
using System.Text;

namespace DND
{
    class Character
    {
        private Statblock stats;
        private Inventory inventory;

        public Statblock Stats { get { return stats; } set { stats = value; } }
        public Inventory Inventory { get { return inventory; } set { inventory = value; } }

    }
}
