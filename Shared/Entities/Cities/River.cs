using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
            {"SN", new River {ID = 2, Name = "South to North"}},
            {"WE", new River {ID = 3, Name = "West to East"}},
            {"EW", new River {ID = 4, Name = "East to West"}}
        };

        public static Dictionary<string, River> Curved = new Dictionary<string, River>
        {
            {"NW", new River {ID = 5, Name = "North to West"}},
            {"NE", new River {ID = 6, Name = "North to East"}},
            {"EN", new River {ID = 7, Name = "East to North"}},
            {"ES", new River {ID = 8, Name = "East to South"}},
            {"SE", new River {ID = 9, Name = "South to East"}},
            {"SW", new River {ID = 10, Name = "South To West"}},
            {"WS", new River {ID = 11, Name = "West to South"}},
            {"WN", new River {ID = 12, Name = "West to North"}}
        };

        public static Dictionary<string, River> Split = new Dictionary<string, River>
        {
            {"ESN", new River {ID = 13, Name = "East and South to North"}},
            {"EWN", new River {ID = 14, Name = "East and West to North"}},
            {"SWN", new River {ID = 15, Name = "South and West to North"}},
            {"SWE", new River {ID = 16, Name = "South and West to East"}},
            {"SNE", new River {ID = 17, Name = "South and North to East"}},
            {"WNE", new River {ID = 18, Name = "West and North to East"}},
            {"WNS", new River {ID = 19, Name = "West and North to South"}},
            {"WES", new River {ID = 20, Name = "West and East to South"}},
            {"NES", new River {ID = 21, Name = "North and East to South"}},
            {"NEW", new River {ID = 22, Name = "North and East to West"}},
            {"NSW", new River {ID = 23, Name = "North and South to West"}},
            {"ESW", new River {ID = 24, Name = "East and South to West"}}
        };

        public static River[] Rivers => rivers();

        private static River[] rivers()
        {
            var rivers = new List<River> {None};
            foreach (var river in Straight)
            {
                rivers.Add(river.Value);
            }

            foreach (var river in Curved)
            {
                rivers.Add(river.Value);
            }

            foreach (var river in Split)
            {
                rivers.Add(river.Value);
            }

            return rivers.ToArray();
        }
    }
}
