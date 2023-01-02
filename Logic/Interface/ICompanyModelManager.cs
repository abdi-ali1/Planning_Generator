using Logic.Companys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
    public interface ICompanyModelManager
    {

        public IList<Company> AllCompanies { get; }

        public Result<string> AddNewCompany(Company company);

        public void SafeProducts();
    }
}
