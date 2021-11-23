using System.Collections.Generic;
using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Characters.Appearances
{
    public class HairColor : Nameable
    {
        public static HairColor Brown = new HairColor {ID = 0, Name = "Brown"};
        public static HairColor Blond = new HairColor {ID = 1, Name = "Blond"};
        public static HairColor Black = new HairColor {ID = 2, Name = "Black"};
        public static HairColor Red = new HairColor {ID = 3, Name = "Red"};
        public static HairColor Purple = new HairColor {ID = 4, Name = "Purple"};
        public static HairColor Ginger = new HairColor {ID = 5, Name = "Ginger"};
        public static HairColor Gray = new HairColor {ID = 6, Name = "Gray"};
        public static HairColor None = new HairColor {ID = 7, Name = "None"};

        public static Dictionary<string,HairColor[]> HairColors = new Dictionary<string, HairColor[]>
        {
            {"Humanoid",new []{Brown,Blond,Black,Ginger}},
            {"Goblinoid",new []{Brown,Black,Gray}},
            {"Tiefling",new []{Brown,Black,Red,Purple}}
        };

        public static HairColor[] hairColors =
        {
            Brown, Blond, Blond, Red, Purple, Ginger, Gray, None
        };
    }
}
