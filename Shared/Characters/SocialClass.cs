namespace DND.Characters
{
    public class SocialClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int[] JobWeightTable { get; set; }
        public static SocialClass[] SocialClasses => socialClasses;

        private static readonly SocialClass[] socialClasses = 
        {
            new SocialClass {}
        };
    }
}
