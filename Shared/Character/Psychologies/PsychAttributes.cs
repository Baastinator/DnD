using System;
using System.Collections.Generic;
using System.Text;

namespace DND.Character.Psychologies
{
    class PsychAttributes
    {
        private Attrib[] attribs;
        public PsychAttributes()
        {
            //attributes taken from dwarf fortress, very cool system they got over there
            List<string> attributeList = new List<string>()
            {
                "law","loyalty","power","truth","cunning","eloquence","fairness","tradition","decorum",
                "art","cooperation","independence","stoicism","introspection","self-control","tranquility",
                "harmony","craftsmanship","martial prowess",""

            };
            attribs = new Attrib[attributeList.Count];
        }
        public int getAttribVal()
        {
            Randomiser rng = new Randomiser(new int[] { 10, 20, 30, 50, 30, 20, 10});
            return rng.Roll();
        }
    }
}
