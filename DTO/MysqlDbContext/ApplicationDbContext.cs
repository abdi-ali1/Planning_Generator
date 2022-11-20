using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class ApplicationDbContext
    {
        //fields
        private MySqlConnection conn;

        /// <summary>
        /// sets connection 
        /// </summary>
        /// <param name="connectionstring"></param>
        public ApplicationDbContext(string connectionstring)
        {
            conn = new MySqlConnection(connectionstring);
        }

        /// <summary>
        /// returns a filled Dataset
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetReturnData(string query, List<MySqlParameter> mySqlParameter)
        {
            DataSet dt = new DataSet();
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);

                foreach (MySqlParameter parameter in mySqlParameter)
                {
                    command.Parameters.Add(parameter);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt, "Table");
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return dt;

        }

        /// <summary>
        /// returns a filled Dataset
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetReturnData(string query)
        {
            DataSet dt = new DataSet();
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt, "Table");
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return dt;
        }

        /// <summary>
        /// insert data to the database
        /// </summary>
        /// <param name="query"></param>
        /// <param name="mySqlParameter"></param>
        public void InsertData(string query, List<MySqlParameter> mySqlParameter)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);

                foreach (MySqlParameter parameter in mySqlParameter)
                {
                    command.Parameters.Add(parameter);
                }

                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }
    }
}
