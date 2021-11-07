using System;
using System.Net.Security;
using DND.Characters;
using DND.Characters.Appearances;
using DND.Characters.Professions;
using DND.Characters.SocialClasses;

namespace DND
{
    public class Character
    {

        public bool Player, IsMale;
        public int Level;
        public Race CRace;
        public Statblock Stats;
        public Psychology CPsychology;
        public SocialClass CSocialClass;
        public Appearance CAppearance;
        public Profession CProfession;
        public Background CBackground;
        public Class CClass;
        public SavingThrows CSavingThrows;
        public Skillblock CSkills;
        public Character(bool isPlayer, int level = 0)
        {
            Player = isPlayer;
            Level = level == 0 ? new Random().Next(1,4) : level;
            IsMale = new Random().Next(0,2)==1;
        }
        // NOTE
        // GENENERATION ORDER: 
        // 
        // RACE             // ALL 
        // STATS            // ALL
        // SOCIAL CLASS     // ALL
        // APPEARANCE       // ALL
        // PROFESSION       // ALL (adventurers locked on "adventurer" profession, trigger for background and class creation
        // BACKGROUND       // ADVENTURER
        // CLASS            // ADVENTURER
        // SAVING THROWS    // ADVENTURER
        // SKILLS           // ALL (only adventurers get proficiencies - inherited from class and background
        // PSYCHOLOGY       // ALL
        //
        // NOTE
        #region RACE

        public void GenRace()   
        {
            var raceRandomiser = new Randomiser(new[] {100,70,60,50,30,20,20,20,15,10,10,5,5,5});
            Race = Race.Races[raceRandomiser.Roll()];
        }

        public void SetRace(int ID)
        {
            Race = Race.Races[ID];
        }

        #endregion

        #region STATS
        public void MakeStats(int[] statTable)
        {
            var stats = Statblock.MakeStats(Statblock.STATS_MANUAL, statTable);
            var bonus = Statblock.MakeStats(Statblock.STATS_MANUAL, Race.StatBonus);
            Stats = Statblock.AddStats(stats, bonus);
        }

        public void MakeStats()
        {
            var stats = Statblock.MakeStats(Statblock.STATS_RANDOM, null!);
            var bonus = Statblock.MakeStats(Statblock.STATS_MANUAL, Race.StatBonus);
            Stats = Statblock.AddStats(stats, bonus);
        }

        #endregion

        #region SOCIAL CLASS

        public void GenSocialClass(int WeightID)
        {
            var randomiser = new Randomiser(SocialClassWeightTables.ClassWeights[WeightID]);
            SocialClass = SocialClass.SocialClasses[randomiser.Roll()];
        }

        public void GetSocialClass(int ClassID)
        {
            SocialClass = SocialClass.SocialClasses[ClassID];
        }

        #endregion

        #region APPEARANCE

        public void GenAppearance()
        {
            int f(int x) { return (int) Math.Floor(x / 5d); }
            CAppearance.ClothingType = CSocialClass.ID switch
            {
                0 => ClothingType.Clothing[new Random().Next(0, 2)],
                1 => ClothingType.Clothing[new Random().Next(1, 3)],
                2 => ClothingType.Clothing[new Randomiser(new[] {30, 70}).Roll()],
                3 => ClothingType.Standard,
                4 => ClothingType.Clothing[new Random().Next(1, 3)],
                5 => ClothingType.Fine,
                6 => ClothingType.Fine,
                7 => ClothingType.Fine,
                8 => ClothingType.Standard,
                9 => ClothingType.Standard,
                _ => throw new Exception("ClothingType: bad social class input")
            };
            CAppearance.BodySize = (int) Math.Floor((Stats.ConMod - Stats.DexMod + Stats.StrMod / 2) * 2 / 5d);
            CAppearance.MuscleMass = (int) Math.Floor((Stats.StrMod + Stats.DexMod / 2 + Stats.ConMod / 2) / 2d);
            var BS = f(CAppearance.BodySize);
            var MM = f(CAppearance.MuscleMass);
            CAppearance.BodyType = BS switch
            {
                -1 => MM switch
                {
                    -1 => BodyType.Skinny,
                    0 => BodyType.Plump,
                    1 => BodyType.Chubby,
                    _ => throw new Exception("")
                },
                0 => MM switch
                {
                    -1 => BodyType.Slim,
                    0 => BodyType.Average,
                    1 => BodyType.Stocky,
                    _ => throw new Exception("")
                },
                1 => MM switch
                {
                    -1 => BodyType.Lean,
                    0 => BodyType.Defined,
                    1 => BodyType.Bulky,
                    _ => throw new Exception("")
                },
                _ => throw new Exception("")
            };
        }

        #endregion

        #region PROFESSION

        public void GenProfession(int weightTableID)
        {
            var randomiser = new Randomiser(ProfessionWeights.ProfessionWeightList[weightTableID]);
            CProfession = Profession.Professions[randomiser.Roll()];
        }

        public void SetProfession(int ID)
        {
            CProfession = Profession.Professions[ID];
        }
        #endregion

        #region BACKGROUND

        #endregion

        #region CLASS



        #endregion

        #region SAVING THROWS

        

        #endregion

        #region SKILLS

        public void MakeSkills(int[] proficiencyTable, Statblock stats, int playerLvl)
        {

        }

        #endregion

        #region PSYCHOLOGY

        #endregion
    }
}
