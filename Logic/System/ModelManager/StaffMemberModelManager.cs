using Logic.Employee;
using Logic.Enum;
using Logic.Interface;

namespace Logic.System.ModelManager
{
    public class StaffMemberModelManager : IStaffMemberModelManager
    {
        private List<StaffMember> staffMembers;
        private IBinaryFileManager fileManager;

        public IList<StaffMember> StaffMembers { get { return staffMembers.AsReadOnly(); } }

        public StaffMemberModelManager(IBinaryFileManager fileManager)
        {

            this.fileManager = fileManager;
            this.staffMembers = fileManager.ReadFromBinaryFile<List<StaffMember>>(RepositoryType.Staff);
        }

        /// <summary>
        /// Adds a new staff member to the list of staff members.
        /// </summary>
        /// <param name="staffMember">The staff member to add.</param>
        /// <returns>A result object containing either a success message or an exception if there was an error.</returns>
        public Result<string> AddNewStaff(StaffMember staffMember)
        {
            try
            {
                if (!staffMembers.Any(x => x.Equals(staffMember)))
                {
                    staffMembers.Add(staffMember);
                    return Result<string>.Ok("is added to the list");
                }

                return Result<string>.Fail(new Exception("staffmember already exists"));
            }
            catch (Exception e)
            {
                return Result<string>.Fail(e);
            }
        }

        /// <summary>
        /// Updates a specific staffMember in the list.
        /// </summary>
        /// <param name="staffMember">The staffMember to update.</param>
        public void SaveStaffMember(StaffMember staffMember)
        {
            int index = staffMembers.FindIndex(x => x.Username == staffMember.Username);
            if (index != -1)
            {
                staffMembers[index] = staffMember;
            }
        }

    

        /// <summary>
        /// Saves the list of staff members to a binary file.
        /// </summary>
        public void SaveStaffMembers()
        {
            fileManager.WriteToBinaryFile<List<StaffMember>>(staffMembers, RepositoryType.Staff);
        }
    }
}
