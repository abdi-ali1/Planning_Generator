using Logic.Employee.Degrees;
using Logic.Employee.Formules;
using Logic.Enum;
using Logic.Schedules.Staff;
using Logic.Shifts.Availibiltiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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




        public void AddSchedule(StaffSchedule staffSchedule)
        {
            schedule.Add(staffSchedule);
        }

        public void AddAvailibilty(AvailibiltyStaff availibiltyStaff)
        {
           Availibilty.Add(availibiltyStaff);
        }







    }
}
