using DTO.DatabaseConnection;
using Logic.Companys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DbTables
{
    public class CompanyTabel : ApplicationDbContext
    {
        public CompanyTabel(string connectionString) : base(connectionString) { }


        public void AddCompany(Company company)
        {

        }


    }
}
