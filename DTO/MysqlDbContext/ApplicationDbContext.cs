using MySql.Data.MySqlClient;
using System.Data;

namespace DTO
{
    internal class ApplicationDbContext
    {
        //fields
        private MySqlConnection conn;

        public ApplicationDbContext(string connectionstring)
        {
            conn = new MySqlConnection(connectionstring);
        }

        /// <summary>
        /// Executes the given query and returns the resulting data as a DataSet.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="mySqlParameter">The parameters for the query.</param>
        /// <returns>The resulting data as a DataSet.</returns>
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
        /// Executes the given query and returns the resulting data as a DataSet.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <returns>The resulting data as a DataSet.</returns>
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
        /// Executes the given query and inserts the given data into the database.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="mySqlParameter">The data to insert.</param>
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
