using System;
using System.Reflection.Emit;
using DND.Characters.Stats;


namespace DND.Characters
{
    public class Statblock
    {
        private Stat Str, Dex, Con, Int, Wis, Cha;

        #region STATVALUES
        public int STR
        {
            get => Str.Value;
            set => Str.Value = value;
        }
        public int DEX
        {
            get => Dex.Value;
            set => Dex.Value = value;
        }
        public int CON
        {
            get => Con.Value;
            set => Con.Value = value;
        }
        public int INT
        {
            get => Int.Value;
            set => Int.Value = value;
        }
        public int WIS
        {
            get => Wis.Value;
            set => Wis.Value = value;
        }
        public int CHA
        {
            get => Cha.Value;
            set => Cha.Value = value;
        }

        public int StrMod => getModifier(STR);
        public int DexMod => getModifier(DEX);
        public int ConMod => getModifier(CON);
        public int IntMod => getModifier(INT);
        public int WisMod => getModifier(WIS);
        public int ChaMod => getModifier(CHA);

        #endregion
        public int[] IntArray
        {
            get
            {
                return new[] { STR, DEX, CON, INT, WIS, CHA };
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
                return new[] { Str, Dex, Con, Int, Wis, Cha };
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
        public static int getModifier(int stat)
        {
            if ((uint)stat > 20)
            {
                throw new Exception("bad number in statmodifier");
            }
            return (int)Math.Floor((stat - 10d) / 2);
        }

        //CONFIGURATIONS
        public static readonly byte STATS_RANDOM = 0, STATS_MANUAL = 1;

        public Statblock()
        {
            Str = new Stat();
            Dex = new Stat();
            Con = new Stat();
            Int = new Stat();
            Wis = new Stat();
            Cha = new Stat();
        }

#nullable enable
        public static Statblock MakeStats(byte config, int[] content )
        {
            Statblock output = new Statblock();
            if (config == STATS_RANDOM)
            {
                output.StatArray = new[] { Stat.MakeStat(), Stat.MakeStat(), Stat.MakeStat(), Stat.MakeStat(), Stat.MakeStat(), Stat.MakeStat() };
            }
            else
            {
                output.IntArray = content;
            }
            return output;
        }
#nullable disable
        public static Statblock AddStats(Statblock s, Statblock o)
        {
            var stats = new int[6];
            for (int i = 0; i < 6; i++)
            {
                stats[i] = s.IntArray[i] + o.IntArray[i];
            } 
            return MakeStats(STATS_MANUAL, stats);
        }
    }
}
