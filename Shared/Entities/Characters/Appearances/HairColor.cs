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

        public static HairColor[] HairColors =
        {
            Brown, Blond, Black, Red, Purple, Ginger, Gray
        };
    }
}
