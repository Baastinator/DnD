using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DND.Shared;
using DND.Shared.Entities;
using DND.Shared.Entities.Characters;
using DND.Shared.Entities.Characters.Appearances;

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
            tempStats = Statblock.MakeStats();
            textBox1.Text = tempStats.STR.ToString();
            textBox2.Text = tempStats.DEX.ToString();
            textBox3.Text = tempStats.CON.ToString();
            textBox4.Text = tempStats.INT.ToString();
            textBox5.Text = tempStats.WIS.ToString();
            textBox6.Text = tempStats.CHA.ToString();
        }

        private void StatsSaveBtn_Click(object sender, EventArgs e)
        {
            tempStats.STR = int.Parse(textBox1.Text);
            tempStats.DEX = int.Parse(textBox2.Text);
            tempStats.CON = int.Parse(textBox3.Text);
            tempStats.INT = int.Parse(textBox4.Text);
            tempStats.WIS = int.Parse(textBox5.Text);
            tempStats.CHA = int.Parse(textBox6.Text);
            Program.Character.MakeStats(tempStats.IntArray); 
            foreach (var i in Program.Character.CStats.IntArray)
            {
                Console.WriteLine(i +"  "+ Statblock.getModifier(i));
            }
            LoadSocialClass();
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var gender in Gender.Genders)
            {
                comboBox1.Items.Add(gender.Name);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Character.SetName(textBox7.Text);
                Program.Character.SetGender(comboBox1.Text == "Male" ? 0 : 1);
                Program.Character.SetLevel(int.Parse(textBox8.Text));
                textBox9.Text = int.Parse(textBox9.Text) >= 15 ? "" + int.Parse(textBox9.Text) : "15";
                Program.Character.SetAge(int.Parse(textBox9.Text));
                Console.WriteLine("{0}\n{1}\n{2}\n{3}", Program.Character.Name, Program.Character.CGender.Name,
                    Program.Character.Level,Program.Character.Age);
                LoadRace();
            }
            catch (Exception exception)
            {
                textBox8.Text = "0";
                textBox9.Text = "" + (int) (20 * Math.Pow(1.01d, Randomiser.rng.Next(0, 101)));
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var age = int.Parse(textBox9.Text);
                if (age < 0) textBox9.Text = "0";
            }
            catch (Exception exception)
            {
                textBox9.Text = "";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var lvl = int.Parse(textBox8.Text);
                if (lvl < 0) textBox8.Text = "0";
                if (lvl > 20) textBox8.Text = "20";
            }
            catch (Exception exception)
            {
                textBox8.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = Randomiser.rng.Next(0, 2) == 1 ? "Male" : "Female";
            textBox8.Text = "" + Randomiser.rng.Next(1, 6);
            textBox9.Text = "" + (int)(20*Math.Pow(1.01d,Randomiser.rng.Next(0,101)));
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var a = int.Parse(textBox1.Text);
                a = (a > 20) ? 20 : ((a < 0) ? 0 : a);
                textBox1.Text = "" + a;
            }
            catch (Exception exception)
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var a = int.Parse(textBox2.Text);
                a = (a > 20) ? 20 : ((a < 0) ? 0 : a);
                textBox2.Text = "" + a;
            }
            catch (Exception exception)
            {
                textBox2.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var a = int.Parse(textBox3.Text);
                a = (a > 20) ? 20 : ((a < 0) ? 0 : a);
                textBox3.Text = "" + a;
            }
            catch (Exception exception)
            {
                textBox3.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var a = int.Parse(textBox4.Text);
                a = (a > 20) ? 20 : ((a < 0) ? 0 : a);
                textBox4.Text = "" + a;
            }
            catch (Exception exception)
            {
                textBox4.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var a = int.Parse(textBox5.Text);
                a = (a > 20) ? 20 : ((a < 0) ? 0 : a);
                textBox5.Text = "" + a;
            }
            catch (Exception exception)
            {
                textBox5.Text = "";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var a = int.Parse(textBox6.Text);
                a = (a > 20) ? 20 : ((a < 0) ? 0 : a);
                textBox6.Text = "" + a;
            }
            catch (Exception exception)
            {
                textBox6.Text = "";
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
                LoadStats();
            }
            catch (Exception exception)
            {
                comboBox2.Text = "";
            }
        }

        private void LoadRace()
        {
            panel4.Enabled = true;
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

            panel5.Enabled = true;
            foreach (var socialClass in SocialClass.SocialClasses)
            {
                comboBox3.Items.Add(socialClass.Name);
            }
            UnloadAppearance();
        }

        private void LoadAppearance()
        {
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
            UnloadBackground();
        }

        private void LoadBackground()
        {
            panel11.Enabled = true;
            UnloadClass();
        }

        private void LoadClass()
        {
            panel12.Enabled = true;
        }

        private void UnloadClass()
        {
            panel12.Enabled = false;
            comboBox11.Text = "";
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
            var r = Randomiser.rng.Next(0, SocialClass.SocialClasses.Length);
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
            catch (Exception exception)
            {
                comboBox3.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RandomiseAppFeatures();
        }

        private void RandomiseAppFeatures()
        {
            
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
    }
}
