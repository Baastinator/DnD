
namespace DND.Characters.Psychologies
{
    public class PsychValue
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte Value { get; set; }
        public static PsychValue[] Values => values;
        private static readonly PsychValue[] values =
        {

        };
    }
}
