using Logic.Companys.Request;
using Logic.Schedules.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic
{
    public interface ICompany
    {
        public string Name { get;  }

        public List<CompanySchedule> Schedules { get; set; }
        public List<WeeklyNeed> WeeklyNeed { get; set; }

    }
}
