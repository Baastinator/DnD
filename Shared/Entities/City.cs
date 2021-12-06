using System;
using System.Collections.Generic;
using System.Text;

namespace DND.Shared.Entities
{
    public class City
    {
        public Dictionary<string, List<Character>> People = new Dictionary<string, List<Character>>()
        {
            {"Mayor",null},
            {"General",null},
            {"Court",new List<Character>()}
        };
        public int Population;
    }
}
