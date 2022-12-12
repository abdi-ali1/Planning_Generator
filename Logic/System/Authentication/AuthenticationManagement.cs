using Logic.Companys;
using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.System.Authentication
{
    public class AuthenticationManagement
    {
        private IList<StaffMember> allStaffMembers;
        private IList<Company> allCompanies;

        public AuthenticationManagement(IList<StaffMember> allStaffMembers, IList<Company> allCompanies)
        {
            this.allStaffMembers = allStaffMembers;
            this.allCompanies = allCompanies;
        }

        /// <summary>
        /// Checks if user exist (tempory solution)
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public StaffMember AuthenticateCurrentStaffMember(string username)
        {
            StaffMember currentStaffMember = null;
            foreach (StaffMember staff in allStaffMembers)
            {
                if (staff.Name == username)
                {
                    currentStaffMember = staff;
                    break;
                }
            }
            return currentStaffMember;
        }


        /// <summary>
        /// checks if company exist
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Company AuthenticateCurrentCompany(string name)
        {
            Company currentCompany = null;
            foreach (Company company in allCompanies)
            {
                if (company.Name == name)
                {
                    currentCompany = company;
                    break;
                }
            }

            return currentCompany;
        }


        /// <summary>
        /// checks if the current staffmember is a manager
        /// </summary>
        /// <param name="staffMember"></param>
        /// <returns></returns>
        public bool AuthenticateManager(StaffMember staffMember)
        {
            if (staffMember.Role == Enum.CompanyRole.Manager) return true;

            return false;
        }
    }
}
