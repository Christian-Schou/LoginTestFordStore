using System.Data;
using System.Data.SqlClient;

namespace LoginTestFordStore
{
    internal class Database
    {
        //Skaber forbindelse til databasen
        // giver mulighed for at skabe forbindelse, åbne forbindelse og lukke forbindelsen igen.

        public string connectionString = "Server=den1.mssql3.gear.host; Database=fordstore; User Id=fordstore; Password=Ct4Aa8_!k0BQ;";
        SqlConnection con;

        public SqlConnection CreateConnection()
        {

            return con = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }

    }
}