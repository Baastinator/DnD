using System.Net;
using DND.Shared.Interfaces.Implementations;
using static DND.Shared.Entities.Characters.Professions.ProfessionWeights;

namespace DND.Shared.Entities.Characters
{
    public class SocialClass : Nameable
    {
        public int[] JobWeightTable { get; set; }
        public double[] PsychMod { get; set; }

        private static readonly double[][] valueMod = {
            new[] { 
                0,   0,   2,   1,   0,       0,   0,  -1,   1,  -1,       1,   1, 0.2,   1,   0,
               -1,  -1,   0,   1,   0,       1,   1,-0.5,   0, 0.5,       1,   0,   2, 0.5
            },
            new[] {
                1,   1,   0,   0,   1,     0.5, 0.3,   1,   0, 0.5,       1, 0.5,   1,   0, 0.2,
                0,   0,   0,   1,   0,     0.5, 0.5, 0.5, 0.5,   0,     0.5,   0,   2,   1
            },
            new[] {
                0,   0,   1,   1,-0.2,       0,   0,-0.2,   1,  -1,     0.5,   1, 0.2,   1,   0,
               -1,   0,   0,   1,   0,       1,   1,-0.5,   0, 0.5,       1,   0,   2, 0.5
            },
            new[] {
                0,   1,   1,   1,   0,       0,-0.5, 0.5, 0.5,   0,       1,   1, 0.3,   1,   0,
               -1,   1,   0,   1,   0,       2,   1,-0.3,-0.3, 0.7,     0.3,   0,   2,   1
            },
            new[] {
                0,   0,   0,   2, 0.2,       0, 0.5,   1,   0,   1,       1,   1, 0.5, 0.2,   0,
                1,   1,   0,   1,   0,       1, 0.5,   0, 0.5, 0.5,       0,   0,   2, 1.5
            },
            new[] { 
                1,   1,   0,   0,   1,       0,   0, 0.5,   1, 0.5,       1, 0.7,   1, 0.5,   0,
                1,   0,   0,   1,   2,       1, 0.5, 0.5,   0,   1,    -0.2,   0,   1, 1.5
            },
            new[] {
                1,   1,   2,-0.5,   1,       1, 0.5,   1,-0.5,   1,       2, 0.5,   1,   0,-0.5,
                1,   0,   0,   1,   0,       1, 0.3, 0.5,   0,-0.5,       2,   0,   2,   2
            },
            new[] {
                2,-0.5,   2,  -1,   2,     0.5,   1,   2,  -1,   2,       2, 0.5,   1,   0,  -1,
                1,   0,   0,   1,   0,       1, -.3,  .5,   0, -.5,       2,   0,   2,   2
            },
            new[] {
                1,   1,   0,   1,   1,       0,   0,   0,   1, -.5,       1,   1,  .2,   2,   0,
                0,   0,   0,   1,   1,      .5,   1,   2,   0,   2,      .2,   0,  -1,   0
            },
            new[] {
               -1,  .5,   0,   1,  .5,       0,   0,  -1,   1,  -1,       0,   1,   0,   1,   0,
               -1,   0,   0,   1,   1,      .5,   1,   1,   0,   1,       0,  .5,   2,   0
            }, 
            new [] {
               -2, 2.0,   1,   1,  -2,       0,   2,   2,  -1,  -1,      -1,   1,   0,   1,  -1,
                0,   0,   0,   1,   0,       1,  -1,  -1,   0,   0,       0,   0,   0,   0,   
            },
            new []
            {
                0, 0.0,   0,   0,   0,       2,  -1,  -1,   0,   0,      -1,   0,   1,   1,   1,
                0,   0,   0,   0,   0,       0,   0,   0,  -1,   1,       0,   0,   0,   1
            }
        };

        public static SocialClass RuralPeasant,
            RuralLandowner,
            CityPeasant,
            CityTradesman,
            CityMerchant,
            Knight,
            LowAristocracy,
            HighAristocracy,
            Warrior,
            Sailor,
            Criminal,
            Scholar;
        public static readonly SocialClass[] SocialClasses;

        static SocialClass()
        {
            RuralPeasant = new SocialClass { ID = 0, Name = "Rural Peasant", JobWeightTable = ProfessionWeightList[0], PsychMod = valueMod[0] };
            RuralLandowner = new SocialClass { ID = 1, Name = "Rural Landowner", JobWeightTable = ProfessionWeightList[1], PsychMod = valueMod[1] };
            CityPeasant = new SocialClass { ID = 2, Name = "City Peasant", JobWeightTable = ProfessionWeightList[2], PsychMod = valueMod[2] };
            CityTradesman = new SocialClass { ID = 3, Name = "City Tradesman", JobWeightTable = ProfessionWeightList[3], PsychMod = valueMod[3] };
            CityMerchant = new SocialClass { ID = 4, Name = "City Merchant", JobWeightTable = ProfessionWeightList[4], PsychMod = valueMod[4] };
            Knight = new SocialClass { ID = 5, Name = "Knight", JobWeightTable = ProfessionWeightList[5], PsychMod = valueMod[5] };
            LowAristocracy = new SocialClass { ID = 6, Name = "Low Aristocracy", JobWeightTable = ProfessionWeightList[6], PsychMod = valueMod[6] };
            HighAristocracy = new SocialClass { ID = 7, Name = "High Aristocracy", JobWeightTable = ProfessionWeightList[7], PsychMod = valueMod[7] };
            Warrior = new SocialClass { ID = 8, Name = "Warrior", JobWeightTable = ProfessionWeightList[8], PsychMod = valueMod[8] };
            Sailor = new SocialClass { ID = 9, Name = "Sailor", JobWeightTable = ProfessionWeightList[9], PsychMod = valueMod[9] };
            Criminal = new SocialClass { ID = 10, Name = "Criminal", JobWeightTable = ProfessionWeightList[10], PsychMod = valueMod[10] };
            Scholar = new SocialClass { ID = 11, Name = "Scholar", JobWeightTable = ProfessionWeightList[11], PsychMod = valueMod[11] };
            SocialClasses = new []
            {
                RuralPeasant, RuralLandowner, CityPeasant, CityTradesman, CityMerchant,
                Knight, LowAristocracy, HighAristocracy, Warrior, Sailor,
                Criminal, Scholar
            };
        }

    }
}
