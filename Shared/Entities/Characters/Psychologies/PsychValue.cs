

namespace DND.Shared.Entities.Characters.Psychologies
{
    public class PsychValue : INameable
    {
        private double _value;

        public double Value
        {
            get => _value;
            set
            {
                if (value > 10.0d)
                {
                    _value = 10.0d;
                }
                else if (value < -10.0d)
                {
                    _value = -10.0d;
                }
                else
                {
                    _value = value;
                }
            }
        }

        public PsychValue()
        {
            Value = 0.0d;
        }
        public static PsychValue[] Values => values;

        public static PsychValue Law = new PsychValue { ID = 0, Name = "Law" };
        public static PsychValue Loyalty = new PsychValue { ID = 1, Name = "Loyalty" };
        public static PsychValue Family = new PsychValue { ID = 2, Name = "Family" };
        public static PsychValue Friendship = new PsychValue { ID = 3, Name = "Friendship" };
        public static PsychValue Power = new PsychValue { ID = 4, Name = "Power" };
        public static PsychValue Truth = new PsychValue { ID = 5, Name = "Truth" };
        public static PsychValue Cunning = new PsychValue { ID = 6, Name = "Cunning" };
        public static PsychValue Eloquence = new PsychValue { ID = 7, Name = "Eloquence" };
        public static PsychValue Fairness = new PsychValue { ID = 8, Name = "Fairness" };
        public static PsychValue Decorum = new PsychValue { ID = 9, Name = "Decorum" };
        public static PsychValue Tradition = new PsychValue { ID = 10, Name = "Tradition" };
        public static PsychValue Whimsey = new PsychValue { ID = 11, Name = "Whimsey" };
        public static PsychValue Artwork = new PsychValue { ID = 12, Name = "Artwork" };
        public static PsychValue Cooperation = new PsychValue { ID = 13, Name = "Cooperation" };
        public static PsychValue Preservation = new PsychValue { ID = 14, Name = "Preservation" };
        public static PsychValue Stoicism = new PsychValue { ID = 15, Name = "Stoicism" };
        public static PsychValue SelfControl = new PsychValue { ID = 16, Name = "Self-Control" };
        public static PsychValue Harmony = new PsychValue { ID = 17, Name = "Harmony" };
        public static PsychValue Merriment = new PsychValue { ID = 18, Name = "Merriment" };
        public static PsychValue MartialProwess = new PsychValue { ID = 19, Name = "Martial Prowess" };
        public static PsychValue Skill = new PsychValue { ID = 20, Name = "Skill" };
        public static PsychValue HardWork = new PsychValue { ID = 21, Name = "Hard Work" };
        public static PsychValue Sacrafice = new PsychValue { ID = 22, Name = "Sacrafice" };
        public static PsychValue Competition = new PsychValue { ID = 23, Name = "Competition" };
        public static PsychValue Perseverance = new PsychValue { ID = 24, Name = "Perseverance" };
        public static PsychValue Romance = new PsychValue { ID = 25, Name = "Romance" };
        public static PsychValue Nature = new PsychValue { ID = 26, Name = "Nature" };
        public static PsychValue Peace = new PsychValue { ID = 27, Name = "Peace" };
        public static PsychValue Knowledge = new PsychValue { ID = 28, Name = "Knowledge" };
        private static readonly PsychValue[] values =
        {
            Law, Loyalty, Family, Friendship, Power, Truth, Cunning, Eloquence, Fairness, Decorum, Tradition,
            Whimsey, Artwork, Cooperation, Preservation, Stoicism, SelfControl, Harmony, Merriment, MartialProwess,
            Skill, HardWork, Sacrafice, Competition, Perseverance, Romance, Nature, Peace, Knowledge
        };
    }
}
 