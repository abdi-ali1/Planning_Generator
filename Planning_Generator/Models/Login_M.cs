using Logic.Companys;
using Logic.Employee;

namespace Planning_Generator.Models
{
    public class Login_M
    {
        public string Username { get; set; }
        public bool IsAuthenticated { get; set; }
        public  StaffMember? AuthenticatedStaffMember { get; set; }
        public  Company? AuthenticatedCompany { get; set; }
    }
}
