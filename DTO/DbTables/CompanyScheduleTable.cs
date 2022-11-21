using DTO.Models.CompanyModels;
using DTO.Models.StaffMemberModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DbTables
{
    internal class CompanyScheduleTable
    {
        private ApplicationDbContext dbContext;
        private Shifttable Shifttable;

        public CompanyScheduleTable(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            Shifttable = new Shifttable(dbContext);
        }

        public List<CompanySchedule> GetCompanySchedule(int id)
        {
            List<CompanySchedule> shedules = new List<CompanySchedule>();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            string query = "select * from companyschedule_tb where id=@value";

            parameters.Add(new MySqlParameter("@value", id.ToString()));

            DataSet table = dbContext.GetReturnData(query);

            foreach (DataRow data in table.Tables["Tables"].Rows)
            {
                shedules.Add(new CompanySchedule((int)data["id"], (DateTime)data["neededWeek"], null));
            }

            return shedules;

        }

        private List<StaffMember> GetNeededStaffMembers(int id) 
        {

            List<StaffMember> staffMembers = new List<StaffMember>();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            string query = "select * from staffmember_tb where id=@value";

            parameters.Add(new MySqlParameter("@value", id.ToString()));

            DataSet table = dbContext.GetReturnData(query);

            foreach (DataRow data in table.Tables["Tables"].Rows)
            {
                //staffMembers.Add(new StaffMember((int)data["id"], (DateTime)data["neededWeek"], );
            }

            return staffMembers;
        }



    }
}
