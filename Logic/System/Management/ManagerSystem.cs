using Logic.Companys;
using Logic.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Management
{
    public class ManagerSystem
    {
        private List<StaffMember> allStaffMembers = new();
        private List<Company> allCompany = new();

        public ManagerSystem(List<StaffMember> allStaffMembers, List<Company> allCompany)
        {
            this.allStaffMembers = allStaffMembers;
            this.allCompany = allCompany;
        }

        /// <summary>
        /// add a new staffMember to list if it doesnt exsist
        /// </summary>
        /// <param name="staffMember"></param>
        /// <returns></returns>
        private bool Add(StaffMember staffMember)
        {
            if (allStaffMembers.Contains(staffMember)){ return false; }
            allStaffMembers.Add(staffMember);
            return true;
        }

        /// <summary>
        /// add a new company to list if it doesnt exsist
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        private bool Add(Company company)
        {
            if (allCompany.Contains(company)) { return false; }
            allCompany.Add(company);
            return true;
        }

    }
}
