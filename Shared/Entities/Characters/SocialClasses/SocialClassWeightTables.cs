
namespace DND.Shared.Entities.Characters.SocialClasses
{
    public static class SocialClassWeightTables
    {

        public static int[] Rural =
        {
            100, 3
        };

        public static int[] City =
        {
            0, 0, 100, 30, 7,   3, 1, 0, 10, 0
        };

        public static int[] Army =
        {
            0, 0, 0, 0, 0,   10, 0, 0, 50, 0
        };

        public static int[] Navy =
        {
            0, 0, 0, 0, 0,   0, 0, 0, 0, 100
        };

        public static int[][] ClassWeights =
        {
            Rural, City, Army, Navy
        };
    }
}
