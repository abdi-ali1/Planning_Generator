namespace DTO.Models.CompanyModels
{
    public class Company
    {
        private int id;
        private string name;
        private List<CompanySchedule>? schedules;
        private List<WeeklyNeed>? weeklyNeeds;

        public string Name
        {
            get { return name; }
        }
        public List<CompanySchedule> Schedules
        {
            get => schedules;
            set => schedules = value;
        }
        public List<WeeklyNeed> WeeklyNeeds
        {
            get => weeklyNeeds;
            set => weeklyNeeds = value;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Company(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Company(
            int id,
            string name,
            List<CompanySchedule> schedules,
            List<WeeklyNeed> weeklyNeeds
        ) : this(id, name)
        {
            this.schedules = schedules;
            this.weeklyNeeds = weeklyNeeds;
        }
    }
}
