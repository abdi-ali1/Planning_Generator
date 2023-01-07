using Logic.Companys;
using Logic.Employee;

namespace Logic.System.Authentication
{
    public class AuthenticationManagement
    {
        private IList<StaffMember> staffMembers;
        private IList<Company> companies;

        public AuthenticationManagement(IList<StaffMember> staffMembers, IList<Company> companies)
        {
            this.staffMembers = staffMembers;
            this.companies = companies;
        }

        /// <summary>
        /// Authenticates the staff member with the given username.
        /// </summary>
        /// <param name="username">The username of the staff member to authenticate.</param>
        /// <returns>A Result object containing the authenticated staff member, or an error message if the operation failed.</returns>
        public Result<StaffMember> AuthenticateCurrentStaffMember(string username)
        {
            try
            {
                StaffMember currentStaffMember = staffMembers.FirstOrDefault(s => s.Name == username);
                if (currentStaffMember == null)
                {
                    return Result<StaffMember>.Fail(new ArgumentException("staff member doesn't exist"));
                }
                return Result<StaffMember>.Ok(currentStaffMember);
            }
            catch (Exception e)
            {
                return Result<StaffMember>.Fail(e);
            }
        }

        /// <summary>
        /// Authenticates the company with the given name.
        /// </summary>
        /// <param name="name">The name of the company to authenticate.</param>
        /// <returns>A Result object containing the authenticated company, or an error message if the operation failed.</returns>
        public Result<Company> AuthenticateCurrentCompany(string name)
        {
            try
            {
                Company currentCompany = companies.FirstOrDefault(c => c.Name == name);
                if (currentCompany == null)
                {
                    return Result<Company>.Fail(new ArgumentException("company doesn't exist"));
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