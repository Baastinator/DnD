
namespace DND.Shared.Entities.Characters

{
    public class Background : INameable
    {
        public int[] proficiencyTable { get; set; }
        public static Background[] Backgrounds => backgrounds;

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
        public static Background Acolyte = new Background
        { ID = 0, Name = "Acolyte", proficiencyTable = WAcolyte };
        public static Background Anthropologist = new Background
        { ID = 1, Name = "Anthropologist", proficiencyTable = WAnthropologist };
        public static Background Athlete = new Background
        { ID = 2, Name = "Athlete", proficiencyTable = WAthlete };
        public static Background Charlatan = new Background
        { ID = 3, Name = "Charlatan", proficiencyTable = WCharlatan };
        public static Background CityWatch = new Background
        { ID = 4, Name = "City Watch", proficiencyTable = WCityWatch };
        public static Background ClanCrafter = new Background
        { ID = 5, Name = "Clan Crafter", proficiencyTable = WClanCrafter };
        public static Background Courtier = new Background
        { ID = 6, Name = "Courtier", proficiencyTable = WCourtier };
        public static Background Criminal = new Background
        { ID = 7, Name = "Criminal", proficiencyTable = WCriminal };
        public static Background Entertainer = new Background
        { ID = 8, Name = "Entertainer", proficiencyTable = WEntertainer };
        public static Background Faceless = new Background
        { ID = 9, Name = "Faceless", proficiencyTable = WFaceless };
        public static Background Fisher = new Background
        { ID = 10, Name = "Fisher", proficiencyTable = WFisher };
        public static Background FolkHero = new Background
        { ID = 11, Name = "Folk Hero", proficiencyTable = WFolkHero };
        public static Background Gladiator = new Background
        { ID = 12, Name = "Gladiator", proficiencyTable = WGladiator };
        public static Background GuildArtisan = new Background
        { ID = 13, Name = "Guild Artisan", proficiencyTable = WGuildArtisan };
        public static Background GuildMerchant = new Background
        { ID = 14, Name = "Guild Merchant", proficiencyTable = WGuildMerchant };
        public static Background HauntedOne = new Background
        { ID = 15, Name = "Haunted One", proficiencyTable = WHauntedOne };
        public static Background Hermit = new Background
        { ID = 16, Name = "Hermit", proficiencyTable = WHermit };
        public static Background Investigator = new Background
        { ID = 17, Name = "Investigator", proficiencyTable = WInvestigator };
        public static Background Knight = new Background
        { ID = 18, Name = "Knight", proficiencyTable = WKnight };
        public static Background Noble = new Background
        { ID = 19, Name = "Noble", proficiencyTable = WNoble };
        public static Background Pirate = new Background
        { ID = 20, Name = "Pirate", proficiencyTable = WPirate };
        public static Background Sage = new Background
        { ID = 21, Name = "Sage", proficiencyTable = WSage };
        public static Background Sailor = new Background
        { ID = 22, Name = "Sailor", proficiencyTable = WSailor };
        public static Background Smuggler = new Background
        { ID = 23, Name = "Smuggler", proficiencyTable = WSmuggler };
        public static Background Soldier = new Background
        { ID = 24, Name = "Soldier", proficiencyTable = WSoldier };
        public static Background Spy = new Background
        { ID = 25, Name = "Spy", proficiencyTable = WSpy };
        public static Background Urchin = new Background
        { ID = 26, Name = "Urchin", proficiencyTable = WUrchin };
        private static readonly Background[] backgrounds = {
            Acolyte, Anthropologist, Athlete, Charlatan, CityWatch, ClanCrafter, Courtier, Criminal,
            Entertainer, Faceless, Fisher, FolkHero, Gladiator, GuildArtisan, GuildMerchant, HauntedOne,
            Hermit, Investigator, Knight, Noble, Pirate, Sage, Sailor, Smuggler, Soldier, Spy, Urchin
        };

    }
}
