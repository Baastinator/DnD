
namespace DND.Shared.Entities.Characters.Appearances
{
    public class ClothingType : INameable
    {
        public static ClothingType[] Clothing => clothing;

        public static ClothingType Rags = new ClothingType { ID = 0, Name = "Rags" };
        public static ClothingType Standard = new ClothingType { ID = 1, Name = "Standard Clothes" };
        public static ClothingType Fine = new ClothingType { ID = 2, Name = "Fine Clothes" };

        private static readonly ClothingType[] clothing = new[]
        {
            Rags, Standard, Fine
        };
    }
}
