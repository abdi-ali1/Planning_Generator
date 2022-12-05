using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.ModelManager
{
    public class StaffMemberModelManager: IStaffMemberModelManager
    {
        private List<StaffMember> allStaffMembers;

        public IList<StaffMember> AllStaffMembers { get { return allStaffMembers.AsReadOnly(); } }


        public StaffMemberModelManager(List<StaffMember> allStaffMembers)
        {
            this.allStaffMembers = allStaffMembers;
        }


        public bool AddNewStaff(StaffMember staffMember)
        {   
         if (allStaffMembers.Contains(staffMember)) return false;

            allStaffMembers.Add(staffMember);
            return true;
        }


    }
}
