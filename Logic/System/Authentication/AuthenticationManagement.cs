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
      private IModelManager modelManager;

        public AuthenticationManagement(IModelManager modelManager)
        {
            this.modelManager = modelManager;
        }





        /// <summary>
        /// Checks if user exist (tempory solution)
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public IStaff AuthenticateCurrentStaffMember(string username)
        {
            IStaff currentStaffMember = null;
            foreach (IStaff staff in modelManager.AllStaffMembers)
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
        public ICompany AuthenticateCurrentCompany(string name)
        {
            ICompany currentCompany = null;
            foreach (ICompany company in modelManager.AllCompanies)
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
        public bool AuthenticateManager(IStaff staffMember)
        {
            if (staffMember.Role == Enum.CompanyRole.Manager) return true;

            return false;
        }






    }
}
