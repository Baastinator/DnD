using System;
using System.Windows.Forms;
using DND.Shared;
using DND.Shared.Entities.Characters;

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
            tempStats = Statblock.MakeStats(Statblock.STATS_RANDOM);
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
            Program.Character.CStats = tempStats;
            foreach (var i in Program.Character.CStats.IntArray)
            {
                Console.WriteLine(i);
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.Character.Name = textBox7.Text;
            Program.Character.IsMale = comboBox1.Text == "Male";
            Program.Character.Level = int.Parse(textBox8.Text);
            textBox9.Text = int.Parse(textBox9.Text) >= 15 ? "" + int.Parse(textBox9.Text) : "15";
            Program.Character.Age = int.Parse(textBox9.Text);
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

    }
}
