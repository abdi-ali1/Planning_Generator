using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Schedules.Company
{
    public class CompanySchedule
    {
        private DateTime currentWeek; 
        
        private List<StaffMember> AllStaffMembers = new();


        public CompanySchedule(DateTime currentWeek, List<StaffMember> staffMembers)
        {
            this.currentWeek = currentWeek;
            this.AllStaffMembers = staffMembers;
        }

       

    }
}
