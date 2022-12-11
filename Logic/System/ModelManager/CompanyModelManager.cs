using Logic;
using Logic.Companys;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.ModelManager
{
    public class CompanyModelManager: ICompanyModelManager
    {
        private List<Company> allCompanies;
        private IBinarayFileManager fileManager { get; set; }

        public IList<Company> AllCompanies { get { return allCompanies.AsReadOnly(); } }



        public CompanyModelManager(IBinarayFileManager fileManager)
        {
            this.fileManager = fileManager;
            this.allCompanies = this.fileManager.ReadFromBinaryFile<List<Company>>();
        }


        public bool AddNewCompany(Company company)
        {
            if (allCompanies.Contains(company)) return false;        
            allCompanies.Add(company);
            return true;
        }

        public void SafeProducts()
        {
            fileManager.WriteToBinaryFile<List<Company>>(allCompanies);
        }

    }
}
