using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Bean_and_Brew_Application
{
    /// <summary>
    /// Interaction logic for NewUserDetails.xaml
    /// </summary>
    public partial class NewUserDetails : Window
    {
        string connStr = "server=ND-COMPSCI;" +
               "user=TL_S2200767;" +
               "database=TL_S2200767_b;" +
               "port=3306;" +
               "password=Notre111005";
        string CustomerID;
        public NewUserDetails(string customerID)
        {
            InitializeComponent();
            this.CustomerID = customerID;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CreateFirstNameTxt.Text == "" || CreateLastNameTxt.Text == "" || CreateEmail.Text == "" || CreatePhoneNumber.Text == "") 
            {
                MessageBox.Show("Please Enter a Valid Input");
                return;
            }
            else if (CreatePhoneNumber.Text.Length != 11 )
            {
                MessageBox.Show("Enter a phone number thats 11digits");
                return;
            }
            else if(CreateFirstNameTxt.Text.Length < 3 )
            {
                MessageBox.Show("Enter a name with more then 3 characters");
                return;
            }
            else if (CreateEmail.Text.Contains("@") && CreateEmail.Text.Contains("."))
            {

            }
            else 
            {
                MessageBox.Show("Please enter a @ or . input");
                return;
            }
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string NewUser = $"Update Customer Set " +
                $"Firstname = '{CreateFirstNameTxt.Text}', surname = '{CreateLastNameTxt.Text}', PhoneNumber = '{CreatePhoneNumber.Text}',Email = '{CreateEmail.Text}'" +
                $"WHERE CustomerID = '{CustomerID}'";
            MySqlCommand cmd = new MySqlCommand(NewUser, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
