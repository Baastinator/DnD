using System;
using System.Windows.Forms;
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

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "AAASadsa";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
