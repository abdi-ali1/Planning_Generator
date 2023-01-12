using DTO.Models.CompanyModels;
using MySql.Data.MySqlClient;
using System.Data;

namespace DTO.DbTables
{
    internal class WeeklyNeedTable
    {
        private ApplicationDbContext dbContext;
        private Shifttable Shifttable;

        public WeeklyNeedTable(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            Shifttable = new Shifttable(dbContext);
        }

        /// <summary>
        /// Retrieves a list of weekly needs with the given ID.
        /// </summary>
        /// <param name="id">The ID of the weekly needs to retrieve.</param>
        /// <returns>A list of weekly needs with the given ID.</returns>
        public List<WeeklyNeed> GetWeeklyNeeds(int id)
        {
            List<WeeklyNeed> weeklyNeeds = new List<WeeklyNeed>();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            string query = "select * from weeklyneed_tb where id=@value";

            parameters.Add(new MySqlParameter("@value", id.ToString()));

            DataSet table = dbContext.GetReturnData(query);

            foreach (DataRow data in table.Tables["Tables"].Rows)
            {
                weeklyNeeds.Add(
                    new WeeklyNeed(
                        (int)data["id"],
                        (DateTime)data["neededWeek"],
                        Shifttable.GetNeededStaffStaff((int)data["id"])
                    )
                );
            }

            return weeklyNeeds;
        }
    }
}
