using DND.Characters.Professions;

namespace DND.Characters
{
    public class SocialClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int[] JobWeightTable { get; set; }
        public static SocialClass[] SocialClasses => socialClasses;

        public static SocialClass RuralPeasant = new SocialClass { ID = 0, Name = "Rural Peasant", JobWeightTable = ProfessionWeights.RuralPeasant};
        public static SocialClass RuralLandowner = new SocialClass { ID = 1, Name = "Rural Landowner", JobWeightTable = ProfessionWeights.RuralLandowner};
        public static SocialClass CityPeasant = new SocialClass { ID = 2, Name = "City Peasant", JobWeightTable = ProfessionWeights.CityPeasant};
        public static SocialClass CityTradesman = new SocialClass { ID = 3, Name = "City Tradesman", JobWeightTable = ProfessionWeights.CityTradesman};
        public static SocialClass CityMerchant = new SocialClass { ID = 4, Name = "City Merchant", JobWeightTable = ProfessionWeights.CityMerchant};
        public static SocialClass Knight = new SocialClass { ID = 5, Name = "Knight", JobWeightTable = ProfessionWeights.Knight};
        public static SocialClass LowAristocracy = new SocialClass { ID = 6, Name = "Low Aristocracy", JobWeightTable = ProfessionWeights.LowAristocracy};
        public static SocialClass HighAristocracy = new SocialClass { ID = 7, Name = "High Aristocracy", JobWeightTable = ProfessionWeights.HighAristocracy};
        public static SocialClass Warrior = new SocialClass { ID = 8, Name = "Warrior", JobWeightTable = ProfessionWeights.Warrior};
        public static SocialClass Sailor = new SocialClass { ID = 9, Name = "Sailor", JobWeightTable = ProfessionWeights.Sailor};
        private static readonly SocialClass[] socialClasses = 
        {
            RuralPeasant, RuralLandowner, CityPeasant, CityTradesman, CityMerchant,
            Knight, LowAristocracy, HighAristocracy, Warrior, Sailor
        };
    }
}
