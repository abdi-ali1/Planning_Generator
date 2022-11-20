
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models.CompanyModels
{
    public class Company
    {
        private int id;
        private string name;
        private List<CompanySchedule> schedules;

        public string Name { get { return name; } }
        public List<CompanySchedule> Schedules { get => schedules; set => schedules = value; }
        public int Id { get { return id; } set { id = value; } }

        public Company( string name)
        {
            this.name = name;
        }

        public Company(int id, string name) : this(name)
        {
            this.id = id;
        }

        public Company(int id, string name, List<CompanySchedule> schedules) : this(id ,name)
        {
            this.schedules = schedules;
        }

        public Company(string name, List<CompanySchedule> schedules) : this(name)
        {
            this.schedules = schedules;
        }
    }
}
