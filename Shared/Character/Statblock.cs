using System;
using System.Collections.Generic;
using System.Text;
using DND.Character.Stats;


namespace DND.Character
{
    public class Statblock
    {
        static Random rng = new Random();
        private Stat Str, Dex, Con, Int, Wis, Cha;
        public int STR
        {
            get
            {
                return Str.Value;
            }
            set
            {
                Str.Value = value;
            }
        }
        public int DEX
        {
            get
            {
                return Dex.Value;
            }
            set
            {
                Dex.Value = value;
            }
        }
        public int CON
        {
            get
            {
                return Con.Value;
            }
            set
            {
                Con.Value = value;
            }
        }
        public int INT
        {
            get
            {
                return Int.Value;
            }
            set
            {
                Int.Value = value;
            }
        }
        public int WIS
        {
            get
            {
                return Wis.Value;
            }
            set
            {
                Wis.Value = value;
            }
        }
        public int CHA
        {
            get
            {
                return Cha.Value;
            }
            set
            {
                Cha.Value = value;
            }
        } 
        public int[] IntArray
        {
            get
            {
                return new int[] { STR, DEX, CON, INT, WIS, CHA };
            }
            set
            {
                STR = value[0];
                DEX = value[1];
                CON = value[2];
                INT = value[3];
                WIS = value[4];
                CHA = value[5];
            }
        }
        public Stat[] StatArray
        {
            get
            {
                return new Stat[] { Str, Dex, Con, Int, Wis, Cha };
            }
            set
            {
                Str = value[0];
                Dex = value[1];
                Con = value[2];
                Int = value[3];
                Wis = value[4];
                Cha = value[5];
            }
        }

        //CONFIGURATIONS
        public readonly static uint STATS_RANDOM = 0, STATS_MANUAL = 1;

        public Statblock()
        {
            Str = new Stat();
            Dex = new Stat();
            Con = new Stat();
            Int = new Stat();
            Wis = new Stat();
            Cha = new Stat();
        }

        public static Statblock MakeStats(uint config, int[]? content = null)
        {
            Statblock output = new Statblock();
            if (config == STATS_RANDOM)
            {
                output.StatArray = new Stat[] { Stat.MakeStat(), Stat.MakeStat(), Stat.MakeStat(), Stat.MakeStat(), Stat.MakeStat(), Stat.MakeStat() };
            }
            else
            {
                output.IntArray = content;
            }
            return output;
        }
    }
}
