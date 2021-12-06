using System;
using DND.Shared.Entities.Characters;
using DND.Shared.Entities.Characters.Appearances;
using DND.Shared.Entities.Characters.Professions;
using DND.Shared.Entities.Characters.SocialClasses;
using DND.Shared.Interfaces;
using static DND.Shared.Strings;

namespace DND.Shared.Entities
{
    public class Character
    {

        public string Name;
        public int Level, Age;
        public Gender CGender;
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

        public Character()
        {
            CAppearance = new Appearance();
        }


        public void SetAge(int age)
        {
            Age = age;
        }

        public void GenAge(int minInc, int maxInc)
        {
            Age = (int) (20 * Math.Pow(1.01d, Randomiser.rng.Next(0, 101)));
        }

        public void SetGender(int ID) => CGender = Gender.Genders[ID];

        public void GenGender() => CGender = Gender.Genders[Randomiser.rng.Next(0,2)];

        public void SetLevel(int lvl) => Level = lvl;
        
        public void GenLevel(int min, int max) => Level = Randomiser.rng.Next(min, max + 1);

        public void SetName(string name) => Name = name;

        #endregion

        public static int FindElement(INameable[] list, string element)
        {
            foreach (var t in list)
            {
                if (t.Name == element) return t.ID;
            }

            throw new Exception();
        }

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
            var stats = Statblock.MakeStats(statTable);
            var bonus = Statblock.MakeStats(CRace.StatBonus);
            CStats = Statblock.AddStats(stats, bonus);
        }

