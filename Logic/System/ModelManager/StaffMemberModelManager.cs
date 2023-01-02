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

        /// <summary>
        /// Adds a new StaffMember object to the list of all staffmembers.
        /// </summary>
        /// <param name="staffMember">The staffmember object to be added to the list.</param>
        /// <returns>
        /// A Result<string> object indicating the success or failure of the operation. If the operation is successful, 
        /// the Ok variant will contain a string message indicating that the Company object was added to the list. 
        /// If the operation fails, the Fail variant will contain an Exception object with more information about the error.
        /// </returns>
        public Result<string> AddNewStaff(StaffMember staffMember)
        {
            try
            {
                if (!allStaffMembers.Any(x => x.Equals(staffMember)))
                {
                    allStaffMembers.Add(staffMember);
                    return Result<string>.Ok("is added to list");
                }

                return Result<string>.Fail(new Exception("staffmember already exist"));
            }
            catch (Exception e)
            {

                return Result<string>.Fail(e);
            }
      

          
     
        }

        /// <summary>
        /// Saves the list of all companies to a binary file.
        /// </summary>
        public void SaveStaffMembers()
        {
            fileManager.WriteToBinaryFile<List<StaffMember>>(allStaffMembers, RepositoryType.Staff);
           
        }





    }
}
