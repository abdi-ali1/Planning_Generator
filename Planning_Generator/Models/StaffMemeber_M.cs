using Logic.Enum;

namespace Planning_Generator.Models
{
    public class StaffMemeber_M
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public CompanyRole Role { get; set; }
        public DateTime BirthDate { get; set; }
        public Occupation Occaption { get; set; }
        public Degree_M Degree_M { get; set; }

        public bool PropertiesAreNotNull()
        {
            if (Username != null &&
                Name != null &&
                Gender != null &&
                Role != null &&
                BirthDate != null &&
                Occaption != null &&
                Degree_M != null &&
                Degree_M.NameOfDegree != null &&
                Degree_M.DegreeLevel != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
