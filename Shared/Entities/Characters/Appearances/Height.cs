using System;
using System.Collections.Generic;
using System.Text;

namespace DND.Shared.Entities.Characters.Appearances
{
    public class Height
    {
        private int _heightInch;
        public int HeightInch
        {
            get => _heightInch;
            set => _heightInch = value;
        }

        public string HeightStr => (int) Math.Floor(_heightInch / 12d) + "'" + (int) Math.Floor(_heightInch % 12d) + "\"";
    }
}