        public void GenStats()
        {
            var stats = Statblock.MakeStats();
            var bonus = Statblock.MakeStats(CRace.StatBonus);
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

        public void GenClothes()
        {
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
        }

        public void GenBody()
        {
            int f(int x) => (int)Math.Floor(Math.Atan(x/6d)+.5);
            CAppearance.BodySize = (int)Math.Floor(CStats.ConMod - CStats.DexMod + CStats.StrMod / 2d);
            CAppearance.MuscleMass = (int)Math.Floor(CStats.StrMod + CStats.DexMod / 2d + CStats.ConMod / 2d);
            var BS = f(CAppearance.BodySize);
            var MM = f(CAppearance.MuscleMass);
            CAppearance.BodyType = MM switch
            {
                -1 => BS switch
                {
                    -1 => BodyType.Skinny,
                    0 => BodyType.Plump,
                    1 => BodyType.Chubby,
                    _ => throw new Exception("")
                },
                0 => BS switch
                {
                    -1 => BodyType.Slim,
                    0 => BodyType.Average,
                    1 => BodyType.Stocky,
                    _ => throw new Exception("")
                },
                1 => BS switch
                {
                    -1 => BodyType.Lean,
                    0 => BodyType.Defined,
                    1 => BodyType.Bulky,
                    _ => throw new Exception("")
                },
                _ => throw new Exception("")
            };
        }

        public void SetBody(int ID) => CAppearance.BodyType = BodyType.BodyTypes[ID];

        public void SetClothes(int ID) => CAppearance.ClothingType = ClothingType.Clothing[ID];

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
            CAppearance.HairLength = CRace.Name switch
            {
                "Dragonborn" => HairLength.None,
                "Goliath" => HairLength.None,
                "Tabaxi" => HairLength.None,
                "Aarakocra" => HairLength.None,
                "Kenku" => HairLength.None,
                "Bugbear" => HairLength.None,
                "Warforged" => HairLength.None,
                _ => CGender.Name switch
                {
                    "Male" => HairLength.HairLengths[new Randomiser(new[] { 5, 10, 100, 20, 5, 1 }).Roll()],
                    "Female" => HairLength.HairLengths[new Randomiser(new[] { 5, 1, 10, 50, 50, 30 }).Roll()],
                    _ => HairLength.HairLengths[new Randomiser(new[] { 5, 10, 100, 100, 50, 20 }).Roll()]
                }
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
                "Half-Orc" => Goblinoid(),
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
                    "Half-Orc" => Goblinoid(),
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
            CProfession = Profession.professions[ID];
        }
        #endregion

        #region BACKGROUND

        public void GenBackground()
        { 
            CBackground = Background.Backgrounds[Randomiser.rng.Next(0,Background.Backgrounds.Length)];
            if (CProfession.ID != 50) {CBackground = Background.None; }
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
            if (CProfession.ID != 50) {CClass = Class.None;}
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

        public string Display
        {
            get
            {
                int Max(int[] a)
                {
                    int max = 0;
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (max < a[i]) max = a[i];
                    }

                    return max;
                }

                var CharValLongest = Max(new[]
                {
                    Name.Length, Age.ToString().Length, Level.ToString().Length, CGender.Name.Length, CRace.Name.Length,
                    CSocialClass.Name.Length, CProfession.Name.Length, CBackground.Name.Length, CClass.Name.Length, 
                    CAppearance.HairColor.Name.Length, CAppearance.HairLength.Name.Length, CAppearance.EyeColor.Name.Length,
                    CAppearance.SkinColor.Name.Length, CAppearance.ClothingType.Name.Length, CAppearance.BodyType.Name.Length,
                });
                var CharNameLongest = Max(new[]
                {
                    "Name".Length, "Age".Length, "Level".Length, "Gender".Length, "Race".Length, "Social Class".Length,
                    "Profession".Length, "Background".Length, "Class".Length, "Hair Color".Length, "Hair Length".Length,
                    "Eye Color".Length, "Skin Color".Length, "Clothing".Length, "Body Type".Length
                });
                var longestChar = CharValLongest + CharNameLongest;
                var longestSC = Math.Max(CSkills.Longest, longestChar);
                var output = "";
                output += "┌" + AddWhitespace("", CPsychology.Personality.Longest + 15, '─') + "┬" +
                                AddWhitespace("", CPsychology.Values.Longest + 19, '─') + "┬" + 
                                AddWhitespace("", longestSC + 8, '─') + "┐" + "\n" +
                          "│" + AddWhitespace(" Personality", CPsychology.Personality.Longest + 15) + "│" +
                                AddWhitespace(" Values", CPsychology.Values.Longest + 19) + "│" + 
                                AddWhitespace(" Skills", longestSC + 8) + "│" + "\n" +
                          "├" + AddWhitespace("", CPsychology.Personality.Longest + 15, '─') + "┼" + 
                                AddWhitespace("", CPsychology.Values.Longest + 19, '─') + "┼" +
                                AddWhitespace("", longestSC + 8, '─') + "┤" + "\n";
                for (var i = 0; i < CPsychology.Personality.Attributes.Length; i++)
                {
                    if (i < CPsychology.Personality.Attributes.Length) {
                        var PItem = CPsychology.Personality.Attributes[i];
                        output += "│ " + AddWhitespace(PItem.Name, CPsychology.Personality.Longest) + "=> " + AddWhitespace(
                            NumToString(RoundNumber(PItem.Value)), 9) + " " + 
                                  (i == 29 || i == 31 || i == 38 ? "├" : "│");
                    }
                    else
                    {
                        output += "│ " + AddWhitespace("", CPsychology.Personality.Longest + 13) + " │";
                    }
                    if (i < CPsychology.Values.Values.Length)
                    {
                        var VItem = CPsychology.Values.Values[i];

                        output += " " + AddWhitespace(VItem.Name, CPsychology.Values.Longest) + "=> " +
                                  AddWhitespace(
                                      NumToString(RoundNumber(VItem.Value)), 12) + "  " +
                                  (i == 18 || i == 20 ? "├" : "│");
                    }
                    else
                    {
                        output += AddWhitespace(i switch
                        {
                            29 => AddWhitespace("", CPsychology.Values.Longest + 19, '─'),
                            30 => " Stats (Stat - Mod - Saving Throws) ",
                            31 => AddWhitespace("", CPsychology.Values.Longest + 19, '─'),
                            32 => AddWhitespace(" Strength      => " + (CStats.STR < 10 ? " " : "") + CStats.STR +
                                                " - " +
                                                (CStats.StrMod < 0 ? "" : "+") +
                                                CStats.StrMod + " - " + (CSavingThrows.STR < 0 ? "" : "+") +
                                                CSavingThrows.STR,
                                CPsychology.Values.Longest + 19),
                            33 => AddWhitespace(" Dexterity     => " + (CStats.DEX < 10 ? " " : "") + CStats.DEX +
                                                " - " +
                                                (CStats.DexMod < 0 ? "" : "+") +
                                                CStats.DexMod + " - " + (CSavingThrows.DEX < 0 ? "" : "+") +
                                                CSavingThrows.DEX, CPsychology.Values.Longest + 19),
                            34 => AddWhitespace(" Constitution  => " + (CStats.CON < 10 ? " " : "") + CStats.CON +
                                                " - " +
                                                (CStats.ConMod < 0 ? "" : "+") +
                                                CStats.ConMod + " - " + (CSavingThrows.CON < 0 ? "" : "+") +
                                                CSavingThrows.CON, CPsychology.Values.Longest + 19),
                            35 => AddWhitespace(" Intelligence  => " + (CStats.INT < 10 ? " " : "") + CStats.INT +
                                                " - " +
                                                (CStats.IntMod < 0 ? "" : "+") +
                                                CStats.IntMod + " - " + (CSavingThrows.INT < 0 ? "" : "+") +
                                                CSavingThrows.INT, CPsychology.Values.Longest + 19),
                            36 => AddWhitespace(" Wisdom        => " + (CStats.WIS < 10 ? " " : "") + CStats.WIS +
                                                " - " +
                                                (CStats.WisMod < 0 ? "" : "+") +
                                                CStats.WisMod + " - " + (CSavingThrows.WIS < 0 ? "" : "+") +
                                                CSavingThrows.WIS, CPsychology.Values.Longest + 19),
                            37 => AddWhitespace(" Charisma      => " + (CStats.CHA < 10 ? " " : "") + CStats.CHA +
                                                " - " +
                                                (CStats.ChaMod < 0 ? "" : "+") +
                                                CStats.ChaMod + " - " + (CSavingThrows.CHA < 0 ? "" : "+") +
                                                CSavingThrows.CHA, CPsychology.Values.Longest + 19),
                            38 => AddWhitespace("", CPsychology.Values.Longest + 19, '─'),
                            _ => ""
                        }, CPsychology.Values.Longest + 19) + i switch
                        {
                            29 => "┤",
                            31 => "┼",
                            33 => "├",
                            38 => "┤",
                            40 => "├",
                            _ => "│"
                        };
                    }
                    if (i < CSkills.skills.Length)
                    {
                        var SItem = CSkills.skills[i];
                        output += " " + AddWhitespace(SItem.Name, CSkills.Longest) + "=> " +
                                  AddWhitespace((SItem.Value < 0 ? "" : " ") + SItem.Value, longestSC-CSkills.Longest+3) + "│";
                    }

                    output += i >= 18
                        ? i switch
                        {
                            18 => AddWhitespace("", longestSC + 8, '─') + "┤",
                            19 => AddWhitespace(" Character", longestSC + 8) + "│",
                            20 => AddWhitespace("", longestSC + 8, '─') + "┤",
                            21 => AddWhitespace(" Name", CharNameLongest + 2) + "=> " +
                                  AddWhitespace(Name, CharValLongest + 2) + "│",
                            22 => AddWhitespace(" Level", CharNameLongest + 2) + "=> " +
                                  AddWhitespace("" + Level, CharValLongest + 2) + "│",
                            23 => AddWhitespace(" Gender", CharNameLongest + 2) + "=> " +
                                  AddWhitespace(CGender.Name, CharValLongest + 2) + "│",
                            24 => AddWhitespace(" Age", CharNameLongest + 2) + "=> " +
                                  AddWhitespace("" + Age, CharValLongest + 2) + "│",
                            25 => AddWhitespace("", longestSC + 8) + "│",
                            26 => AddWhitespace(" Race", CharNameLongest + 2) + "=> " +
                                  AddWhitespace(CRace.Name, CharValLongest + 2) + "│",
                            27 => AddWhitespace(" Social Class", CharNameLongest + 2) + "=> " +
                                  AddWhitespace(CSocialClass.Name, CharValLongest + 2) + "│",
                            28 => AddWhitespace(" Profession", CharNameLongest + 2) + "=> " +
                                  AddWhitespace(CProfession.Name, CharValLongest + 2) + "│",
                            29 => AddWhitespace(" Background", CharNameLongest + 2) + "=> " +
                                  AddWhitespace(CBackground.Name, CharValLongest + 2) + "│",
                            30 => AddWhitespace(" Class", CharNameLongest + 2) + "=> " +
                                  AddWhitespace(CClass.Name, CharValLongest + 2) + "│",
                            31 => AddWhitespace("", longestSC + 8, '─') + "┤",
                            32 => AddWhitespace(" Appearance", longestSC + 8) + "│",
                            33 => AddWhitespace("", longestSC + 8, '─') + "┤",
                            34 => AddWhitespace(" Hair Color   => " + CAppearance.HairColor.Name, longestSC + 8) + "│",
                            35 => AddWhitespace(" Hair Length  => " + CAppearance.HairLength.Name, longestSC + 8) + "│",
                            36 => AddWhitespace(" Eye Color    => " + CAppearance.EyeColor.Name, longestSC + 8) + "│",
                            37 => AddWhitespace(" Skin Color   => " + CAppearance.SkinColor.Name, longestSC + 8) + "│",
                            38 => AddWhitespace(" Clothing     => " + CAppearance.ClothingType.Name, longestSC + 8) +
                                  "│",
                            39 => AddWhitespace(" Body Type    => " + CAppearance.BodyType.Name, longestSC + 8) + "│",
                            40 => AddWhitespace("", longestSC + 8, '─') + "┤",
                            _ => AddWhitespace("", longestSC + 8) + "│",
                        }
                        : "";


                    output += "\n";
                }

                output += "└" + AddWhitespace("", CPsychology.Personality.Longest + 15, '─') + "┴" +
                                AddWhitespace("", CPsychology.Values.Longest + 19, '─') + "┴" +
                                AddWhitespace("", longestSC + 8, '─') + "┘" + "\n";

                return output;
            }
        }

        #endregion

        #endregion

        #region PRESETS

        public static Character Empty = new Character {Name = "None"};

        #endregion
    }
}
