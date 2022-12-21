using Logic.Employee;
using Logic.Shifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Schedules.Company
{
    public class CompanyScheduleInfo
    {

        private StaffMember staff;
        private Shift shift;

        public StaffMember Staff { get { return staff; }}
        public Shift Shift { get { return shift; } }

        public CompanyScheduleInfo(StaffMember staff, Shift shift)
        {
            this.staff = staff;
            this.shift = shift;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            CompanyScheduleInfo info = (CompanyScheduleInfo)obj;
            return (staff.Equals(info.staff)) && (shift.Equals(info.shift));
        }
    }
}
