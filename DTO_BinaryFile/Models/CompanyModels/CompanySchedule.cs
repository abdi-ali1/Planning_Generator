using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BinaryFile
{
    [Serializable]
    public class CompanySchedule
    {
  
        private DateTime currentWeek;
        private List<StaffMember> AllStaffMembers = new();

        public DateTime CurrentWeek { get => currentWeek; }
        public List<StaffMember> AllStaffMembers1 { get => AllStaffMembers; }


        public CompanySchedule( DateTime currentWeek, List<StaffMember> allStaffMembers)
        {
 
            this.currentWeek = currentWeek;
            AllStaffMembers = allStaffMembers;
        }

        private  CompanySchedule()
        {

        }

     
    }
}
