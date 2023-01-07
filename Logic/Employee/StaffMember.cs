using Logic.Employee.Degrees;
using Logic.Employee.Formules;
using Logic.Enum;
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
        private CompanyRole companyRole;
        private Occupation occupation;
        private DateTime birthDate;
        private Degree degree;

        private List<StaffSchedule> staffSchedules = new List<StaffSchedule>();
        private List<AvailabilityStaff> availibiltyStaffs = new List<AvailabilityStaff>();

        //properties (getters//setters)
        public string Username { get { return username; } }
        public string Name { get { return name; } }
        public Gender Gender { get { return gender; } }
        public CompanyRole Role { get { return companyRole; } }
        public int Age { get { return AgeCalculater.GetCurrentAge(birthDate); } }
        public Occupation Occaption { get { return occupation; } }
        public Degree Degree { get { return degree; } }

        public IList<StaffSchedule> StaffSchedule { get { return staffSchedules.AsReadOnly(); } }
        public IList<AvailabilityStaff> AvailabilityStaff { get { return availibiltyStaffs.AsReadOnly(); } }

        public StaffMember(string username, string name, Gender gender, CompanyRole companyRole, Occupation occupation, DateTime birthDate, Degree degree)
        {
            this.username = username;
            this.name = name;
            this.gender = gender;
            this.companyRole = companyRole;
            this.occupation = occupation;
            this.birthDate = birthDate;
            this.degree = degree;
        }

        public StaffMember(string username, string name, Gender gender, CompanyRole companyRole, Occupation occupation, DateTime birthDate, Degree degree,
            List<StaffSchedule> staffSchedules, List<AvailabilityStaff> availibiltyStaffs) :
            this(username, name, gender, companyRole, occupation, birthDate, degree)
        {
            this.staffSchedules = staffSchedules;
            this.availibiltyStaffs = availibiltyStaffs;
        }

        /// <summary>
        /// Adds a staff schedule to the list of staff schedules.
        /// </summary>
        /// <param name="staffSchedule">The staff schedule to add to the list.</param>
        /// <returns>A Result object indicating the success or failure of the operation, and any error message if applicable.</returns>
        public Result<string> AddSchedule(StaffSchedule staffSchedule)
        {
            try
            {
                if (!staffSchedules.Any(x => x.Equals(staffSchedule)))
                {
                    staffSchedules.Add(staffSchedule);
                    return Result<string>.Ok("schedule is added to the list");
                }

                return Result<string>.Fail(new Exception("schedule for this date already exists"));
            }
            catch (Exception e)
            {
                return Result<string>.Fail(e);
            }
        }

        /// <summary>
        /// Adds an availability for a staff member to the list of availabilities.
        /// </summary>
        /// <param name="availibiltyStaff">The availability to add to the list.</param>
        /// <returns>A Result object indicating the success or failure of the operation, and any error message if applicable.</returns>
        public Result<string> AddAvailibilty(AvailabilityStaff availibiltyStaff)
        {
            try
            {
                if (!availibiltyStaffs.Any(x => x.Equals(availibiltyStaff)))
                {
                    AvailabilityStaff.Add(availibiltyStaff);
                    return Result<string>.Ok("is added to the list");
                }

                return Result<string>.Fail(new Exception("schedule for this date already exists"));
            }
            catch (Exception e)
            {
                return Result<string>.Fail(e);
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            StaffMember staff = (StaffMember)obj;
            return (username == staff.Username);
        }
    }
}