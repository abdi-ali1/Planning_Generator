using Logic.Companys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Pl.Mocking.Companys
{
    internal class CompanyDataMock
    {


        public static IList<Company> GetListCompany()
        {
            IList<Company> companies = new List<Company>();
            companies.Add(new Company("Tesla"));
            companies.Add(new Company("Apple"));
            companies.Add(new Company("Google"));

            return companies;
        }
    }
}
