using Logic.Companys;
using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Authentication
{
    public class AuthenticationManagement
    {

        private List<StaffMember> allStaffMembers = new();
        private List<Company> allCompany = new();


        /// <summary>
        /// Checks if user exist (tempory solution)
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool AuthenticateCurrentStaff(string username)
        {
            bool isAuthenticated = false;
            foreach (StaffMember staff in allStaffMembers)
            {
                if (staff.Username == username)
                {
                    isAuthenticated = true;
                }
             
            }

            return isAuthenticated;
        }

        /// <summary>
        /// checks if company exist (tempory solution)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AuthenticateCurrentCompany(string name)
        {
            bool isAuthenticated = false;
            foreach (Company company in allCompany)
            {
                if (company.Name == name)
                {
                    isAuthenticated = true;
                }

            }

            return isAuthenticated;
        }






    }
}
