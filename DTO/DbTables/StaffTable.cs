﻿using DTO.DatabaseConnection;
using Logic.Employee;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DbTables
{
    public class StaffTable : ApplicationDbContext
    {
        public StaffTable(string connectionString) : base(connectionString) { }
        
        
        public void InsertStaff(StaffMember staffMember)
        {
            conn.Open();
            string query = "insert into staffmember(name, gender, companyrole, occupation," +
                "age, username) values(@name, @gender, @companyRole, @occupation, @age, @username)";
            MySqlCommand comm = new MySqlCommand( query, conn);

            comm.Parameters.AddWithValue("@name", staffMember.Name);
            comm.Parameters.AddWithValue("@gender", staffMember.Gender.ToString());
            comm.Parameters.AddWithValue("@companyRole", staffMember.Role.ToString());
            comm.Parameters.AddWithValue("@occupation", staffMember.Occaption.ToString());
            comm.Parameters.AddWithValue("@age", staffMember.Age);
            comm.Parameters.AddWithValue("@username", staffMember.Username);
            MySqlDataReader reader = comm.ExecuteReader();
            conn.Close();
        }
    }
}