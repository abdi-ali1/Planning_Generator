using Logic.Companys;
using Logic.Employee;


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
        /// Authenticates the current staffmemeber based on its username.
        /// </summary>
        /// <param name="username">A string value representing the username of the StaffMember to authenticate.</param>
        /// <returns>
        /// A Result<Company> object indicating the success or failure of the operation. If the operation is successful, 
        /// the Ok variant will contain the authenticated StaffMember object. If the operation fails, the Fail variant will 
        /// contain an Exception object with more information about the error.
        /// </returns>
        public Result<StaffMember> AuthenticateCurrentStaffMember(string username)
        {
            try
            {
                StaffMember currentStaffMember = allStaffMembers.FirstOrDefault(s => s.Name == username);
                if (currentStaffMember == null)
                {
                    return Result<StaffMember>.Fail(new ArgumentException("staff member does not exist"));
                }
                return Result<StaffMember>.Ok(currentStaffMember);
            }
            catch (Exception e)
            {
                return Result<StaffMember>.Fail(e);
            }
        }

        /// <summary>
        /// Authenticates the current company based on its name.
        /// </summary>
        /// <param name="name">A string value representing the name of the company to authenticate.</param>
        /// <returns>
        /// A Result<Company> object indicating the success or failure of the operation. If the operation is successful, 
        /// the Ok variant will contain the authenticated Company object. If the operation fails, the Fail variant will 
        /// contain an Exception object with more information about the error.
        /// </returns>
        public Result<Company> AuthenticateCurrentCompany(string name)
        {
            try
            {
                Company currentCompany = allCompanies.FirstOrDefault(c => c.Name == name);
                if (currentCompany == null)
                {
                    return Result<Company>.Fail(new ArgumentException("company does not exist"));
                }
                return Result<Company>.Ok(currentCompany);
            }
            catch (Exception e)
            {
                return Result<Company>.Fail(e);
            }
        }
    }
}
