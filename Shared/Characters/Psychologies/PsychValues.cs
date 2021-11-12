namespace DND.Characters.Psychologies
{
    public class PsychValues
    {
        public PsychValue[] Values { get; set; }

        public PsychValues()
        {
            Values = PsychValue.Values;
            foreach (var t in Values)
            {
                t.Value = Randomiser.NormalDist();
            }
        }
    }
}
