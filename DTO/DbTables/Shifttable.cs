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
    internal class Shifttable
    {
        private ApplicationDbContext dbContext;

        public Shifttable(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<NeededStaff> GetNeededStaffStaff(int id)
        {
            List<NeededStaff> neededStaff = new List<NeededStaff>();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            string query = "select * from shift_tb where weeklyneed_id=@value";

            parameters.Add(new MySqlParameter("@value", id.ToString()));

            DataSet table = dbContext.GetReturnData(query);

            foreach (DataRow data in table.Tables["Tables"].Rows)
            {
                neededStaff.Add(new NeededStaff((int)data["id"], (int)data["occupation"], (int)data["kindOfShift"]));
            }

            return neededStaff;
        }




    }
}
