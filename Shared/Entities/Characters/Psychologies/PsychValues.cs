namespace DND.Shared.Entities.Characters.Psychologies
{
    public class PsychValues
    {
        public PsychValue[] Values { get; set; }
        private const double rngMean = 0;
        private const double rngDev = 1;

        public static double[] empty =
            {0.0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        public PsychValues(double[] mod,bool randomise = true)
        {
            Values = PsychValue.Values;
            for (var i = 0; i < Values.Length; i++)
            {
                Values[i].Value = randomise ? Randomiser.NormalDist(rngMean,rngDev) + mod[i] : mod[i];
            }
        }
        public PsychValues(bool randomise)
        {
            Values = PsychValue.Values;
            for (var index = 0; index < Values.Length; index++)
            {
                var t = Values[index];
                t.Value = randomise ? Randomiser.NormalDist(rngMean,rngDev) : 0d;
                Values[index] = t;
            }
        }

        public PsychValues()
        {
            Values = PsychValue.Values;
            for (var index = 0; index < Values.Length; index++)
            {
                Values[index].Value = Randomiser.NormalDist(rngMean,rngDev);
            }
        }
    }
}
