
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO_BinaryFile
{
    [Serializable]
    public class Company
    {
    
        private string name;
        private List<CompanySchedule>? schedules;
        private List<WeeklyNeed>? weeklyNeeds;

        public string Name { get { return name; } }
        public List<CompanySchedule> Schedules { get => schedules; set => schedules = value; }
        public List<WeeklyNeed> WeeklyNeeds { get => weeklyNeeds; set => weeklyNeeds = value; }
     


        public Company( string name)
        {
            this.name = name;
        }

        public Company(string name, List<CompanySchedule> schedules, List<WeeklyNeed> weeklyNeeds):this( name)
        {
           
            this.schedules = schedules;
            this.weeklyNeeds = weeklyNeeds;
        }

        private Company()
        {

        }



    }
}
