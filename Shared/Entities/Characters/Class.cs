using DND.Shared.Interfaces;
using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Characters
{
    public class Class : Nameable
    {
        public int[] SavingThrowProficiencies { get; set; }
        public int[] SkillProficiencies { get; set; }
        public static Class[] Classes => classes;

        #region SkillProficiencies
        public static int[] PArtificer = {
            0, 0, 1,   0, 0, 0,   0, 0, 0,
            0, 0, 0,   0, 0, 0,   1, 0, 0,
        };
        public static int[] PBarbarian = {
            0, 0, 0,   1, 0, 0,   0, 1, 0,
            0, 0, 0,   0, 0, 0,   0, 0, 0,
        };
        public static int[] PBard = {
            0, 0, 0,   0, 0, 0,   1, 0, 0,
            0, 0, 0,   1, 1, 0,   0, 0, 0,
        };
        public static int[] PCleric = {
            0, 0, 0,   0, 0, 0,   0, 0, 0,
            1, 0, 0,   0, 0, 1,   0, 0, 0,
        };
        public static int[] PDruid = {
            0, 1, 0,   0, 0, 0,   0, 0, 0,
            0, 1, 0,   0, 0, 0,   0, 0, 0,
        };
        public static int[] PFighter = {
            0, 0, 0,   1, 0, 0,   0, 0, 0,
            0, 0, 1,   0, 0, 0,   0, 0, 0,
        };
        public static int[] PMonk = {
            1, 0, 0,   1, 0, 0,   0, 0, 0,
            0, 0, 0,   0, 0, 0,   0, 0, 0,
        };
        public static int[] PPaladin = {
            0, 0, 0,   1, 0, 0,   0, 0, 0,
            0, 0, 0,   0, 0, 1,   0, 0, 0,
        };
        public static int[] PRanger = {
            0, 0, 0,   0, 0, 0,   0, 0, 1,
            0, 1, 0,   0, 0, 0,   0, 0, 0,
        };
        public static int[] PRogue = {
            0, 0, 0,   0, 1, 0,   1, 0, 0,
            0, 0, 0,   0, 0, 0,   2, 2, 0,
        };
        public static int[] PSorcerer = {
            0, 0, 0,   0, 1, 0,   1, 0, 0,
            0, 0, 0,   0, 0, 0,   0, 0, 0,
        };
        public static int[] PWarlock = {
            0, 0, 0,   0, 1, 0,   0, 1, 0,
            0, 0, 0,   0, 0, 0,   0, 0, 0,
        };
        public static int[] PWizard = {
            0, 0, 1,   0, 0, 0,   1, 0, 0,
            0, 0, 0,   0, 0, 0,   0, 0, 0,
        };
        #endregion
        #region SAVING THROWS
        public static int[] STArtificer = {
            0, 0, 1, 1, 0, 0
        };
        public static int[] STBarbarian = {
            1, 0, 1, 0, 0, 0
        };
        public static int[] STBard = {
            0, 1, 0, 0, 0, 1
        };
        public static int[] STCleric = {
            0, 0, 0, 0, 1, 1
        };
        public static int[] STDruid = {
            0, 0, 0, 1, 1, 0
        };
        public static int[] STFighter = STBarbarian;
        public static int[] STMonk = {
            1, 1, 0, 0, 0, 0
        };
        public static int[] STPaladin = STCleric;
        public static int[] STRanger = STMonk;
        public static int[] STRogue = {
            0, 1, 0, 1, 0, 0
        };
        public static int[] STSorcerer = {
            0, 0, 1, 0, 0, 1
        };
        public static int[] STWarlock = STCleric;
        public static int[] STWizard = STDruid;
        #endregion
        #region Classes
        public static Class Artificer = new Class { ID = 0, Name = "Artificer", SavingThrowProficiencies = STArtificer, SkillProficiencies = PArtificer };
        public static Class Barbarian = new Class { ID = 1, Name = "Barbarian", SavingThrowProficiencies = STBarbarian, SkillProficiencies = PBarbarian };
        public static Class Bard = new Class { ID = 2, Name = "Bard", SavingThrowProficiencies = STBard, SkillProficiencies = PBard };
        public static Class Cleric = new Class { ID = 3, Name = "Cleric", SavingThrowProficiencies = STCleric, SkillProficiencies = PCleric };
        public static Class Druid = new Class { ID = 4, Name = "Druid", SavingThrowProficiencies = STDruid, SkillProficiencies = PDruid };
        public static Class Fighter = new Class { ID = 5, Name = "Fighter", SavingThrowProficiencies = STFighter, SkillProficiencies = PFighter };
        public static Class Monk = new Class { ID = 6, Name = "Monk", SavingThrowProficiencies = STMonk, SkillProficiencies = PMonk };
        public static Class Paladin = new Class { ID = 7, Name = "Paladin", SavingThrowProficiencies = STPaladin, SkillProficiencies = PPaladin };
        public static Class Ranger = new Class { ID = 8, Name = "Ranger", SavingThrowProficiencies = STRanger, SkillProficiencies = PRanger };
        public static Class Rogue = new Class { ID = 9, Name = "Rogue", SavingThrowProficiencies = STRogue, SkillProficiencies = PRogue };
        public static Class Sorcerer = new Class { ID = 10, Name = "Sorcerer", SavingThrowProficiencies = STSorcerer, SkillProficiencies = PSorcerer };
        public static Class Warlock = new Class { ID = 11, Name = "Warlock", SavingThrowProficiencies = STWarlock, SkillProficiencies = PWarlock };
        public static Class Wizard = new Class { ID = 12, Name = "Wizard", SavingThrowProficiencies = STWizard, SkillProficiencies = PWizard };
        #endregion
        private static readonly Class[] classes =
        {
            Artificer, Barbarian, Bard, Cleric, Druid, Fighter,
            Monk, Paladin, Ranger, Rogue, Sorcerer, Warlock, Wizard
        };
    }
}
