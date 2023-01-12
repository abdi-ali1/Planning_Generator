namespace DTO.DbTables
{
    public class StaffTable
    {
        public StaffTable() { }

        /// <summary>
        /// Inserts a new staff member into the database.
        /// </summary>
        public void InsertStaff()
        {
            string query =
                "insert into staffmember(name, gender, companyrole, occupation,"
                + "age, username) values(@name, @gender, @companyRole, @occupation, @age, @username)";
            /*   comm.Parameters.AddWithValue("@name", staffMember.Name);
            comm.Parameters.AddWithValue("@gender", staffMember.Gender.ToString());
            comm.Parameters.AddWithValue("@companyRole", staffMember.Role.ToString());
            comm.Parameters.AddWithValue("@occupation", staffMember.Occaption.ToString());
            comm.Parameters.AddWithValue("@age", staffMember.Age);
            comm.Parameters.AddWithValue("@username", staffMember.Username);*/
        }
    }
}
