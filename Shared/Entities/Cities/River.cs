using System;
using System.Collections.Generic;
using System.Text;
using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Cities
{
    public class River : Nameable
    {
        public static River None = new River {ID = 0, Name = "No River"};

        public static Dictionary<string, River> Straight = new Dictionary<string, River>
        {
            {"NS", new River {ID = 1, Name = "North to South"}},
            {"SN", new River{ID = 2, Name = "South to North"}},
        };
    }
}
