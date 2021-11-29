namespace DND.Shared.Entities.Characters.Psychologies
{
    public class Personality
    {
        public PersAttrib[] Attributes { get; set; }

        public int Longest
        {
            get
            {
                var longestP = 0;
                foreach (var attribute in Attributes)
                {
                    if (longestP < attribute.Name.Length) longestP = attribute.Name.Length;
                }

                return longestP + 1;
            }
        }
        public Personality()
        {

            Attributes = PersAttrib.PersAttribs;
            foreach (var t in Attributes)
            {
                t.Value = Randomiser.NormalDist(0, 2);
            }
        }
    }
}
