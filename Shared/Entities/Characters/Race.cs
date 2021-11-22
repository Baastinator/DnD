using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Characters
{
    public class Race : Nameable
    {
        public int[] StatBonus { get; set; }
        public int[] SkinColorWeights { get; set; }
        public int[] HairColorWeights { get; set; }
        public int[] EyeColorWeights { get; set; }
        public static Race[] Races => races;

        private static int[] DefaultSkinWeights = {100, 30, 80, 0, 0, 0, 0, 0};
        private static int[] GreenSkinWeights = {0, 0, 0, 0, 0, 0, 50, 50};
        private static int[] TieflingSkinWeights = {30, 10, 30, 100, 30, 50, 0, 0};

        private static int[] DefaultHairColors = {30, 30, 30, 0, 0, 5, 0};
        private static int[] GreenHairColors = {30, 0, 100, 0, 0, 0, 10};
        private static int[] TieflingHairColors = {30, 0, 10, 50, 30, 0, 0};

        public Race()
        {
            SkinColorWeights = DefaultSkinWeights;
        }

        public static Race Human = new Race {ID = 0, Name = "Human", StatBonus = new[] {1, 1, 1, 1, 1, 1}};
        public static Race Elf = new Race {ID = 1, Name = "Elf", StatBonus = new[] {0, 2, 0, 1, 0, 0}};
        public static Race Dwarf = new Race {ID = 2, Name = "Dwarf", StatBonus = new[] {0, 0, 2, 0, 0, 0}};
        public static Race HalfElf = new Race {ID = 3, Name = "HalfElf", StatBonus = new[] {0, 1, 0, 0, 1, 2}};
        public static Race Gnome = new Race {ID = 4, Name = "Gnome", StatBonus = new[] {0, 0, 1, 2, 0, 0}};

        public static Race HalfOrc = new Race
            {ID = 5, Name = "HalfOrc", StatBonus = new[] {2, 0, 1, 0, 0, 0}, SkinColorWeights = GreenSkinWeights};
        public static Race Halfling = new Race {ID = 6, Name = "Halfling", StatBonus = new[] {0, 2, 0, 0, 0, 0}};

        public static Race Dragonborn = new Race {ID = 7, Name = "Dragonborn", StatBonus = new[] {2, 0, 0, 0, 0, 1}};

        public static Race Tiefling = new Race
            {ID = 8, Name = "Tiefling", StatBonus = new[] {0, 0, 0, 0, 0, 2}, SkinColorWeights = TieflingSkinWeights};
        public static Race Goliath = new Race {ID = 9, Name = "Goliath", StatBonus = new[] {2, 0, 1, 0, 0, 0}};
        public static Race Tabaxi = new Race {ID = 10, Name = "Tabaxi", StatBonus = new[] {0, 0, 2, 0, 0, 1}};
        public static Race Genasi = new Race {ID = 11, Name = "Genasi", StatBonus = new[] {0, 0, 2, 0, 0, 0}};
        public static Race Aarakocra = new Race {ID = 12, Name = "Aarakocra", StatBonus = new[] {0, 2, 0, 0, 1, 0}};
        public static Race Kenku = new Race {ID = 13, Name = "Kenku", StatBonus = new[] {0, 2, 0, 0, 1, 0}};

        private static readonly Race[] races =
        {
            Human, Elf, Dwarf, HalfElf, Gnome, HalfOrc, Halfling, Dragonborn, Tiefling, Goliath, Tabaxi, Genasi,
            Aarakocra, Kenku
        };
    }
}
