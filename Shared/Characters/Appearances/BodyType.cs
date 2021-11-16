
namespace DND.Characters.Appearances
{
    public class BodyType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static BodyType[] BodyTypes => bodyTypes;

        public static BodyType Skinny = new BodyType { ID = 0, Name = "Skinny" };
        public static BodyType Plump = new BodyType { ID = 1, Name = "Plump" };
        public static BodyType Chubby = new BodyType { ID = 2, Name = "Chubby" };
        public static BodyType Slim = new BodyType { ID = 3, Name = "Slim" };
        public static BodyType Average = new BodyType { ID = 4, Name = "Average" };
        public static BodyType Stocky = new BodyType { ID = 5, Name = "Stocky" };
        public static BodyType Lean = new BodyType { ID = 6, Name = "Lean" };
        public static BodyType Defined = new BodyType { ID = 7, Name = "Defined" };
        public static BodyType Bulky = new BodyType { ID = 8, Name = "Bulky" };
        private static readonly BodyType[] bodyTypes =
        {
            Skinny, Plump, Chubby, Slim, Average,
            Stocky, Lean, Defined, Bulky
        };
    }
}
