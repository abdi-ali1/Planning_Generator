using Logic.Companys.Request;
using Logic.Employee;
using Logic.Employee.Degrees;
using Logic.Enum;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace UnitTest_Pl.Mocking.StaffMember
{
    internal class MockStaffMembers
    {

        public static IList<Logic.Employee.StaffMember> GetListStaffMember()
        {
            IList<Logic.Employee.StaffMember> staffMembers = new List<Logic.Employee.StaffMember>();
            staffMembers.Add(new Logic.Employee.StaffMember("abdi114@live.nl", "Abdi", Gender.Male, CompanyRole.StaffMember, Occupation.Picker, DateTime.Now, new Degree("Software Developer", 5)));
            staffMembers.Add(new Logic.Employee.StaffMember("john.doe@gmail.com", "John", Gender.Male, CompanyRole.Manager, Occupation.Driver, DateTime.Now, new Degree("Business Administration", 3)));
            staffMembers.Add(new Logic.Employee.StaffMember("jane.doe@gmail.com", "Jane", Gender.Female, CompanyRole.StaffMember, Occupation.Driver, DateTime.Now, new Degree("Supply Chain Management", 4)));
            return staffMembers;
        }






    }
}
