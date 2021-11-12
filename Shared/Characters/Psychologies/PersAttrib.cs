namespace DND.Characters.Psychologies
{
    public class PersAttrib
    {
        private double _value;
        public int ID { get; set; }
        public string Name { get; set; }
        public string[] Descriptor { get; set; }
        public double Value
        {
            get => _value;
            set
            {
                if (value > 10.0d)
                {
                    _value = 10.0d;
                }
                else if (value < -10.0d)
                {
                    _value = -10.0d;
                }
                else
                {
                    _value = value;
                }
            }
        }
        public PersAttrib()
        {
            Value = 0.0d;
        }
        private static readonly string[][] descriptors =
        {
            new[] {"Loves Easily","No Love"},
            new[] {"Hates Easily","No Hate"},
            new[] {"Envies Easily","No Envy"},
            new[] {"Easily Cheerful","Cheerless"},
            new[] {"Easily Sad","No Sadness"},
            new[] {"Easily Angered","No Anger"},
            new[] {"Very Anxious","No Anxiety"},
            new[] {"Lustful","No Lust"},
            new[] {"Vulnerable To Stress"},
            new[] {"Greedy"},
            new[] {"Intemperate"},
            new[] {"Likes Brawls","Avoids Fights"},
            new[] {"Too Stubborn","Quits Easily"},
            new[] {"Wasteful","Miserliness"},
            new[] {"Discord","Harmony"},
            new[] {"Flatterer","Quarreler"},
            new[] {"Polite","Rude"},
            new[] {"Disdains Advice","Overreliant"},
            new[] {"Fearless","Fearful"},
            new[] {"Overconfident","Timid"},
            new[] {"Vain"},
            new[] {"Ambitious"},
            new[] {"Sense of Gratitude"},
            new[] {"Extravagant","Austere"},
            new[] {"Humorful","Humorless"},
            new[] {"Vengeful"},
            new[] {"Proud","No Self-Esteem"},
            new[] {"Cruel","Merciful"},
            new[] {"Scatterbrained","Singleminded"},
            new[] {"Hopeful","Despairs"},
            new[] {"Curious","Incurious"},
            new[] {"Shameless","Bashful"},
            new[] {"Private","Oversharing"},
            new[] {"Perfectionist","Inattentive"},
            new[] {"Tolerates Differences"},
            new[] {"Emotionally Obsessive"},
            new[] {"Swayed by Emotions"},
            new[] {"Altruistic"},
            new[] {"Dutiful"},
            new[] {"Thoughtless","Too deliberate"},
            new[] {"Orderly","Sloppy"},
            new[] {"Too Trusting","Distrustful"},
            new[] {"Gregarious","Loner"},
            new[] {"Overbearing","Non-Assertive"},
            new[] {"Frenetic","Leisurely"},
            new[] {"Excitement Seeking"},
            new[] {"Inclined to Abstract"},
            new[] {"Inclined to create Art"}
        };

        public static PersAttrib[] PersAttribs => persAttribs;

        #region PersonalityAttribs
        public static PersAttrib Love = new PersAttrib { ID = 0, Descriptor = descriptors[0], Name = "Love" };
        public static PersAttrib Hate = new PersAttrib { ID = 1, Descriptor = descriptors[1], Name = "Hate" };
        public static PersAttrib Envy = new PersAttrib { ID = 2, Descriptor = descriptors[2], Name = "Envy" };
        public static PersAttrib Cheerfulness = new PersAttrib { ID = 3, Descriptor = descriptors[3], Name = "Cheerfulness" };
        public static PersAttrib Sadness = new PersAttrib { ID = 4, Descriptor = descriptors[4], Name = "Sadness" };
        public static PersAttrib Anger = new PersAttrib { ID = 5, Descriptor = descriptors[5], Name = "Anger" };
        public static PersAttrib Anxiety = new PersAttrib { ID = 6, Descriptor = descriptors[6], Name = "Anxiety" };
        public static PersAttrib Lust = new PersAttrib { ID = 7, Descriptor = descriptors[7], Name = "Lust" };
        public static PersAttrib Stressed = new PersAttrib { ID = 8, Descriptor = descriptors[8], Name = "Stressed" };
        public static PersAttrib Greed = new PersAttrib { ID = 9, Descriptor = descriptors[9], Name = "Greed" };
        public static PersAttrib Intemperance = new PersAttrib { ID = 10, Descriptor = descriptors[10], Name = "Intemperance" };
        public static PersAttrib Brawler = new PersAttrib { ID = 11, Descriptor = descriptors[11], Name = "Brawler" };
        public static PersAttrib Persistance = new PersAttrib { ID = 12, Descriptor = descriptors[12], Name = "Persistance" };
        public static PersAttrib Wastefulness = new PersAttrib { ID = 13, Descriptor = descriptors[13], Name = "Wastefulness" };
        public static PersAttrib Discord = new PersAttrib { ID = 14, Descriptor = descriptors[14], Name = "Discord" };
        public static PersAttrib Flatterer = new PersAttrib { ID = 15, Descriptor = descriptors[15], Name = "Flatterer" };
        public static PersAttrib Politeness = new PersAttrib { ID = 16, Descriptor = descriptors[16], Name = "Politeness" };
        public static PersAttrib DislikesAdvice = new PersAttrib { ID = 17, Descriptor = descriptors[17], Name = "Dislikes Advice" };
        public static PersAttrib Fearlessness = new PersAttrib { ID = 18, Descriptor = descriptors[18], Name = "Fearlessness" };
        public static PersAttrib Confidence = new PersAttrib { ID = 19, Descriptor = descriptors[19], Name = "Confidence" };
        public static PersAttrib Vain = new PersAttrib { ID = 20, Descriptor = descriptors[20], Name = "Vain" };
        public static PersAttrib Ambition = new PersAttrib { ID = 21, Descriptor = descriptors[21], Name = "Ambition" };
        public static PersAttrib Gratefulness = new PersAttrib { ID = 22, Descriptor = descriptors[22], Name = "Gratefulness" };
        public static PersAttrib Extravagant = new PersAttrib { ID = 23, Descriptor = descriptors[23], Name = "Extravagant" };
        public static PersAttrib Humor = new PersAttrib { ID = 24, Descriptor = descriptors[24], Name = "Humor" };
        public static PersAttrib Vengefulness = new PersAttrib { ID = 25, Descriptor = descriptors[25], Name = "Vengefulness" };
        public static PersAttrib Pride = new PersAttrib { ID = 26, Descriptor = descriptors[26], Name = "Pride" };
        public static PersAttrib Cruelty = new PersAttrib { ID = 27, Descriptor = descriptors[27], Name = "Cruelty" };
        public static PersAttrib Fuzziness = new PersAttrib { ID = 28, Descriptor = descriptors[28], Name = "Fuzziness" };
        public static PersAttrib Hopefulness = new PersAttrib { ID = 29, Descriptor = descriptors[29], Name = "Hopefulness" };
        public static PersAttrib Curiosity = new PersAttrib { ID = 30, Descriptor = descriptors[30], Name = "Curiosity" };
        public static PersAttrib Shamelessness = new PersAttrib { ID = 31, Descriptor = descriptors[31], Name = "Shamelessness" };
        public static PersAttrib Reservedness = new PersAttrib { ID = 32, Descriptor = descriptors[32], Name = "Reservedness" };
        public static PersAttrib Perfectionism = new PersAttrib { ID = 33, Descriptor = descriptors[33], Name = "Perfectionism" };
        public static PersAttrib Tolerant = new PersAttrib { ID = 34, Descriptor = descriptors[34], Name = "Tolerant" };
        public static PersAttrib EmotionallyObsessive = new PersAttrib { ID = 35, Descriptor = descriptors[35], Name = "Emotionally Obsessive" };
        public static PersAttrib Emotional = new PersAttrib { ID = 36, Descriptor = descriptors[36], Name = "Emotional" };
        public static PersAttrib Altruistic = new PersAttrib { ID = 37, Descriptor = descriptors[37], Name = "Altruistic" };
        public static PersAttrib Dutiful = new PersAttrib { ID = 38, Descriptor = descriptors[38], Name = "Dutiful" };
        public static PersAttrib Thoughtlessness = new PersAttrib { ID = 39, Descriptor = descriptors[39], Name = "Thoughtlessness" };
        public static PersAttrib Orderliness = new PersAttrib { ID = 40, Descriptor = descriptors[40], Name = "Orderliness" };
        public static PersAttrib Trusting = new PersAttrib { ID = 41, Descriptor = descriptors[41], Name = "Trusting" };
        public static PersAttrib Gregarious = new PersAttrib { ID = 42, Descriptor = descriptors[42], Name = "Gregarious" };
        public static PersAttrib Assertive = new PersAttrib { ID = 43, Descriptor = descriptors[43], Name = "Assertive" };
        public static PersAttrib Frenetic = new PersAttrib { ID = 44, Descriptor = descriptors[44], Name = "Frenetic" };
        public static PersAttrib Adventurous = new PersAttrib { ID = 45, Descriptor = descriptors[45], Name = "Adventurous" };
        public static PersAttrib Abstracting = new PersAttrib { ID = 46, Descriptor = descriptors[46], Name = "Abstracting" };
        public static PersAttrib Artistic = new PersAttrib { ID = 47, Descriptor = descriptors[47], Name = "Artistic" };
        #endregion
        private static readonly PersAttrib[] persAttribs =
        {
            Love, Hate, Envy, Cheerfulness, Sadness, Anger, Anxiety, Lust, Stressed, Greed, Intemperance, Brawler, Persistance,
            Wastefulness, Discord, Flatterer, Politeness, DislikesAdvice, Fearlessness, Confidence, Vain, Ambition, Gratefulness,
            Extravagant, Humor, Vengefulness, Pride, Cruelty, Fuzziness, Hopefulness, Curiosity, Shamelessness, Reservedness,
            Perfectionism, Tolerant, EmotionallyObsessive, Emotional, Altruistic, Dutiful, Thoughtlessness, Orderliness, Trusting,
            Gregarious, Assertive, Frenetic, Adventurous, Abstracting, Artistic
        };

    }
}
