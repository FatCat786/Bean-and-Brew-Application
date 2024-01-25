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
    /// Interaction logic for LoginPagexaml.xaml
    /// </summary>
    public partial class LoginPagexaml : Window
    {
        string connStr = "server=ND-COMPSCI;" +
                "user=TL_S2200767;" +
                "database=TL_S2200767_b;" +
                "port=3306;" +
                "password=Notre111005";
       
        
        public LoginPagexaml()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string SelectLogin = $"SELECT CustomerID From customer " + 
                $"Where CustomerID = '{LoginLbl.Text}' " +
                $"AND Password = ('{PassLbl.Text}')"; //add SHA 
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(SelectLogin,conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("login successful");
                OrderDetails.CustomerID = LoginLbl.Text;

                MainWindow mainWindow   = new MainWindow();
                mainWindow.Show();
                this.Close();

            }
            //if no value is returned
            else
            {
                MessageBox.Show("check username or password and try again or make a new user");
            }
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            if (LoginLbl.Text.Length > 5)
           {
                MessageBox.Show("User is Bigger then 5");
                return;
            }

            else if (LoginLbl.Text == "" && PassLbl.Text == "")
            {
                MessageBox.Show("Please Enter A User or a Pass");
                return;
            }

            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();   
            string NewUser = $"INSERT into customer(customerID,password) " +
                $"Values (@paramUser, SHA(@paramPass)) ";
            MySqlCommand cmd = new MySqlCommand(NewUser, conn);
            cmd.Parameters.AddWithValue("@ParamUser", LoginLbl.Text);
            cmd.Parameters.AddWithValue("@ParamPass", PassLbl.Text);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {

                MessageBox.Show("User Already exists");
                return;
            }
           
            conn.Close();
           MessageBox.Show("UserCreated");
        
            NewUserDetails newUserDetails = new NewUserDetails(LoginLbl.Text);
            newUserDetails.Show();
            this.Close();
        }

        private void ResetPassword_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string updatePassword = $"UPDATE customer " +
                $"SET password = '{PassLbl.Text}' " +
                $"WHERE customerID = '{LoginLbl.Text}';  ";

            MySqlCommand cmd = new MySqlCommand(updatePassword,conn);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Password Updated.");
        }

        private void LimitChar(object sender, TextCompositionEventArgs e)
        { 
            List<string> banned = new List<string>();
            banned.Add("'");
            banned.Add("\"");
            //banned.Add("9");
            if (banned.Contains(e.Text))
            { 
                e.Handled = true;
            }

        }
    }
        
}
