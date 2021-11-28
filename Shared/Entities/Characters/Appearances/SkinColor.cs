﻿using System.Collections.Generic;
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

        public static SkinColor TfRed = new SkinColor {ID = 3, Name = "Red"};
        public static SkinColor TfPurple = new SkinColor {ID = 4, Name = "Purple"};
        public static SkinColor TfOrange = new SkinColor {ID = 5, Name = "Orange"};

        #endregion
        #region Goblinoid

        public static SkinColor GLightGreen = new SkinColor {ID = 6, Name = "Light Green"};
        public static SkinColor GDarkGreen = new SkinColor {ID = 7, Name = "Dark Green"};

        #endregion
        #region Dragonborn

        public static SkinColor DBrass = new SkinColor {ID = 8, Name = "Brass"};
        public static SkinColor DBronze = new SkinColor {ID = 9, Name = "Bronze"};

        #endregion

        public static SkinColor Goliath = new SkinColor {ID = 10, Name = "Gray"};

        #region Tabaxi

        public static SkinColor TaBrown = new SkinColor {ID = 11, Name = "Brown"};
        public static SkinColor TaYellow = new SkinColor {ID = 11, Name = "Yellow"};

        #endregion

        public static SkinColor Warforged = new SkinColor {ID = 11, Name = "Steel"};

        public static Dictionary<string, SkinColor[]> SkinColors = new Dictionary<string, SkinColor[]>
        {
            {"Humanoid", new[] {HLight, HPale, HDark}},
            {"Tiefling", new[] {TfRed, TfPurple, TfOrange}},
            {"Goblinoid", new[] {GLightGreen, GDarkGreen}},
            {"Dragonborn", new[] {DBrass, DBronze}},
            {"Goliath", new[] {Goliath}},
            {"Tabaxi", new[] {TaBrown, TaYellow}},
            {"Warforged", new[] {Warforged}}
        };

        public static SkinColor[] skinColors =
        {
            HLight, HPale, HDark, TfRed, TfPurple, TfOrange, GLightGreen, GDarkGreen, DBrass, DBrass, Goliath, TaBrown,
            TaYellow, Warforged
        };
    }
}
