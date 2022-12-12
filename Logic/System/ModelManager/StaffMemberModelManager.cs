using Logic.Employee;
using Logic.Enum;
using Logic.Interface;

namespace Logic.System.ModelManager
{
    public class StaffMemberModelManager: IStaffMemberModelManager
    {
        private List<StaffMember> allStaffMembers;
        private IBinarayFileManager fileManager;

        public IList<StaffMember> AllStaffMembers { get { return allStaffMembers.AsReadOnly(); } }


        public StaffMemberModelManager(IBinarayFileManager fileManager)
        {

            this.fileManager = fileManager;    
            this.allStaffMembers = fileManager.ReadFromBinaryFile<List<StaffMember>>(RepositoryType.Staff);
        }

        public bool AddNewStaff(StaffMember staffMember)
        {   
         if (allStaffMembers.Contains(staffMember)) return false;

            allStaffMembers.Add(staffMember);
            return true;
        }


        public void SaveStaffMembers()
        {
            fileManager.WriteToBinaryFile<List<StaffMember>>(allStaffMembers, RepositoryType.Staff);
           
        }





    }
}
