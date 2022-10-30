﻿using Logic.Employee.Degrees;
using Logic.Employee.Formules;
using Logic.Enum;
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
        private string name;
        private Gender gender;
        private CompanyRole role;
        private Age age;
        private List<Degree> allDegrees = new List<Degree>();
        private staffSchedule schedule;

        //properties (getters//setters)

        public string Name { get { return name; } }
        public Gender Gender { get { return gender; } }
        public CompanyRole Role { get { return role; } }
        public int Age { get { return age.GetCurrentAge(); } }

        public IList<Degree> AllDegrees { get { return allDegrees.AsReadOnly(); } }

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



        public StaffMember(string name, Gender gender, CompanyRole role, Age age, List<Degree> degrees)
        {
            this.name = name;
            this.gender = gender;
            this.role = role;
            this.age = age;
            this.allDegrees = degrees;
        }

        public StaffMember(string name, Gender gender, CompanyRole role, Age age, Degree degree)
        {
            this.name = name;
            this.gender = gender;
            this.role = role;
            this.age = age;
            allDegrees.Add(degree);
        }


    }
}