using Logic.Companys;
using Logic.Shifts;

namespace Planning_Generator.Models
{
    public class AvailabilityStaff_M
    {

        public DateTime WeekAvailability { get; set; }
        public Company Company { get; set; }
        public List<Shift> Shifts { get; set; }
    }
}
