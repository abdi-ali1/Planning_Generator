using DTO.DbTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DataMangement
{
    public class DataManagement
    {
        private StaffTable staffTable;
        private CompanyTabel companyTable;

      public StaffTable StaffTable { get { return staffTable; } }
      public CompanyTabel CompanyTabel { get { return companyTable; } }


        public DataManagement(string connectionString)
        {
            
        }




    }
}
