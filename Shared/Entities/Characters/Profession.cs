using System.Security.Cryptography.X509Certificates;
using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Characters
{
    public class Profession : Nameable
    {
        public double[] PsychMod { get; set; }
            #region PsychMods
            private static readonly double[] MEmpty =
            {
                0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0,  0,
                0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0
            };
        private static readonly double[] MMinstrel =
        {
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  1,  0,  0,  0,
           -1,  0,  0,  1,  0,      0,  0,  0,  0,  0,      1,  0,  0,  0
        };
        private static readonly double[] MArtist =
        {
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  1,  0,  0,
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  1,  0,  0
        };
        private static readonly double[] MBarrister =
        {
            2,  0,  0,  0,  0,      1,-.5,  0,  1,  0,      0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0, .5
        };
        private static readonly double[] MMayor =
        {
            1,  1,  0,  0,  0,     .5,  0,  0,  0, .5,      0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0
        };
        private static readonly double[] MGuardCaptain =
        {
            0,  2,  0,  0,  0,      0,  0,  0,  1,  0,      1,  0,  0,  0,  0,
            0,  0,  0,  0,  2,      0,  0, .5,  0,  0,      0,  0, .5,  0
        };
        private static readonly double[] MMinister =
        {
            2,  0,  0,  0,  1,      0,  1,  1,  0,  2,      1,  0,  0,  0,  0,
            0,  1,  0,  0,  0,      0,  0,-.5,  0,  1,      0,  0,  0,  0
        };
        private static readonly double[] MJudge =
        {
            2,  0,  0,  0,  0,      1,  0,  0,  0,  1,     .5,  0,  0,  0,  0,
            0,  2,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0
        };
        private static readonly double[] MLibrarian =
        {
            0,  0,  0,  0,  0,      1,  0,  0,  0,  0,      1,  0,  0,  0,  2,
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  2
        };
        private static readonly double[] MAlchemist =
        {
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,     -1,  0,  0,  0,  0,
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  1,  0,  1
        };
        private static readonly double[] MGuard =
        {
            1,  1,  0,  0,  0,      0,  0,  0, .5,  0,     .5,  0,  0,  0,  0,
            0, .5,  1,  0,  1,      0,  0,  1,  0,  0,      0,  0,  1,  0
        };
        private static readonly double[] MTeacher =
        {
            0,  0,  0,  0,  0,      1,  0, .5,  0,  0,      1,  0,  0,  0,  0,
            0,  0,  0,  0,  0,     .5,  0,  0,  0,  0,      0,  0,  0,  2
        };
        #endregion
        public Profession()
        {
            PsychMod = MEmpty;
        }
        #region JOBS 0-19
        public static Profession Lumberjack = new Profession { Name = "Lumberjack", ID = 0 };     // 0
        public static Profession Armorer = new Profession { Name = "Armorer", ID = 1 };
        public static Profession Minstrel = new Profession { Name = "Minstrel", ID = 2, PsychMod = MMinstrel};
        public static Profession Baker = new Profession { Name = "Baker", ID = 3 };
        public static Profession Candlemaker = new Profession { Name = "Candlemaker", ID = 4 };
        public static Profession Artist = new Profession { Name = "Artist", ID = 5, PsychMod = MArtist};          // 5
        public static Profession Butcher = new Profession { Name = "Butcher", ID = 6 };
        public static Profession Weaver = new Profession { Name = "Weaver", ID = 7 };
        public static Profession Winemaker = new Profession { Name = "Winemaker", ID = 8 };
        public static Profession Shoemaker = new Profession { Name = "Shoemaker", ID = 9 };
        public static Profession Steelwright = new Profession { Name = "Steelwright", ID = 10 };   // 10
        public static Profession Roofer = new Profession { Name = "Roofer", ID = 11 };
        public static Profession Locksmith = new Profession { Name = "Locksmith", ID = 12 };
        public static Profession Tanner = new Profession { Name = "Tanner", ID = 13 };
        public static Profession Cook = new Profession { Name = "Cook", ID = 14 };
        public static Profession Beltmaker = new Profession { Name = "Beltmaker", ID = 15 };      // 15
        public static Profession Barrister = new Profession { Name = "Barrister", ID = 16, PsychMod = MBarrister};
        public static Profession Banker = new Profession { Name = "Banker", ID = 17 };
        public static Profession Mayor = new Profession { Name = "Mayor", ID = 18, PsychMod = MMayor };
        public static Profession Manager = new Profession { Name = "Manager", ID = 19 };
        #endregion
        #region JOBS 20-39
        public static Profession GuardCaptain = new Profession { Name = "Guard Captain", ID = 20, PsychMod = MGuardCaptain}; // 20
        public static Profession Admiral = new Profession { Name = "Admiral", ID = 21 };
        public static Profession Captain = new Profession { Name = "Captain", ID = 22 };
        public static Profession Shiphand = new Profession { Name = "Shiphand", ID = 23 };
        public static Profession Servant = new Profession { Name = "Servant", ID = 24 };
        public static Profession WaitStaff = new Profession { Name = "Wait Staff", ID = 25 };       // 25
        public static Profession TaxCollector = new Profession { Name = "Tax Collector", ID = 26 };
        public static Profession Minister = new Profession { Name = "Minister", ID = 27, PsychMod = MMinister};
        public static Profession Secretary = new Profession { Name = "Secretary", ID = 28 };
        public static Profession Judge = new Profession { Name = "Judge", ID = 29, PsychMod = MJudge};
        public static Profession Merchant = new Profession { Name = "Merchant", ID = 30 };         // 30
        public static Profession Barkeep = new Profession { Name = "Barkeep", ID = 31 };
        public static Profession Librarian = new Profession { Name = "Librarian", ID = 32, PsychMod = MLibrarian};
        public static Profession Alchemist = new Profession { Name = "Alchemist", ID = 33, PsychMod = MAlchemist};
        public static Profession CharcoalBurner = new Profession { Name = "Charcoal Burner", ID = 34 };
        public static Profession Nurse = new Profession { Name = "Nurse", ID = 35 };               // 35
        public static Profession Labourer = new Profession { Name = "Labourer", ID = 36 };
        public static Profession Doctor = new Profession { Name = "Doctor", ID = 37 };
        public static Profession General = new Profession { Name = "General", ID = 38, PsychMod = MGuardCaptain};
        public static Profession Soldier = new Profession { Name = "Soldier", ID = 39 };
        #endregion
        #region JOBS 40-59
        public static Profession Guard = new Profession { Name = "Guard", ID = 40, PsychMod = MGuard};               // 40
        public static Profession Miller = new Profession { Name = "Miller", ID = 41 };
        public static Profession Farmer = new Profession { Name = "Farmer", ID = 42 };
        public static Profession Carpenter = new Profession { Name = "Carpenter", ID = 43 };
        public static Profession Smith = new Profession { Name = "Smith", ID = 44 };
        public static Profession Tailor = new Profession { Name = "Tailor", ID = 45 };             // 45
        public static Profession Mason = new Profession { Name = "Mason", ID = 46 };
        public static Profession Herder = new Profession { Name = "Herder", ID = 47 };
        public static Profession Teacher = new Profession { Name = "Teacher", ID = 48 };
        public static Profession Miner = new Profession { Name = "Miner",ID = 49 };               // 49
        public static Profession Adventurer = new Profession { Name = "Adventurer", ID = 50 };
        public static Profession None = new Profession { Name = "None", ID = 51 };
        public static Profession Urchin = new Profession { Name = "Urchin", ID = 52 };
        public static Profession Bandit = new Profession { Name = "Bandit", ID = 53 };
        public static Profession Pickpocket = new Profession { Name = "Pickpocket", ID = 54 };
        public static Profession Smuggler = new Profession { Name = "Smuggler", ID = 55 };
        public static Profession Fencer = new Profession { Name = "Fencer", ID = 56 };
        public static Profession Spy = new Profession { Name = "Spy", ID = 57 };
        public static Profession Thief = new Profession { Name = "Thief", ID = 58 };
        public static Profession CrewLeader = new Profession { Name = "Crew Leader", ID = 59 };
        #endregion
        #region JOBS 60-79s
        public static Profession Burglar = new Profession { Name = "Burglar", ID = 60 };
        public static Profession Enforcer = new Profession { Name = "Enforcer", ID = 61 };
        public static Profession Blackmailer = new Profession { Name = "Blackmailer", ID = 62 };
        public static Profession Herbalist = new Profession {Name = "Herbalist", ID = 63 };
        public static Profession Author = new Profession {Name = "Author", ID = 64};
        public static Profession Professor = new Profession {Name = "Professor", ID = 65};
        public static Profession CourtMage = new Profession {Name = "Court Mage", ID = 66};
        public static Profession Wizard = new Profession {Name = "Wizard", ID = 67};
        public static Profession Witch = new Profession {Name = "Witch", ID = 68};
        public static Profession Headmaster = new Profession {Name = "Headmaster", ID = 69};
        public static Profession Researcher = new Profession {Name = "Researcher", ID = 70};
        #endregion
        public static readonly Profession[] Professions = {
            Lumberjack, Armorer, Minstrel, Baker, Candlemaker,
            Artist, Butcher, Weaver, Winemaker, Shoemaker,
            Steelwright, Roofer, Locksmith, Tanner, Cook,
            Beltmaker, Barrister, Banker, Mayor, Manager,

            GuardCaptain, Admiral, Captain, Shiphand, Servant,
            WaitStaff, TaxCollector, Minister, Secretary, Judge,
            Merchant, Barkeep, Librarian, Alchemist, CharcoalBurner,
            Nurse, Labourer, Doctor, General, Soldier,

            Guard, Miller, Farmer, Carpenter, Smith,
            Tailor, Mason, Herder, Teacher, Miner, 
                    None, Urchin, Bandit, Pickpocket, 
            Smuggler, Fencer, Spy, Thief, CrewLeader,

            Burglar, Enforcer, Blackmailer, Herbalist, Author,
            Professor, CourtMage, Wizard, Witch, Headmaster,
            Researcher
        };

        public static Profession[] professions => Professions;
        //{

        //    Lumberjack, Armorer, Minstrel, Baker, Candlemaker,
        //    Artist, Butcher, Weaver, Winemaker, Shoemaker,
        //    Steelwright, Roofer, Locksmith, Tanner, Cook,
        //    Beltmaker, Barrister, Banker, Mayor, Manager,

        //    GuardCaptain, Admiral, Captain, Shiphand, Servant,
        //    WaitStaff, TaxCollector, Minister, Secretary, Judge,
        //    Merchant, Barkeep, Librarian, Alchemist, CharcoalBurner,
        //    Nurse, Labourer, Doctor, General, Soldier,

        //    Guard, Miller, Farmer, Carpenter, Smith,
        //    Tailor, Mason, Herder, Teacher, Miner, Adventurer
        //};
    }
}
