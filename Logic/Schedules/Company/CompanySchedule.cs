using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Schedules.Company
{
    [Serializable]
    public class CompanySchedule
    {
        private DateTime currentWeek; 
        
        private List<StaffMember> allStaffMembers = new();

        public IList<StaffMember> AllStaffMembers { get { return allStaffMembers.AsReadOnly(); } }


        public CompanySchedule(DateTime currentWeek) 
        {
            this.currentWeek = currentWeek;
        }

        public CompanySchedule(DateTime currentWeek, List<StaffMember> staffMembers) : this(currentWeek)
        {
         
            this.allStaffMembers = staffMembers;
        }

        public bool AddStaff(StaffMember staff)
        {
            bool doesntExist = true;
            foreach (StaffMember s in allStaffMembers)
            {
                if (s.Equals(staff))
                {
                    doesntExist = false;
                    break;
                }
            }
            if (doesntExist) allStaffMembers.Add(staff);

            return doesntExist;
        }
      

      

       

    }
}
