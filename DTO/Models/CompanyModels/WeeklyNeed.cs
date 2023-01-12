namespace DTO.Models.CompanyModels
{
    public class WeeklyNeed
    {
        // fields
        private int id;
        private DateTime weekNeeded;
        private List<NeededStaff> neededStaff = new();

        // properties
        public DateTime WeekNeeded
        {
            get { return weekNeeded; }
        }
        public List<NeededStaff> NeededStaff
        {
            get { return neededStaff; }
        }
        public int Id
        {
            get { return id; }
        }

        // constructors
        public WeeklyNeed(int id, DateTime weekNeeded, List<NeededStaff> neededStaff)
        {
            this.weekNeeded = weekNeeded;
            this.neededStaff = neededStaff;
        }
    }
}
