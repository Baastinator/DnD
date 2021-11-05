using System;
using System.Collections.Generic;
using System.Text;

namespace DND.Characters.Appearances
{
    public class BodyType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static BodyType[] BodyTypes => bodyTypes;

        publiy static BodyType  BodyType { ID = 1, Name = }
        private static readonly BodyType[] bodyTypes =
        {
        };
    }
}
