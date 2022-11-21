using Logic.Companys.Request;
using Logic.Schedules.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Companys
{
    public class Company
    {
        private string name;
        private List<CompanySchedule> schedules;
        private WeeklyNeed WeeklyNeed;
 

        public string Name { get { return name; } }
        public List<CompanySchedule> Schedules { get => schedules; set => schedules = value; }

        public Company(string name)
        {
            this.name = name;
        }

        public Company(string name, DateTime addedTime, List<CompanySchedule> schedules) : this(name)
        {
            this.schedules = schedules;
        }
    }
}
