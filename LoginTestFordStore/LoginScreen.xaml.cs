using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginTestFordStore
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {

        Database database = new Database();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = database.CreateConnection();
                database.OpenConnection();

                SqlCommand cmd = new SqlCommand("spGetEmployeeFromInitials", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Initials", txtCredentials.Text));

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
                    MessageBox.Show("Credentials is incorrect.");
                }
                database.CloseConnection();
                if (Name != null)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}