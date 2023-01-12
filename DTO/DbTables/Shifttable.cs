using DTO.Models.CompanyModels;
using MySql.Data.MySqlClient;
using System.Data;

namespace DTO.DbTables
{
    internal class Shifttable
    {
        private ApplicationDbContext dbContext;

        public Shifttable(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves a list of needed staff members with the given weekly need ID.
        /// </summary>
        /// <param name="id">The weekly need ID of the needed staff members to retrieve.</param>
        /// <returns>A list of needed staff members with the given weekly need ID.</returns>
        public List<NeededStaff> GetNeededStaffStaff(int id)
        {
            List<NeededStaff> neededStaff = new List<NeededStaff>();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            string query = "select * from shift_tb where weeklyneed_id=@value";

            parameters.Add(new MySqlParameter("@value", id.ToString()));

            DataSet table = dbContext.GetReturnData(query);

            foreach (DataRow data in table.Tables["Tables"].Rows)
            {
                neededStaff.Add(
                    new NeededStaff(
                        (int)data["id"],
                        (int)data["occupation"],
                        (int)data["kindOfShift"]
                    )
                );
            }

            return neededStaff;
        }
    }
}
