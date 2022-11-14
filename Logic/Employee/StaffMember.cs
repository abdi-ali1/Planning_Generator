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
    public class StaffMember
    {
        //fields 
        private string username;
        private string name;
        private Gender gender;
        private CompanyRole role;
        private Occaption occaption;
        private Age age;
        private Degree degree;
        private StaffSchedule schedule;
        private AvailibiltyStaff availibilty;




        //properties (getters//setters)
        public string Name { get { return name; } }
        public Gender Gender { get { return gender; } }
        public CompanyRole Role { get { return role; } }
        public int Age { get { return age.GetCurrentAge(); } }
        public Occaption Occaption { get { return occaption; } }
        public AvailibiltyStaff Availibilty { get { return availibilty; } set { this.availibilty = value;} }
        public Degree Degree { get { return degree; } } 
        public StaffSchedule Schedule 
        { 
            get 
            { 
               return schedule; 
            }
            set
            {
                schedule = value;
            } 
        }
        public string Username { get { return username; } }



        public StaffMember(string username, string name, Gender gender, CompanyRole role, Occaption occaption, DateTime birthDate, Degree degree)
        {
            this.username = username;
            this.name = name;
            this.gender = gender;
            this.role = role;
            this.occaption = occaption;
            this.age = new Age(birthDate);
            this.degree = degree;
        }




    }
}
