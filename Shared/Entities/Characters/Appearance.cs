using DND.Shared.Entities.Characters.Appearances;

namespace DND.Shared.Entities.Characters
{
    public class Appearance
    {
        public int MuscleMass { get; set; }
        public int BodySize { get; set; }
        public BodyType BodyType { get; set; }
        public ClothingType ClothingType { get; set; }
        public HairLength HairLength { get; set; }
        public SkinColor SkinColor { get; set; }
        public HairColor HairColor { get; set; }
        public EyeColor EyeColor { get; set; }
    }
}
