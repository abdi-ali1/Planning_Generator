using DTO.DbTables;

namespace DTO.DataMangement
{
    public class DataManagement
    {
        private StaffTable staffTable;
        private CompanyTabel companyTable;

        public StaffTable StaffTable
        {
            get { return staffTable; }
        }
        public CompanyTabel CompanyTabel
        {
            get { return companyTable; }
        }

        public DataManagement(string connectionString) { }
    }
}
