using System;
using System.Collections.Generic;
using System.Text;
using DND.Character;

namespace DND_Character
{
    public class Character
    {
        public Statblock Stats { get; set; }
        public Psychology Psychology { get; set; }
        public Appearance Appearance { get; set; }

        public Character()
        {
            Stats = new Statblock(); 
            Psychology = new Psychology();
            Appearance = new Appearance();
        }
    }
}
