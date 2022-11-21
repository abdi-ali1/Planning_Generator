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

        private List<StaffMember> allStaffMembers = new();
        private List<Company> allCompany = new();

        public AuthenticationManagement(List<StaffMember> allStaffMembers, List<Company> allCompany)
        {
            this.allStaffMembers = allStaffMembers;
            this.allCompany = allCompany;
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
            foreach (Company company in allCompany)
            {
                if (company.Name == name)
                {
                    currentCompany = company;
                    break;
                }
            }

            return currentCompany;
        }






    }
}
