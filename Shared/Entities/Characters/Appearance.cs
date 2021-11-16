using DND.Shared.Entities.Characters.Appearances;

namespace DND.Shared.Entities.Characters
{
    public class Appearance
    {
        public int MuscleMass { get; set; }
        public int BodySize { get; set; }
        public BodyType BodyType { get; set; }
        public ClothingType ClothingType { get; set; }
    }
}
