using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Characters

{
    public class Background : Nameable
    {
        public int[] proficiencyTable { get; set; }
        public static Background[] Backgrounds => backgrounds;
        public double[] PsychMod { get; set; }

        #region PsychMods
        private static readonly double[] MAcolyte =
        {
            0,  1,  0,  0,  0,      0,  0,  0,  0,  0,      1,  0, .5,  0,  0,
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0
        };
        private static readonly double[] MAnthropologist =
        {
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      1,  0,  1,  0,  1,
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  2
        };
        private static readonly double[] MAthlete =
        {
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0,  0,
            0,  1,  0,  0,  1,      0,  1,  0,  2,  1,      0,  0,  0,  0
        };
        private static readonly double[] MCharlatan =
        {
           -1,  0,  0,  0,  0,     -1,  1,  2,  0,  0,      0,  0,  0,  0,  0,
            0,  1,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0
        };
        private static readonly double[] MCityWatch =
        {
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0,  0,
            1,  0,  0,  0,  1,      0,  1,  0,  0,  0,      0,  0,  0,  0
        };
        private static readonly double[] MClanCrafter =
        {
            0,  1,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,      1,  1,  0,  0,  0,      0,  0,  0,  1
        };
        private static readonly double[] MCourtier =
        {
            0,  1,  0,  0, .5,      0,  1,  0,  0,  1,      1,  0,  0,  0,  0,
            1,  0,  0,  0,  0,      0,  0,  0,  1,  0,      0,  0,  0,  0
        };
        private static readonly double[] MCriminal =
        {
           -1,  0,  0,  0,  0,      0,  1,  0, -1, -1,      0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,      1,  0,  0,  0,  0,      0,  0,  0,  0
        };
        private static readonly double[] MEntertainer =
        {
            0,  0,  0,  0,  0,      0,  1,  0,  0,  0,      0,  2,  1,  0,  0,
            0,  0,  0,  1,  0,      0,  0,  0,  0,  0,      1,  0,  0,  1
        };
        private static readonly double[] MFaceless =
        {
            0,  0,  0,  0,  0,      0,  1,  1,  0,  0,      0,  0,  0,  0,  0,
            0,  1,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  1
        };
        private static readonly double[] MFisher =
        {
            0,  0,  1,  0,  0,      0,  0,  0,  1,  0,      0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,      0,  0,  1,  0,  1,      0,  0,  1,  0
        };
        private static readonly double[] MFolkHero =
        {
            0,  0,  0,  0,  1,      0,  0,  0,  0,  0,      0,  0,  0,  0,  0,
            0,  0,  0,  0,  1,      1,  0,  0,  0,  0,      0,  0,  0,  0
        };
        private static readonly double[] MGuildArtisan =
        {
            0,  1,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  2,  0,  0,
            0,  0,  0,  0,  0,      1,  1,  0,  0,  0,      0,  0,  0,  1
        };
        private static readonly double[] MGuildMerchant =
        {
            0,  1,  1,  0,  0,      0,  0,  1,  0,  0,      0,  0,  0,  1,  0,
            0,  0,  0,  0,  0,      0,  0,  0,  1,  0,      0,  0,  0,  0
        };
        private static readonly double[] MHauntedOne =
        {
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0,  0,
            1,  0,  0,  0,  0,      0,  0,  0,  0,  1,      0,  0,  1,  0
        };
        private static readonly double[] MHermit =
        {
            0,  0,  0,  0,  0,      1,  0,  0,  0,  0,      0,  0,  0,  0,  0,
            0,  1,  1,  0,  0,      0,  0,  0,  0,  0,      0,  1,  1,  1,
        };
        private static readonly double[] MInvestigator =
        {
           .5,  0,  0,  0,  0,      1,  0,  0,  1,  0,      0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,      1,  0,  0,  0,  0,      0,  0,  0,  1
        };
        private static readonly double[] MKnight =
        {
            1,  1,  0,  0, .5,      0,  0,  0,  0,  1,      1,  0,  0,  1,  0,
            0,  0,  0,  0,  0,      0,  1,  1,  0,  1,      0,  0,  0,  0
        };
        private static readonly double[] MNoble =
        {
            1,  0,  0,  0,  1,      0,  1,  1,  0,  1,      1,  0,  0,  0,  0,
            0,  1,  0,  1,  0,      0,  0,  0,  0,  0,      1,  0,  0,  0
        };
        private static readonly double[] MPirate =
        {
           -1,  0, .5,  0,  0,      0,  0,  0,  0, -1,      0,  1,  0,  1,  0,
            0,  0,  0,  1,  0,      1,  0,  0,  0,  1,      0,  0,  1,  0
        };
        private static readonly double[] MSage =
        {
            0,  0,  0,  0,  0,      1,  0,  0,  1,  0,      0,  0,  0,  1,  0,
            0,  0,  0,  0,  0,      0,  0,  0,  0,  1,      0,  0,  1,  0
        };
        private static readonly double[] MSailor =
        {
            0,  0, .5,  0,  0,      0,  0,  0,  0, -1,      0,  1,  0,  1,  0,
            0,  0,  0,  1,  0,      1,  0,  0,  0,  1,      0,  0,  1,  0
        };
        private static readonly double[] MSmuggler =
        {
           -1,  0,  0,  0,  0,      0,  1,  1,  0,  0,      0,  0,  0,  1,  0,
            1,  1,  0,  0,  0,      1,  0,  0,  0,  1,      0,  0,  0,  0
        };
        private static readonly double[] MSoldier =
        {
            0,  1,  0,  1,  0,      0,  0,  0,  1,  0,      0,  1,  0,  1,  0,
            0,  0,  0,  1,  1,      0,  1,  1,  0,  1,      0,  0,  0,  0
        };
        private static readonly double[] MSpy =
        {
            0,  0,  0,  0,  0,      1,  1,  2,  0,  1,      0,  0,  0,  0,  0,
            0,  1,  0,  0,  0,      1,  0,  0,  0,  1,      0,  0,  0,  0
        };
        private static readonly double[] MUrchin =
        {
            0,  0,  0,  0,  0,      0,  1,  0,  0, -1,      0,  1,  0,  1,  1,
            0,  0,  1,  0,  0,      0,  1,  0,  0,  1,      0,  0,  1,  0
        };
        private static readonly double[] MEmpty =
        {
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,      0,  0,  0,  0,  0,      0,  0,  0,  0
        };

        #endregion
        #region Weights
        private static readonly int[] WAcolyte =
        {
            0,  0,  0,  0,  0,  0,  1,  0,  0,
            0,  0,  0,  0,  0,  1,  0,  0,  0,
        }; // 0
        private static readonly int[] WAnthropologist = WAcolyte;
        private static readonly int[] WAthlete =
        {
            1,  0,  0,  1,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  0
        };
        private static readonly int[] WCharlatan =
        {
            0,  0,  0,  0,  1,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  1,  0,  0
        };
        private static readonly int[] WCityWatch =
        {
            0,  0,  0,  1,  0,  0,  1,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  0
        };
        private static readonly int[] WClanCrafter =
        {
            0,  0,  0,  0,  0,  1,  1,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  0
        }; // 5
        private static readonly int[] WCourtier =
        {
            0,  0,  0,  0,  0,  0,  1,  0,  0,
            0,  0,  0,  0,  1,  0,  0,  0,  0
        };
        private static readonly int[] WCriminal =
        {
            0,  0,  0,  0,  1,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  1,  0
        };
        private static readonly int[] WEntertainer =
        {
            1,  0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  1,  0,  0,  0,  0,  0
        };
        private static readonly int[] WFaceless =
        {
            0,  0,  0,  0,  1,  0,  0,  1,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  0
        };
        private static readonly int[] WFisher =
        {
            0,  0,  0,  0,  0,  1,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  1
        }; // 10
        private static readonly int[] WFolkHero =
        {
            0,  1,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  1
        };
        private static readonly int[] WGladiator =
        {
            1,  0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  1,  0,  0,  0,  0,  0
        };
        private static readonly int[] WGuildArtisan =
        {
            0,  0,  0,  0,  0,  0,  1,  0,  0,
            0,  0,  0,  0,  1,  0,  0,  0,  0
        };
        private static readonly int[] WGuildMerchant =
        {
            0,  0,  0,  0,  0,  0,  1,  0,  0,
            0,  0,  0,  0,  1,  0,  0,  0,  0
        };
        private static readonly int[] WHauntedOne =
        {
            0,  0,  0,  0,  0,  0,  0,  0,  1,
            0,  0,  0,  0,  0,  0,  0,  0,  1
        }; // 15
        private static readonly int[] WHermit =
        {
            0,  0,  0,  0,  0,  0,  0,  0,  0,
            1,  0,  0,  0,  0,  1,  0,  0,  0
        };
        private static readonly int[] WInvestigator =
        {
            0,  0,  0,  1,  0,  0,  1,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  0
        };
        private static readonly int[] WKnight =
        {
            0,  0,  0,  0,  0,  1,  0,  0,  0,
            0,  0,  0,  0,  1,  0,  0,  0,  0
        };
        private static readonly int[] WNoble = WKnight;
        private static readonly int[] WPirate =
        {
            0,  0,  0,  1,  0,  0,  0,  0,  0,
            0,  0,  1,  0,  0,  0,  0,  0,  0
        }; // 20
        private static readonly int[] WSage =
        {
            0,  0,  1,  0,  0,  1,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  0
        };
        private static readonly int[] WSailor = WPirate;
        private static readonly int[] WSmuggler =
        {
            0,  0,  0,  1,  1,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  0
        };
        private static readonly int[] WSoldier =
        {
            0,  0,  0,  1,  0,  0,  0,  1,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  0
        };
        private static readonly int[] WSpy = WCriminal; // 25
        private static readonly int[] WUrchin =
        {
            0,  0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  1,  1,  0
        };
        #endregion

        public static Background Acolyte = new Background
        { ID = 0, Name = "Acolyte", proficiencyTable = WAcolyte, PsychMod = MAcolyte };
        public static Background Anthropologist = new Background
        { ID = 1, Name = "Anthropologist", proficiencyTable = WAnthropologist, PsychMod = MAnthropologist};
        public static Background Athlete = new Background
        { ID = 2, Name = "Athlete", proficiencyTable = WAthlete, PsychMod = MAthlete};
        public static Background Charlatan = new Background
        { ID = 3, Name = "Charlatan", proficiencyTable = WCharlatan, PsychMod = MCharlatan};
        public static Background CityWatch = new Background
        { ID = 4, Name = "City Watch", proficiencyTable = WCityWatch, PsychMod = MCityWatch};
        public static Background ClanCrafter = new Background
        { ID = 5, Name = "Clan Crafter", proficiencyTable = WClanCrafter, PsychMod = MClanCrafter};
        public static Background Courtier = new Background
        { ID = 6, Name = "Courtier", proficiencyTable = WCourtier, PsychMod = MCourtier};
        public static Background Criminal = new Background
        { ID = 7, Name = "Criminal", proficiencyTable = WCriminal, PsychMod = MCriminal};
        public static Background Entertainer = new Background
        { ID = 8, Name = "Entertainer", proficiencyTable = WEntertainer, PsychMod = MEntertainer};
        public static Background Faceless = new Background
        { ID = 9, Name = "Faceless", proficiencyTable = WFaceless, PsychMod = MFaceless};
        public static Background Fisher = new Background
        { ID = 10, Name = "Fisher", proficiencyTable = WFisher, PsychMod = MFisher};
        public static Background FolkHero = new Background
        { ID = 11, Name = "Folk Hero", proficiencyTable = WFolkHero, PsychMod = MFolkHero};
        public static Background Gladiator = new Background
        { ID = 12, Name = "Gladiator", proficiencyTable = WGladiator, PsychMod = MSoldier};
        public static Background GuildArtisan = new Background
            {ID = 13, Name = "Guild Artisan", proficiencyTable = WGuildArtisan, PsychMod = MGuildArtisan};
        public static Background GuildMerchant = new Background
            {ID = 14, Name = "Guild Merchant", proficiencyTable = WGuildMerchant, PsychMod = MGuildMerchant};
        public static Background HauntedOne = new Background
        { ID = 15, Name = "Haunted One", proficiencyTable = WHauntedOne, PsychMod = MHauntedOne};
        public static Background Hermit = new Background
        { ID = 16, Name = "Hermit", proficiencyTable = WHermit, PsychMod = MHermit};
        public static Background Investigator = new Background
        { ID = 17, Name = "Investigator", proficiencyTable = WInvestigator, PsychMod = MInvestigator};
        public static Background Knight = new Background
        { ID = 18, Name = "Knight", proficiencyTable = WKnight, PsychMod = MKnight};
        public static Background Noble = new Background
        { ID = 19, Name = "Noble", proficiencyTable = WNoble, PsychMod = MNoble};
        public static Background Pirate = new Background
        { ID = 20, Name = "Pirate", proficiencyTable = WPirate, PsychMod = MPirate};
        public static Background Sage = new Background
        { ID = 21, Name = "Sage", proficiencyTable = WSage, PsychMod = MSage};
        public static Background Sailor = new Background
        { ID = 22, Name = "Sailor", proficiencyTable = WSailor, PsychMod = MSailor};
        public static Background Smuggler = new Background
        { ID = 23, Name = "Smuggler", proficiencyTable = WSmuggler, PsychMod = MSmuggler};
        public static Background Soldier = new Background
        { ID = 24, Name = "Soldier", proficiencyTable = WSoldier, PsychMod = MSoldier};
        public static Background Spy = new Background
        { ID = 25, Name = "Spy", proficiencyTable = WSpy, PsychMod = MSpy};
        public static Background Urchin = new Background
        { ID = 26, Name = "Urchin", proficiencyTable = WUrchin, PsychMod = MUrchin};
        private static readonly Background[] backgrounds = {
            Acolyte, Anthropologist, Athlete, Charlatan, CityWatch, ClanCrafter, Courtier, Criminal,
            Entertainer, Faceless, Fisher, FolkHero, Gladiator, GuildArtisan, GuildMerchant, HauntedOne,
            Hermit, Investigator, Knight, Noble, Pirate, Sage, Sailor, Smuggler, Soldier, Spy, Urchin
        };

    }
}
