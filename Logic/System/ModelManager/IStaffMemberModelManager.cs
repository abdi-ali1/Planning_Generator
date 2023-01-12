using Logic.Employee;

namespace Logic.System.ModelManager
{
    public interface IStaffMemberModelManager
    {
        public IList<StaffMember> StaffMembers { get; }
        public Result<string> AddNewStaff(StaffMember staffMember);
        public void SaveStaffMembers();
        public void SaveStaffMember(StaffMember staffMember);
    }
}
