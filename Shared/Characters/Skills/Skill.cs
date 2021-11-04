
namespace DND.Characters.Skills
{
    public class Skill
    {
        public int ID { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public byte BaseStat { get; set; }
        public byte proficiency = 0;
        public static Skill[] Skills { 
            get => skills; 
            set
            {
                Acrobatics = value[0];
                AnimalHandling = value[1];
                Arcana = value[2];
                Athletics = value[3];
                Deception = value[4];
                History = value[5];
                Insight = value[6];
                Intimidation = value[7];
                Investigation = value[8];
                Medicine = value[9];
                Nature = value[10];
                Perception = value[11];
                Performance = value[12];
                Persuation = value[13];
                Religion = value[14];
                SleightOfHand = value[15];
                Stealth = value[16];
                Survival = value[17];
            } 
        }

        public static readonly byte STR = 0, DEX = 1, CON = 2, INT = 3, WIS = 4, CHA = 5;

        public static Skill Acrobatics = new Skill { ID = 0, Name = "Acrobatics", Value = 0, BaseStat = DEX };
        public static Skill AnimalHandling = new Skill { ID = 1, Name = "AnimalHandling", Value = 0, BaseStat = WIS };
        public static Skill Arcana = new Skill { ID = 2, Name = "Arcana", Value = 0, BaseStat = INT };
        public static Skill Athletics = new Skill { ID = 3, Name = "Athletics", Value = 0, BaseStat = STR };
        public static Skill Deception = new Skill { ID = 4, Name = "Deception", Value = 0, BaseStat = CHA };
        public static Skill History = new Skill { ID = 5, Name = "History", Value = 0, BaseStat = INT };
        public static Skill Insight = new Skill { ID = 6, Name = "Insight", Value = 0, BaseStat = WIS };
        public static Skill Intimidation = new Skill { ID = 7, Name = "Intimidation", Value = 0, BaseStat = CHA };
        public static Skill Investigation = new Skill { ID = 8, Name = "Investigation", Value = 0, BaseStat = INT };
        public static Skill Medicine = new Skill { ID = 9, Name = "Medicine", Value = 0, BaseStat = WIS };
        public static Skill Nature = new Skill { ID = 10, Name = "Nature", Value = 0, BaseStat = INT };
        public static Skill Perception = new Skill { ID = 11, Name = "Perception", Value = 0, BaseStat = WIS };
        public static Skill Performance = new Skill { ID = 12, Name = "Performance", Value = 0, BaseStat = CHA };
        public static Skill Persuation = new Skill { ID = 13, Name = "Persuation", Value = 0, BaseStat = CHA };
        public static Skill Religion = new Skill { ID = 14, Name = "Religion", Value = 0, BaseStat = INT };
        public static Skill SleightOfHand = new Skill { ID = 15, Name = "SleightOfHand", Value = 0, BaseStat = DEX };
        public static Skill Stealth = new Skill { ID = 16, Name = "Stealth", Value = 0, BaseStat = DEX };
        public static Skill Survival = new Skill { ID = 17, Name = "Survival", Value = 0, BaseStat = WIS };
        private static readonly Skill[] skills = {
            Acrobatics, AnimalHandling, Arcana, Athletics, Deception, History, Insight, Intimidation, Investigation,
            Medicine, Nature, Perception, Performance, Persuation, Religion, SleightOfHand, Stealth, Survival
        };

    }
}
