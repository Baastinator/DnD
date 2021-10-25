using System;
using System.Collections.Generic;
using System.Text;

namespace DND
{
    class Weapon
    {
        private int _diceN, _diceS;
        private string _name;
        public int DiceNumber { get => _diceN; set { _diceN = value; } }
        public int DiceSize { get => _diceS; set { _diceS = value; } }
        public string Name { get => _name; set { _name = value; } }
        public string DiceName { get => _diceN + "d" + _diceS; } 
    }
}
