using DTO.Models.CompanyModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public List<WeeklyNeed> GetWeeklyNeeds(int id)
        {
            List<WeeklyNeed> weeklyNeeds = new List<WeeklyNeed>();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            string query = "select * from weeklyneed_tb where id=@value";

            parameters.Add(new MySqlParameter("@value", id.ToString()));

            DataSet table =  dbContext.GetReturnData(query);

            foreach (DataRow data in table.Tables["Tables"].Rows)
            {
                weeklyNeeds.Add(new WeeklyNeed((int)data["id"], (DateTime)data["neededWeek"],
                    Shifttable.GetNeededStaffStaff((int)data["id"])));
            }

            return weeklyNeeds;

        }



    }
}
