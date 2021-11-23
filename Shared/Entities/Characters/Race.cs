using System.Runtime.InteropServices.ComTypes;
using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Characters
{
    public class Race : Nameable
    {
        public int[] StatBonus { get; set; }
        public string SkinType { get; set; }
        public static Race[] Races => races;


        public static Race Human = new Race {ID = 0, Name = "Human", StatBonus = new[] {1, 1, 1, 1, 1, 1}};

        public static Race Elf = new Race {ID = 1, Name = "Elf", StatBonus = new[] {0, 2, 0, 1, 0, 0}};

        public static Race Dwarf = new Race {ID = 2, Name = "Dwarf", StatBonus = new[] {0, 0, 2, 0, 0, 0}};

        public static Race HalfElf = new Race {ID = 3, Name = "HalfElf", StatBonus = new[] {0, 1, 0, 0, 1, 2}};

        public static Race Gnome = new Race {ID = 4, Name = "Gnome", StatBonus = new[] {0, 0, 1, 2, 0, 0}};

        public static Race HalfOrc = new Race {ID = 5, Name = "Half-Orc", StatBonus = new[] {2, 0, 1, 0, 0, 0}};

        public static Race Halfling = new Race {ID = 6, Name = "Halfling", StatBonus = new[] {0, 2, 0, 0, 0, 0}};

        public static Race Dragonborn = new Race {ID = 7, Name = "Dragonborn", StatBonus = new[] {2, 0, 0, 0, 0, 1}};

        public static Race Tiefling = new Race {ID = 8, Name = "Tiefling", StatBonus = new[] {0, 0, 0, 0, 0, 2}};

        public static Race Goliath = new Race {ID = 9, Name = "Goliath", StatBonus = new[] {2, 0, 1, 0, 0, 0}};

        public static Race Tabaxi = new Race {ID = 10, Name = "Tabaxi", StatBonus = new[] {0, 0, 2, 0, 0, 1}};

        public static Race Aarakocra = new Race {ID = 11, Name = "Aarakocra", StatBonus = new[] {0, 2, 0, 0, 1, 0}};

        public static Race Kenku = new Race {ID = 12, Name = "Kenku", StatBonus = Aarakocra.StatBonus};

        public static Race Tortle = new Race {ID = 13, Name = "Tortle", StatBonus = new[] {2, 0, 0, 0, 1, 0}};

        public static Race Triton = new Race {ID = 14, Name = "Triton", StatBonus = new[] {1, 0, 1, 0, 0, 1}};

        public static Race Bugbear = new Race {ID = 15, Name = "Bugbear", StatBonus = new[] {2, 1, 0, 0, 0, 0}};

        public static Race Goblin = new Race {ID = 16, Name = "Goblin", StatBonus = new[] {0, 2, 1, 0, 0, 0}};

        public static Race Hobgoblin = new Race {ID = 17, Name = "Hobgoblin", StatBonus = new[] {0, 0, 2, 1, 0, 0}};

        public static Race Kobold = new Race {ID = 18, Name = "Kobold", StatBonus = Halfling.StatBonus};

        public static Race Lizardfolk = new Race {ID = 19, Name = "Lizardfolk", StatBonus = new[] {0, 0, 2, 0, 1, 0}};

        public static Race Orc = new Race {ID = 20, Name = "Orc", StatBonus = Goliath.StatBonus};

        public static Race YuanTi = new Race {ID = 21, Name = "Yuan-Ti", StatBonus = new[] {0, 0, 0, 1, 0, 2}};

        public static Race Changeling = new Race {ID = 22, Name = "Changeling", StatBonus = new[] {0, 1, 0, 0, 0, 2}};

        public static Race Warforged = new Race {ID = 23, Name = "Warforged", StatBonus = Hobgoblin.StatBonus};

        private static readonly Race[] races =
        {
            Human, Elf, Dwarf, HalfElf, Gnome, HalfOrc, Halfling, Dragonborn, Tiefling, Goliath, Tabaxi, Aarakocra,
            Kenku, Tortle, Triton, Bugbear, Goblin, Hobgoblin, Kobold, Lizardfolk, Orc, YuanTi, Changeling, Warforged
        };
    }
}
