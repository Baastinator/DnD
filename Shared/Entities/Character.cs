using System;
using System.Collections.Generic;
using DND.Shared.Entities.Characters;
using DND.Shared.Entities.Characters.Appearances;
using DND.Shared.Entities.Characters.Professions;
using DND.Shared.Entities.Characters.SocialClasses;

namespace DND.Shared.Entities
{
    public class Character
    {

        public bool Player, IsMale;
        public int Level, Age;
        public Race CRace;
        public Statblock CStats;
        public SocialClass CSocialClass;
        public Appearance CAppearance;
        public Profession CProfession;
        public Background CBackground;
        public Class CClass;
        public SavingThrows CSavingThrows;
        public Skillblock CSkills;
        public Psychology CPsychology;
        public Character(bool isPlayer, int level = 0)
        {
            Player = isPlayer;
            Level = level == 0 ? new Random().Next(1, 4) : level;
            IsMale = new Random().Next(0, 2) == 1;

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

        #region CHARACTER OBJECT METHODS

        #region MISC

        #region Age

        public void SetAge(int age)
        {
            Age = age;
        }

        public void GenAge(int minInc, int maxInc)
        {
            Age = Randomiser.rng.Next(minInc, maxInc + 1);
        }

        #endregion

        #endregion

        #region RACE

        public void GenRace()
        {
            var raceRandomiser = new Randomiser(new[] { 100, 70, 60, 50, 30, 20, 20, 20, 15, 10, 10, 5, 5, 5 });
            CRace = Race.Races[raceRandomiser.Roll()];
        }

        public void SetRace(int ID)
        {
            CRace = Race.Races[ID];
        }

        #endregion

        #region STATS
        public void MakeStats(int[] statTable)
        {
            var stats = Statblock.MakeStats(Statblock.STATS_MANUAL, statTable);
            var bonus = Statblock.MakeStats(Statblock.STATS_MANUAL, CRace.StatBonus);
            CStats = Statblock.AddStats(stats, bonus);
        }

        public void MakeStats()
        {
            var stats = Statblock.MakeStats(Statblock.STATS_RANDOM, null!);
            var bonus = Statblock.MakeStats(Statblock.STATS_MANUAL, CRace.StatBonus);
            CStats = Statblock.AddStats(stats, bonus);
        }

        #endregion

        #region SOCIAL CLASS

        public void GenSocialClass(int WeightID)
        {
            var randomiser = new Randomiser(SocialClassWeightTables.ClassWeights[WeightID]);
            CSocialClass = SocialClass.SocialClasses[randomiser.Roll()];
        }

        public void GenSocialClass()
        {
            GenSocialClass(new Random().Next(0,4));
        }

        public void SetSocialClass(int ClassID)
        {
            CSocialClass = SocialClass.SocialClasses[ClassID];
        }

        #endregion

        #region APPEARANCE

        public void GenAppearanceBodyAndClothes()
        {
            CAppearance = new Appearance();
            int f(int x) => (int) Math.Floor(x / 5d);
            CAppearance.ClothingType = CSocialClass.ID switch
            {
                0 => ClothingType.Clothing[new Random().Next(0, 2)],
                1 => ClothingType.Clothing[new Random().Next(1, 3)],
                2 => ClothingType.Clothing[new Randomiser(new[] { 30, 70 }).Roll()],
                3 => ClothingType.Standard,
                4 => ClothingType.Clothing[new Random().Next(1, 3)],
                5 => ClothingType.Fine,
                6 => ClothingType.Fine,
                7 => ClothingType.Fine,
                8 => ClothingType.Standard,
                9 => ClothingType.Standard,
                _ => throw new Exception("ClothingType: bad social class input")
            };
            CAppearance.BodySize = (int)Math.Floor((CStats.ConMod - CStats.DexMod + CStats.StrMod / 2) * 2 / 5d);
            CAppearance.MuscleMass = (int)Math.Floor((CStats.StrMod + CStats.DexMod / 2 + CStats.ConMod / 2) / 2d);
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
        public void GenHairLength()
        {
            CAppearance.HairLength = IsMale switch
            {
                true => HairLength.HairLengths[new Randomiser(new[] {5, 10, 100, 20, 5, 1}).Roll()],
                false => HairLength.HairLengths[new Randomiser(new[] {5, 1, 10, 50, 50, 30}).Roll()]
            };
        }

        public void SetHairLength(int ID) => CAppearance.HairLength = HairLength.HairLengths[ID];

        public void GenHairColor()
        {
            // REMEMBER TO MAKE OLD FUCKS MORE GRAY
        }

        public void GenEyes()
        {

        }

        public void GenSkin()
        {

        }

        #endregion

        #region PROFESSION

        public void GenProfession(int weightTableID)
        {
            var randomiser = new Randomiser(ProfessionWeights.ProfessionWeightList[weightTableID]);
            CProfession = Profession.Professions[randomiser.Roll()];
        }
        public void GenProfession()
        {
            var randomiser = new Randomiser(CSocialClass.JobWeightTable);
            CProfession = Profession.Professions[randomiser.Roll()];
        }

        public void SetProfession(int ID)
        {
            CProfession = Profession.Professions[ID];
        }
        #endregion

        #region BACKGROUND

        public void GenBackground()
        {
            var a = new List<int>();
            for (var i = 0; i < Background.Backgrounds.Length; i++)
            {
                a.Add(10);
            }
            var randomiser = new Randomiser(a);
            CBackground = Background.Backgrounds[randomiser.Roll()];
        }

        public void SetBackground(int ID)
        {
            CBackground = Background.Backgrounds[ID];
        }

        #endregion

        #region CLASS

        public void GenClass()
        {
            CClass = Class.Classes[new Random().Next(0, 13)];
        }

        public void SetClass(int ID)
        {
            CClass = Class.Classes[ID];
        }

        #endregion

        #region SAVING THROWS

        public void MakeSavingThrows() => 
            CSavingThrows = new SavingThrows(CStats, CClass.SavingThrowProficiencies);

        #endregion

        #region SKILLS

        public void MakeSkills() => CSkills = new Skillblock(Level, CStats,
            Proficiencies.AddTables(CClass.SkillProficiencies, CBackground.proficiencyTable));

        #endregion

        #region PSYCHOLOGY

        public void GenPsychology() =>
            CPsychology = new Psychology(new[] {CSocialClass.PsychMod, CProfession.PsychMod});

        #endregion

        #endregion

        #region DISPLAY STRINGS

        #region DEBUG
        public string PsychModString 
        {
            get
            {
                var a = "\n\n" + CSocialClass.Name + " - " + CProfession.Name +
                                  "\nValue:  full = original + SoCl mod + Pro mod\n";
                for (var i = 0; i < CPsychology.Values.Values.Length; i++)
                {
                    a += CPsychology.Values.Values[i].Name + ":  " +
                         CPsychology.Values.Values[i].Value + " = oValue + " +
                         CSocialClass.PsychMod[i] / 2 + " + " +
                         CProfession.PsychMod[i] + "\n";
                }
                return a;
            }
        }

        #endregion

        #region NOT DEBUG

        

        #endregion

        #endregion
    }
}
