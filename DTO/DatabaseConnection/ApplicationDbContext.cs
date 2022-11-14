using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DatabaseConnection
{
    public abstract class ApplicationDbContext
    {
       protected MySqlConnection conn;


        public ApplicationDbContext(string connectionString)
        {
            conn = new MySqlConnection(connectionString);
        }
    }
}
