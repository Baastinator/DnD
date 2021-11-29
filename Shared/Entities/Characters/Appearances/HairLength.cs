using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Characters.Appearances
{
    public class HairLength : Nameable
    {
        public static HairLength Bald = new HairLength {ID = 0, Name = "Bald"};
        public static HairLength BuzzCut = new HairLength {ID = 1, Name = "Buzz Cut"};
        public static HairLength Short = new HairLength {ID = 2, Name = "Short"};
        public static HairLength NeckLength = new HairLength {ID = 3, Name = "Neck Length"};
        public static HairLength ShoulderLength = new HairLength {ID = 4, Name = "Shoulder Length"};
        public static HairLength ChestLength = new HairLength {ID = 5, Name = "Chest Length"};
        public static HairLength None = new HairLength {ID = 6, Name = "None"};

        public static HairLength[] HairLengths =
        {
            Bald, BuzzCut, Short, NeckLength, ShoulderLength, ChestLength, None
        };
    }
}
