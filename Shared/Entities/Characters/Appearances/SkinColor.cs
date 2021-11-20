using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Characters.Appearances
{
    public class SkinColor : Nameable
    {
        #region Human

        public static SkinColor HLight = new SkinColor { ID = 0, Name = "Light" };
        public static SkinColor HPale = new SkinColor { ID = 1, Name = "Pale" };
        public static SkinColor HDark = new SkinColor { ID = 2, Name = "Dark" };

        #endregion

        #region Tiefling

        public static SkinColor TRed = new SkinColor {ID = 3, Name = "Red"};
        public static SkinColor TPurple = new SkinColor {ID = 4, Name = "Purple"};
        public static SkinColor TOrange = new SkinColor {ID = 5, Name = "Orange"};

        #endregion

        #region Greenish

        public static SkinColor GLightGreen = new SkinColor {ID = 6, Name = "Light Green"};
        public static SkinColor GDarkGreen = new SkinColor {ID = 7, Name = "Dark Green"};

        #endregion

        public static SkinColor[] SkinColors =
        {
            HLight, HPale, HDark, TRed, TPurple, TOrange, GLightGreen, GDarkGreen
        };
    }
}
