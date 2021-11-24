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
        public string Name;
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

        public void SetGender(bool isMale) => IsMale = isMale;

        public void GenGender() => IsMale = Randomiser.rng.Next(0, 2) == 1;

        public void SetLevel(int lvl) => Level = lvl;
        
        public void GenLevel(int min, int max) => Level = Randomiser.rng.Next(min, max + 1);

        public void SetName(string name) => Name = name;

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

        public void GenStats()
        {
            var stats = Statblock.MakeStats(Statblock.STATS_RANDOM);
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

        public void GenBodyClothes()
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

        public void GenAppearance()
        {
            GenHairLength();
            GenSkin();
            GenHairColor();
            GenEyes(); 
        }

        public void SetAppearance(int[] IDs)
        {
            SetHairLength(IDs[0]);
            SetSkin(IDs[1]);
            SetHairColor(IDs[2]);
            SetEyes(IDs[3]);
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

        public void GenSkin()
        {
            SkinColor Goblinoid() => SkinColor.SkinColors["Goblinoid"][Randomiser.rng.Next(0, 2)];

            SkinColor Avian() => Randomiser.rng.Next(0, 3) switch
            {
                0 => SkinColor.TfRed,
                1 => SkinColor.TfOrange,
                2 => SkinColor.TaYellow,
                _ => throw new Exception("")
            };

            CAppearance.SkinColor = CRace.Name switch
            {
                "Half Orc" => Goblinoid(),
                "Dragonborn" => SkinColor.SkinColors["Dragonborn"][Randomiser.rng.Next(0, 2)],
                "Tiefling" => new Randomiser(new[] {20, 50}).Roll() == 1
                    ? SkinColor.SkinColors["Humanoid"][new Randomiser(new[] {50, 10, 40}).Roll()]
                    : SkinColor.SkinColors["Tiefling"][new Randomiser(new[] {40, 50, 10}).Roll()],
                "Goliath" => SkinColor.Goliath,
                "Tabaxi" => SkinColor.SkinColors["Tabaxi"][Randomiser.rng.Next(0, 2)],
                "Aarakokra" => Avian(),
                "Kenku" => Avian(),
                "Tortle" => Goblinoid(),
                "Bugbear" => SkinColor.SkinColors["Tabaxi"][Randomiser.rng.Next(0, 2)],
                "Goblin" => Goblinoid(),
                "Hobgoblin" => Goblinoid(),
                "Kobold" => Goblinoid(),
                "Lizardfolk" => Goblinoid(),
                "Orc" => Goblinoid(),
                "Warforged" => SkinColor.Warforged,
                _ => SkinColor.SkinColors["Humanoid"][new Randomiser(new[] {50, 10, 40}).Roll()]
            };
        }

        public void SetSkin(int ID) => CAppearance.SkinColor = SkinColor.skinColors[ID];

        public void GenHairColor()
        {
            // REMEMBER TO MAKE OLD FUCKS MORE GRAY
            HairColor Goblinoid() => HairColor.HairColors["Goblinoid"][Randomiser.rng.Next(0,3)];
            HairColor Tiefling() => HairColor.HairColors["Tiefling"][Randomiser.rng.Next(0, 4)];
            int f(int age) => (int) Math.Max(0d, Math.Min(100d,5.821*Math.Pow(1.05859,age-50)-0.338));
            CAppearance.HairColor = new Randomiser(new[] {f(Age), 100 - f(Age)}).Roll() == 0
                ? HairColor.Gray
                : CRace.Name switch
                {
                    "Half Orc" => Goblinoid(),
                    "Dragonborn" => HairColor.None,
                    "Tiefling" => Tiefling(),
                    "Goliath" => HairColor.None,
                    "Tabaxi" => HairColor.None,
                    "Aarakocra" => HairColor.None,
                    "Kenku" => HairColor.None,
                    "Bugbear" => HairColor.None,
                    "Tortle" => Goblinoid(),
                    "Goblin" => Goblinoid(),
                    "Hobgoblin" => Goblinoid(),
                    "Kobold" => Goblinoid(),
                    "Lizardfolk" => Goblinoid(),
                    "Orc" => Goblinoid(),
                    "Warforged" => HairColor.None,
                    _ => HairColor.HairColors["Humanoid"][Randomiser.rng.Next(0,4)]
                };
        }

        public void SetHairColor(int ID) => CAppearance.HairColor = HairColor.hairColors[ID];

        public void GenEyes() => CAppearance.EyeColor =
            EyeColor.EyeColors[new Randomiser(new[] {10, 10, 10, 10, 10, 10, 0}).Roll()];

        public void SetEyes(int ID) => CAppearance.EyeColor = EyeColor.EyeColors[ID];

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

        public void GenSavingThrows() => 
            CSavingThrows = new SavingThrows(CStats, CClass.SavingThrowProficiencies);

        #endregion

        #region SKILLS

        public void GenSkills() => CSkills = new Skillblock(Level, CStats,
            Proficiencies.AddTables(CClass.SkillProficiencies, CBackground.proficiencyTable));

        #endregion

        #region PSYCHOLOGY

        public void GenPsychology() =>
            CPsychology = new Psychology(new[] {CSocialClass.PsychMod, CProfession.PsychMod, CBackground.PsychMod, CClass.PsychMod});

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
