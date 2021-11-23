using System.ComponentModel.Design;
using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Characters.Appearances
{
    public class EyeColor : Nameable
    {
        public static EyeColor Gray = new EyeColor {ID = 0, Name = "Gray"};
        public static EyeColor Blue = new EyeColor {ID = 1, Name = "Blue"};
        public static EyeColor Green = new EyeColor {ID = 2, Name = "Green"};
        public static EyeColor Brown = new EyeColor {ID = 3, Name = "Brown"};
        public static EyeColor Amber = new EyeColor {ID = 4, Name = "Amber"};
        public static EyeColor Hazel = new EyeColor {ID = 5, Name = "Hazel"};
        public static EyeColor Red = new EyeColor {ID = 6, Name = "Red"};

        public static EyeColor[] EyeColors =
        {
            Gray, Blue, Green, Brown, Amber, Hazel, Red
        };
    }
}
