using Logic.Employee.Degrees;
using Logic.Employee.Formules;
using Logic.Enum;
using Logic.Schedules;
using Logic.Schedules.Company;
using Logic.Schedules.Staff;
using Logic.Shifts.Availibiltiy;


namespace Logic.Employee
{
    [Serializable]
    public class StaffMember
    {
        //fields 
        private string username;
        private string name;
        private Gender gender;
        private CompanyRole role;
        private Occaption occaption;
        private DateTime birtDate;
        private Degree degree;

        private List<StaffSchedule> schedule = new List<StaffSchedule>();
        private List<AvailibiltyStaff> availibilty = new List<AvailibiltyStaff>();


        //properties (getters//setters)
        public string Username { get { return username; } }
        public string Name { get { return name; } }
        public Gender Gender { get { return gender; } }
        public CompanyRole Role { get { return role; } }
        public int Age { get { return AgeCalculater.GetCurrentAge(birtDate); } }
        public Occaption Occaption { get { return occaption; } }
        public Degree Degree { get { return degree; } }

        public IList<StaffSchedule> Schedule { get { return schedule.AsReadOnly(); }  }
        public IList<AvailibiltyStaff> Availibilty { get { return availibilty.AsReadOnly(); } }

        public StaffMember(string username, string name, Gender gender, CompanyRole role, Occaption occaption, DateTime birtDate, Degree degree)
        {
            this.username = username;
            this.name = name;
            this.gender = gender;
            this.role = role;
            this.occaption = occaption;
            this.birtDate = birtDate;
            this.degree = degree;
        }


        public StaffMember(string username, string name, Gender gender, CompanyRole role, Occaption occaption, DateTime birtDate, Degree degree,
            List<StaffSchedule> staffSchedules, List<AvailibiltyStaff> availibilties):
            this(username, name, gender, role, occaption, birtDate, degree)
        {
            this.schedule = staffSchedules;
            this.availibilty = availibilties;
        }

        /// <summary>
        /// Adds a StaffSchedule object to the list of schedules for the staff member.
        /// </summary>
        /// <param name="staffSchedule">The StaffSchedule object to be added to the list.</param>
        /// <returns>
        /// A Result<string> object indicating the success or failure of the operation. If the operation is successful,
        /// the Ok variant will contain a string message indicating that the StaffSchedule object was added to the list. 
        /// If the operation fails, the Fail variant will contain an Exception object with more information about the 
        /// error.
        /// </returns>
        public Result<string> AddSchedule(StaffSchedule staffSchedule)
        {
            try
            {
                if (!schedule.Any(x => x.Equals(staffSchedule)))
                {
                    schedule.Add(staffSchedule);
                    return Result<string>.Ok("schedule is added to list");
                }

                return Result<string>.Fail(new Exception("schedule for this date already exist"));
            }
            catch (Exception e)
            {
                return Result<string>.Fail(e);
            }
          
        }

        /// <summary>
        /// Adds a AvailibiltyStaff object to the list of availibilties for the staff member.
        /// </summary>
        /// <param name="availibiltyStaff">The availibiltyStaff object to be added to the list.</param>
        /// <returns>
        /// A Result<string> object indicating the success or failure of the operation. If the operation is successful,
        /// the Ok variant will contain a string message indicating that the StaffSchedule object was added to the list. 
        /// If the operation fails, the Fail variant will contain an Exception object with more information about the 
        /// error.
        /// </returns>
        public Result<string> AddAvailibilty(AvailibiltyStaff availibiltyStaff)
        {
            try
            {
                if (!availibilty.Any(x => x.Equals(availibiltyStaff)))
                {
                    Availibilty.Add(availibiltyStaff);
                    return Result<string>.Ok("is added to list");
                }

                return Result<string>.Fail(new Exception("schedule for this date already exist"));
            }
            catch (Exception e)
            {

                return Result<string>.Fail(e);
            }
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            StaffMember staff = (StaffMember)obj;
            return (username == staff.Username);
        }







    }
}
