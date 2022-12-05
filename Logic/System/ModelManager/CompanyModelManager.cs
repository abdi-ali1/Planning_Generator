using Logic.Companys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.ModelManager
{
    public class CompanyModelManager
    {
        private List<Company> allCompanies;

        public IList<Company> AllCompanies { get { return allCompanies.AsReadOnly(); } }

        public CompanyModelManager(List<Company> allCompanies)
        {
            this.allCompanies = allCompanies;
        }


        public bool AddNewCompany(Company company)
        {
            if (allCompanies.Contains(company)) return false;        
            allCompanies.Add(company);
            return true;
        }

    }
}
