
namespace DND.Characters.Psychologies
{
    public class Attrib
    {
        private byte _val;
        public int val
        {
            get => _val;
            set
            {
                if (value > 6)
                {
                    value = 6;
                } 
                else if (value < 0)
                {
                    value = 0;
                }
                _val = (byte)value;
            }
        }
        public Attrib(int value)
        {
            if (value > 6)
            {
                value = 6;
            }
            else if (value < 0)
            {
                value = 0;
            }
            _val = (byte)value;
        }
    }
}
