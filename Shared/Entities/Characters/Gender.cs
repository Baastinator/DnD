using DND.Shared.Interfaces.Implementations;

namespace DND.Shared.Entities.Characters
{
    public class Gender : Nameable
    {
        public static Gender Male = new Gender {ID = 0, Name = "Male"};
        public static Gender Female = new Gender {ID = 1, Name = "Female"};
        public static Gender Other = new Gender {ID = 2, Name = "Other"};

        public static Gender[] Genders =
        {
            Male, Female, Other
        };
    }
}
