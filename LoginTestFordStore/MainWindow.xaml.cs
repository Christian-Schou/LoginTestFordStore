using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Employee employee = new Employee();

        public MainWindow()
        {
            InitializeComponent();
            userName.Content = GetUserName();
            this.UserName.Text = GetUserName();
        }

        public string GetUserName()
        {
            return employee.Name;
            
        }
    }
}
