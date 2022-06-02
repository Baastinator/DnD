using System;
using System.IO;
using System.Windows.Forms;
using DND.Shared;
using DND.Shared.Entities;
using DND.Shared.Entities.Characters;
using DND.Shared.Entities.Characters.Appearances;
using static DND.Shared.Strings;

namespace DnD.Char_Gen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        #region STATS

        private Statblock tempStats;
        private void StatsRollBtn_Click(object sender, EventArgs e)
        {
            tempStats = textBox11.Text switch
            {
                "" => Statblock.MakeStats(),
                "0" => Statblock.MakeStats(),
                _ => Statblock.MakeStats(int.Parse(textBox11.Text))
            };
            textBox1.Text = tempStats.STR.ToString();
            textBox2.Text = tempStats.DEX.ToString();
            textBox3.Text = tempStats.CON.ToString();
            textBox4.Text = tempStats.INT.ToString();
            textBox5.Text = tempStats.WIS.ToString();
            textBox6.Text = tempStats.CHA.ToString();
        }

        private void StatsSaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                tempStats.STR = int.Parse(RemoveWhitespace(textBox1.Text));
                tempStats.DEX = int.Parse(RemoveWhitespace(textBox2.Text));
                tempStats.CON = int.Parse(RemoveWhitespace(textBox3.Text));
                tempStats.INT = int.Parse(RemoveWhitespace(textBox4.Text));
                tempStats.WIS = int.Parse(RemoveWhitespace(textBox5.Text));
                tempStats.CHA = int.Parse(RemoveWhitespace(textBox6.Text));
                if (checkBox1.Checked)
                {
                    Program.Character.MakeStats(tempStats.IntArray);
                }
                else
                {
                    Program.Character.CStats = Statblock.MakeStats(tempStats.IntArray);
                }
                foreach (var i in Program.Character.CStats.IntArray)
                {
                    Console.WriteLine(i + "  " + Statblock.getModifier(i));
                }
                LoadSocialClass();
            }
            catch 
            {
                UnloadSocialClass();
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadRace();
        }

        private void LoadCharacter()
        {
            panel2.Enabled = true;
            comboBox1.Items.Clear();
            foreach (var gender in Gender.Genders)
            {
                comboBox1.Items.Add(gender.Name);
            }
            comboBox1.Text = "";
            UnloadStats();
        }

        private void UnloadCharacter()
        {
            panel2.Enabled = false;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Character.SetName(textBox7.Text);
                try
                {
                    Program.Character.SetGender(Character.FindElement(Gender.Genders,comboBox1.Text));
                }
                catch
                {
                    comboBox1.Text = "";
                    throw;
                }
                try
                {
                    textBox9.Text = int.Parse(textBox9.Text) >= 15 * (Program.Character.CRace.Name == "Elf" ? 5 : 1)
                        ? "" + int.Parse(textBox9.Text)
                        : "" + 15 * (Program.Character.CRace.Name == "Elf" ? 5 : 1);
                }
                catch
                {
                    textBox9.Text = "";
                    throw;
                }
                Program.Character.SetLevel(int.Parse(textBox8.Text));
                Program.Character.SetAge(int.Parse(textBox9.Text));
                Console.WriteLine("{0}\n{1}\n{2}\n{3}", Program.Character.Name, Program.Character.CGender.Name,
                    Program.Character.Level,Program.Character.Age);
                LoadStats();
            }
            catch 
            {
                UnloadStats();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var lvl = int.Parse(textBox8.Text);
                if (lvl < 0) textBox8.Text = "0";
                if (lvl > 20) textBox8.Text = "20";
            }
            catch 
            {
                textBox8.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Char = new Character();
            if (!checkBox6.Checked)
            { 
                Char.GenGender();
                comboBox1.Text = Char.CGender.Name;
            }
            if (!checkBox7.Checked) textBox8.Text = "" + Randomiser.rng.Next(1,4);
            if (!checkBox8.Checked)
                textBox9.Text = "" + (int) ((Program.Character.CRace.ID == Race.Elf.ID ? 5 : 1) * 20 *
                                            Math.Pow(1.01d, Randomiser.rng.Next(0, 101)));
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Program.Character.GenSavingThrows();
            Program.Character.GenSkills();
            Program.Character.GenPsychology();
            Console.WriteLine(Program.Character.Display);
            LoadFileSave();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var a = int.Parse(textBox1.Text);
                a = a > 20 ? 20 : a < 0 ? 0 : a;
                textBox1.Text = "" + a;
            }
            catch 
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var a = int.Parse(textBox2.Text);
                a = a > 20 ? 20 : a < 0 ? 0 : a;
                textBox2.Text = "" + a;
            }
            catch 
            {
                textBox2.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var a = int.Parse(textBox3.Text);
                a = a > 20 ? 20 : a < 0 ? 0 : a;
                textBox3.Text = "" + a;
            }
            catch 
            {
                textBox3.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var a = int.Parse(textBox4.Text);
                a = a > 20 ? 20 : a < 0 ? 0 : a;
                textBox4.Text = "" + a;
            }
            catch 
            {
                textBox4.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var a = int.Parse(textBox5.Text);
                a = a > 20 ? 20 : a < 0 ? 0 : a;
                textBox5.Text = "" + a;
            }
            catch 
            {
                textBox5.Text = "";
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Text = Race.Races[Randomiser.rng.Next(0, Race.Races.Length)].Name;
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                Program.Character.SetRace(Character.FindElement(Race.Races, comboBox2.Text));
                Console.WriteLine(Program.Character.CRace.Name);
                LoadCharacter();
            }
            catch
            {
                comboBox2.Text = "";
                UnloadCharacter();
                
            }
        }

        private void LoadRace()
        {
            panel4.Enabled = true;
            comboBox2.Items.Clear();
            foreach (var race in Race.Races)
            {
                comboBox2.Items.Add(race.Name);
            }
            UnloadStats();
        }
        private void LoadStats()
        {
            panel1.Enabled = true;
            UnloadSocialClass();
        }

        private void LoadSocialClass()
        {
            comboBox3.Items.Clear();
            panel5.Enabled = true;
            foreach (var socialClass in SocialClass.SocialClasses)
            {
                comboBox3.Items.Add(socialClass.Name);
            }
            UnloadAppearance();
        }

        private void LoadAppearance()
        {
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();
            foreach (var length in HairLength.HairLengths)
            {
                comboBox4.Items.Add(length.Name);
            }

            var RaceType = Program.Character.CRace.Name switch
            {
                "Half Orc" => "Goblinoid",
                "Dragonborn" => "Dragonborn",
                "Tiefling" => "Tiefling",
                "Goliath" => "Goliath",
                "Tabaxi" => "Tabaxi",
                "Aarakokra" => "Avian",
                "Kenku" => "Avian",
                "Tortle" => "Goblinoid",
                "Bugbear" => "Tabaxi",
                "Goblin" => "Goblinoid",
                "Hobgoblin" => "Goblinoid",
                "Kobold" => "Goblinoid",
                "Lizardfolk" => "Goblinoid",
                "Orc" => "Goblinoid",
                "Warforged" => "Warforged",
                _ => "Humanoid"
            };

            var SkinCollection = RaceType switch
            {
                "Tiefling" => SkinColor.SkinColors["TieflingFull"],
                "Goblinoid" => SkinColor.SkinColors["Goblinoid"],
                "Dragonborn" => SkinColor.SkinColors["Dragonborn"],
                "Goliath" => SkinColor.SkinColors["Goliath"],
                "Tabaxi" => SkinColor.SkinColors["Tabaxi"],
                "Avian" => SkinColor.SkinColors["Avian"],
                "Warforged" => SkinColor.SkinColors["Warforged"],
                _ => SkinColor.SkinColors["Humanoid"]
            };

            foreach (var skinColor in SkinCollection)
            {
                comboBox5.Items.Add(skinColor.Name);
            }

            var HairCollection = RaceType switch
            {
                "Humanoid" => HairColor.HairColors["Humanoid"],
                "Goblinoid" => HairColor.HairColors["Goblinoid"],
                "Tiefling" => HairColor.HairColors["Tiefling"],
                _ => new[] {HairColor.None}
            };

            foreach (var hairColor in HairCollection)
            {
                comboBox6.Items.Add(hairColor.Name);
            }

            foreach (var eyeColor in EyeColor.EyeColors)
            {
                comboBox7.Items.Add(eyeColor.Name);
            }

            foreach (var clothingType in ClothingType.Clothing)
            {
                comboBox8.Items.Add(clothingType.Name);
            }

            Program.Character.GenBody();
            label24.Text = "Body Type: " + Program.Character.CAppearance.BodyType.Name;
            panel6.Enabled = true;
            UnloadProfession();
        }

        private void LoadProfession()
        {
            panel10.Enabled = true;
            comboBox9.Items.Clear();
            comboBox9.Items.Add(Profession.Adventurer.Name);
            foreach (var profession in Profession.Professions)
            {
                comboBox9.Items.Add(profession.Name);
            }
            UnloadBackground();
        }

        private void LoadBackground()
        {
            panel11.Enabled = true;
            comboBox10.Items.Clear();
            foreach (var background in Background.Backgrounds)
            {
                comboBox10.Items.Add(background.Name);
            }
            UnloadClass();
        }

        private void LoadClass()
        {
            comboBox11.Items.Clear();
            foreach (var @class in Class.Classes)
            {
                comboBox11.Items.Add(@class.Name);
            }
            panel12.Enabled = true;
            UnloadFinalSave();
        }

        private void UnloadClass()
        {
            panel12.Enabled = false;
            comboBox11.Text = "";
            UnloadFinalSave();
        }

        private void UnloadBackground()
        {
            panel11.Enabled = false;
            comboBox10.Text = "";
            UnloadClass();
        }

        private void UnloadProfession()
        {
            panel10.Enabled = false;
            comboBox9.Text = "";
            UnloadBackground();
        }

        private void UnloadAppearance()
        {
            panel6.Enabled = false;
            comboBox8.Text = "";
            comboBox7.Text = "";
            comboBox6.Text = "";
            comboBox5.Text = "";
            comboBox4.Text = "";
            UnloadProfession();
        }

        private void UnloadSocialClass()
        {
            panel5.Enabled = false;
            comboBox4.Text = "";
            UnloadAppearance();
        }

        private void UnloadStats()
        {
            panel1.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            UnloadSocialClass();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var r = new Randomiser(new[]{100,10,100,50,20,10,5,1,20,10}).Roll();
            comboBox3.Text = SocialClass.SocialClasses[r].Name;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Character.SetSocialClass(Character.FindElement(SocialClass.SocialClasses, comboBox3.Text));
                Console.WriteLine(Program.Character.CSocialClass.Name);
                LoadAppearance();
            }
            catch
            {
                comboBox3.Text = "";
                UnloadAppearance();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RandomiseAppFeatures();
        }

        private void RandomiseAppFeatures()
        {
            SkinColor SGoblinoid() => SkinColor.SkinColors["Goblinoid"][Randomiser.rng.Next(0, 2)];

            SkinColor SAvian() => Randomiser.rng.Next(0, 3) switch
            {
                0 => SkinColor.TfRed,
                1 => SkinColor.TfOrange,
                2 => SkinColor.TaYellow,
                _ => throw new Exception("")
            };

            HairColor HGoblinoid() => HairColor.HairColors["Goblinoid"][Randomiser.rng.Next(0, 3)];
            HairColor HTiefling() => HairColor.HairColors["Tiefling"][Randomiser.rng.Next(0, 4)];
            int f(double age) => (int) Math.Max(0d, Math.Min(100d, 5.821 * Math.Pow(1.05859, age - 50) - 0.338));

            if (!checkBox2.Checked)
            {
                var hairlength = Program.Character.CRace.Name switch
                {
                    "Dragonborn" => HairLength.None,
                    "Goliath" => HairLength.None,
                    "Tabaxi" => HairLength.None,
                    "Aarakocra" => HairLength.None,
                    "Kenku" => HairLength.None,
                    "Bugbear" => HairLength.None,
                    "Warforged" => HairLength.None,
                    _ => Program.Character.CGender.Name switch
                    {
                        "Male" => HairLength.HairLengths[new Randomiser(new[] {5, 10, 100, 20, 5, 1}).Roll()],
                        "Female" => HairLength.HairLengths[new Randomiser(new[] {5, 1, 10, 50, 50, 30}).Roll()],
                        _ => HairLength.HairLengths[new Randomiser(new[] {5, 10, 100, 100, 50, 20}).Roll()]
                    }
                };

                comboBox4.Text = hairlength.Name;
            }

            if (!checkBox3.Checked)
            {
                var skinColor = Program.Character.CRace.Name switch
                {
                    "Half-Orc" => SGoblinoid(),
                    "Dragonborn" => SkinColor.SkinColors["Dragonborn"][Randomiser.rng.Next(0, 2)],
                    "Tiefling" => new Randomiser(new[] {20, 50}).Roll() == 1
                        ? SkinColor.SkinColors["Humanoid"][new Randomiser(new[] {50, 20, 30, 40}).Roll()]
                        : SkinColor.SkinColors["Tiefling"][new Randomiser(new[] {40, 50, 10}).Roll()],
                    "Goliath" => SkinColor.Goliath,
                    "Tabaxi" => SkinColor.SkinColors["Tabaxi"][Randomiser.rng.Next(0, 2)],
                    "Aarakokra" => SAvian(),
                    "Kenku" => SAvian(),
                    "Tortle" => SGoblinoid(),
                    "Bugbear" => SkinColor.SkinColors["Tabaxi"][Randomiser.rng.Next(0, 2)],
                    "Goblin" => SGoblinoid(),
                    "Hobgoblin" => SGoblinoid(),
                    "Kobold" => SGoblinoid(),
                    "Lizardfolk" => SGoblinoid(),
                    "Orc" => SGoblinoid(),
                    "Warforged" => SkinColor.Warforged,
                    _ => SkinColor.SkinColors["Humanoid"][new Randomiser(new[] {50, 20, 30, 40}).Roll()]
                };

                comboBox5.Text = skinColor.Name;
            }

            if (!checkBox4.Checked)
            {
                var hairColor = new Randomiser(new[]
                {
                    f(Program.Character.Age * (Program.Character.CRace.Name == "Elf" ? 0.2 : 1)),
                    100 - f(Program.Character.Age * (Program.Character.CRace.Name == "Elf" ? 0.2 : 1))
                }).Roll() == 0
                    ? HairColor.Gray
                    : Program.Character.CRace.Name switch
                    {
                        "Half-Orc" => HGoblinoid(),
                        "Dragonborn" => HairColor.None,
                        "Goliath" => HairColor.None,
                        "Tiefling" => HTiefling(),
                        "Tabaxi" => HairColor.None,
                        "Aarakocra" => HairColor.None,
                        "Kenku" => HairColor.None,
                        "Bugbear" => HairColor.None,
                        "Tortle" => HGoblinoid(),
                        "Goblin" => HGoblinoid(),
                        "Hobgoblin" => HGoblinoid(),
                        "Kobold" => HGoblinoid(),
                        "Lizardfolk" => HGoblinoid(),
                        "Orc" => HGoblinoid(),
                        "Warforged" => HairColor.None,
                        _ => HairColor.HairColors["Humanoid"][Randomiser.rng.Next(0, 4)]
                    };

                comboBox6.Text = hairColor.Name;
            }

            if (!checkBox5.Checked) {
                var eyeColor = EyeColor.EyeColors[new Randomiser(new[] {10, 10, 10, 10, 10, 10, 0}).Roll()];

                comboBox7.Text = eyeColor.Name;
            }

            if (!checkBox9.Checked)
            {
                var Char = Program.Character;
                Char.GenHeight();
                numericUpDown1.Text = "" + Char.CAppearance.Height.HeightInch;
                UpdateHeightBox();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            RandomiseAppFeatures();
            RandomiseClothing();
        }

        private void RandomiseClothing()
        {
            var clothingType = Program.Character.CSocialClass.ID switch
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
            comboBox8.Text = clothingType.Name;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Program.Character.SetHairLength(Character.FindElement(HairLength.HairLengths,comboBox4.Text));
                }
                catch
                {
                    comboBox4.Text = "";
                    throw;
                }
                try
                {
                    Program.Character.SetSkin(Character.FindElement(SkinColor.skinColors,comboBox5.Text));
                }
                catch
                {
                    comboBox5.Text = "";
                    throw;
                }
                try
                {
                    Program.Character.SetHairColor(Character.FindElement(HairColor.hairColors,comboBox6.Text));
                }
                catch
                {
                    comboBox6.Text = "";
                    throw;
                }
                try
                {
                    Program.Character.SetEyes(Character.FindElement(EyeColor.EyeColors,comboBox7.Text));
                }
                catch
                {
                    comboBox7.Text = "";
                    throw;
                }
                try
                {
                    Program.Character.SetClothes(Character.FindElement(ClothingType.Clothing,comboBox8.Text));
                }
                catch
                {
                    comboBox8.Text = "";
                    throw;
                }

                LoadProfession();
            }
            catch
            {
                UnloadProfession();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox9.Text == Profession.Adventurer.Name)
                {
                    Program.Character.CProfession = Profession.Adventurer;
                    comboBox10.Text = "";
                    comboBox11.Text = "";
                    LoadBackground();
                    return;
                }
                Program.Character.SetProfession(Character.FindElement(Profession.professions,comboBox9.Text));
                {
                    UnloadBackground();
                    Program.Character.CBackground = Background.None;
                    comboBox10.Text = "None";
                    Program.Character.CClass = Class.None;
                    comboBox11.Text = "None";
                    LoadFinalSave();
                }
            }
            catch
            {
                comboBox9.Text = "";
                UnloadBackground();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var Char = new Character
            {
                CRace = Program.Character.CRace,
                CStats = Program.Character.CStats,
                CSocialClass = Program.Character.CSocialClass
            };
            Char.GenProfession();  
            comboBox9.Text = Char.CProfession.Name;
        }

        private void LoadFinalSave()
        {
            button17.Enabled = true;
            UnloadFileSave();
        }
        private void LoadFileSave()
        {
            panel13.Enabled = true;
        }

        private void UnloadFinalSave()
        {
            button17.Enabled = false;
            UnloadFileSave();
        }

        private void UnloadFileSave()
        {
            panel13.Enabled = false;
            textBox10.Text = "";
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            var background = Background.Backgrounds[Randomiser.rng.Next(0,Background.Backgrounds.Length)];
            comboBox10.Text = background.Name;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Character.SetBackground(Character.FindElement(Background.Backgrounds,comboBox10.Text));
                Console.WriteLine(Program.Character.CBackground.Name);
                LoadClass();
            }
            catch
            {
                comboBox10.Text = "";
                UnloadClass();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var @class = Class.Classes[Randomiser.rng.Next(0, Class.Classes.Length)];
            comboBox11.Text = @class.Name;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Character.SetClass(Character.FindElement(Class.Classes,comboBox11.Text));
                Console.WriteLine(Program.Character.CClass.Name);
                LoadFinalSave();
            }
            catch
            {
                comboBox11.Text = "";
                UnloadFinalSave();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DnD\\";
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path);}
                path += "Characters\\";
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path);}
                path += textBox10.Text + ".txt";
                File.WriteAllText(path, Program.Character.Display);
            }
            catch
            {
                textBox10.Text = "";
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var a = int.Parse(textBox11.Text);
                a = a > 100 ? 100 : a < 0 ? 0 : a;
                textBox11.Text = "" + a;
            }
            catch
            {
                textBox11.Text = "";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateHeightBox();
            }
            catch
            {
                numericUpDown1.Text = "64";
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            UpdateHeightBox();
        }

        private void UpdateHeightBox()
        {
            Program.Character.CAppearance.Height.HeightInch = int.Parse(numericUpDown1.Text);
            textBox12.Text = Program.Character.CAppearance.Height.HeightStr;
        }
    }
}
