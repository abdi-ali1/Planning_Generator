

using Logic.Companys;
using Logic.Employee;

namespace Logic
{
    public interface IModelManager
    {

        public List<IStaff> AllStaffMembers { get; }
        public List<ICompany> AllCompanies { get; }


        public void AddStaffMember(IStaff staffMember);
        public void AddCompany(ICompany company);


        // only use it  for dummy data
      /*  public void SampleObject();*/
    }
}