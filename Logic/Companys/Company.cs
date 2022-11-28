using Logic.Companys.Request;
using Logic.Schedules.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Companys
{
    [Serializable]
    public class Company: ICompany
    {
        private string name;
        private List<CompanySchedule> schedules;
        private List<WeeklyNeed> weeklyNeed;
 

        public string Name { get { return name; } }
        public List<CompanySchedule> Schedules { get => schedules; set => schedules = value; }
        public List<WeeklyNeed> WeeklyNeed { get => weeklyNeed; set => weeklyNeed = value; }

        public Company(string name)
        {
            this.name = name;
        }

        public Company(string name, List<CompanySchedule> schedules, List<WeeklyNeed> weeklyNeed):this(name)
        {
          
            this.schedules = schedules;
            this.weeklyNeed = weeklyNeed;
        }
    }
}
