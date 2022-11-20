using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models.StaffMemberModels
{
    public class StaffMember
    {
        //fields 
        private int  id;
        private string name;
        private int gender;
        private int role;
        private int occaption;
        private DateTime birthdate;
        private Degree degree;
        private StaffMemeberSchedule schedule;
        private AvailibiltyStaff availibilty;


        //properties (getters//setters)
        public int Id { get { return id; } }
        public string Name { get { return name; } }
        public int Gender { get { return gender; } }
        public int Role { get { return role; } }
        public DateTime birthDate { get { return birthDate; } }
        public int Occaption { get { return occaption; } }
        public AvailibiltyStaff Availibilty { get { return availibilty; } set { this.availibilty = value; } }
        public Degree Degree { get { return degree; } }
        public StaffMemeberSchedule Schedule { get { return schedule; } }




        public StaffMember(int id, string name, int gender, int role, int occaption, 
            DateTime birthdate, Degree degree, StaffMemeberSchedule schedule, AvailibiltyStaff availibilty)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.role = role;
            this.occaption = occaption;
            this.birthdate = birthdate;
            this.degree = degree;
            this.schedule = schedule;
            this.availibilty = availibilty;
        }



    }
}
