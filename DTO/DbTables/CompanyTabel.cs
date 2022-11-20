using DTO;
using DTO.Models.CompanyModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DbTables
{
    public class CompanyTabel
    {
        private ApplicationDbContext dbContext;

        public CompanyTabel(string conntectionString)
        {
            dbContext = new ApplicationDbContext(conntectionString);
        }

        public void Create(Company company)
        {
            string query = "insert into company_tb (name) values('@value')";

            List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();

            mySqlParameters.Add(new MySqlParameter("@value", company.Name));

            dbContext.InsertData(query, mySqlParameters);

        }

        public List<Company> SelectAllCompanies()
        {
            List<Company> companies = new List<Company>();




        }



   


    }
}
