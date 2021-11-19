namespace DND.Shared.Entities.Characters.Psychologies
{
    public class PsychValues
    {
        private readonly double[] _mod;
        public PsychValue[] Values { get; set; }

        public static double[] empty =
            {0.0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        public PsychValues(double[] mod,bool randomise = true)
        {
            Values = PsychValue.Values;
            for (int i = 0; i < Values.Length; i++)
            {
                if (randomise)
                {
                    Values[i].Value = Randomiser.NormalDist() + mod[i];
                }
                else
                {
                    Values[i].Value = mod[i];
                }
            }
        }
        public static PsychValues operator +(PsychValues a, PsychValues b)
        {
            var c = new PsychValues(empty, false);
            for (int i = 0; i < a.Values.Length; i++)
            {
                c.Values[i].Value = a.Values[i].Value + b.Values[i].Value;
            }

            return c;
        }
    }
}
