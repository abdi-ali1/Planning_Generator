using Logic.Companys;
using Logic.Employee;

namespace Logic
{
    public interface IModelManager
    {

        public IList<StaffMember> AllStaffMembers { get; }
        public IList<Company> AllCompanies { get; }


        public void AddStaffMember(StaffMember staffMember);
        public void AddCompany(Company company);


        // only use it  for dummy data
      /*  public void SampleObject();*/
    }
}