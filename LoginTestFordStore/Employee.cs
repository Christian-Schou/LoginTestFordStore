using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTestFordStore
{
    class Employee
    {

        Database database = new Database();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }

        // Giver logon tilladelse baseret på employee initialer i databasen.

        public void LogOn(string employeeInitials)
        {

            try
            {
                SqlConnection con = database.CreateConnection();
                database.OpenConnection();

                SqlCommand cmd = new SqlCommand("spGetEmployeeFromInitials", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Initials", employeeInitials));

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Id = int.Parse(reader["EmployeeId"].ToString());
                        Name = reader["EmployeeName"].ToString();
                        Initials = reader["EmployeeInitials"].ToString();
                    }
                }
                else
                {
                    Console.WriteLine("Der kunne ikke logges på. Prøv igen.");
                    Console.ReadLine();
                }


                database.CloseConnection();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Ups " + e.Message);
            }

        }

        public void GetAllEmployees()
        {

        }

        public void GetEmployees()
        {

        }

        public void InsertEmployees()
        {

        }
    }
}