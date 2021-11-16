namespace DND.Shared.Entities.Characters.Psychologies
{
    public class Personality
    {
        public PersAttrib[] Attributes { get; set; }

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
