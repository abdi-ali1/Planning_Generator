using Logic.Employee.Degrees;
using Logic.Employee.Formules;
using Logic.Enum;
using Logic.Schedules.Staff;
using Logic.Shifts.Availibiltiy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic
{
    public interface IStaff
    {
        //properties (getters//setters)
        public string Name { get; }
        public Gender Gender { get; }
        public CompanyRole Role { get; }
        public int Age { get; }
        public Occaption Occaption { get; }
        public AvailibiltyStaff Availibilty { get; }
        public Degree Degree { get;  }
        public StaffSchedule Schedule { get; set; }

    }
}
