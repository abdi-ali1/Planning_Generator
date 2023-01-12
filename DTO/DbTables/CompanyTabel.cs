using DTO.Models.CompanyModels;
using MySql.Data.MySqlClient;
using System.Data;

namespace DTO.DbTables
{
    public class CompanyTabel
    {
        private ApplicationDbContext dbContext;

        public CompanyTabel(string conntectionString)
        {
            dbContext = new ApplicationDbContext(conntectionString);
        }

        /// <summary>
        /// Creates a new company in the database.
        /// </summary>
        /// <param name="company">The company to create.</param>
        public void Create(Company company)
        {
            string query = "insert into company_tb (name) values('@value')";

            List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();

            mySqlParameters.Add(new MySqlParameter("@value", company.Name));

            dbContext.InsertData(query, mySqlParameters);
        }

        /// <summary>
        /// Retrieves a list of all companies in the database.
        /// </summary>
        /// <returns>A list of all companies in the database.</returns>
        public List<Company> SelectAllCompanies()
        {
            List<Company> companies = new List<Company>();
            List<WeeklyNeed> weeklies = new List<WeeklyNeed>();
            string query =
                "SELECT * FROM company_tb AS c INNER JOIN weeklyneed As wn ON wn.company_id = c.id Inner join shift AS s ON s.weeklyneed_id = wn.id;";

            DataSet table = dbContext.GetReturnData(query);

            foreach (DataRow data in table.Tables["Tables"].Rows)
            {
                companies.Add(new Company((int)data["id"], (string)data["name"]));
            }

            return companies;
        }

        /// <summary>
        /// Inserts a list of companies into the database.
        /// </summary>
        /// <param name="companies">The list of companies to insert.</param>
        public void InsertAllCompanies(List<Company> companies) { }
    }
}
