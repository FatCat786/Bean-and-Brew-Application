using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    /// Interaction logic for OrderMenu.xaml
    /// </summary>
    public partial class OrderMenu : Window
    {
        string connStr = "server=ND-COMPSCI;" +
              "user=TL_S2200767;" +
              "database=TL_S2200767_b;" +
              "port=3306;" +
              "password=Notre111005";

        MySqlConnection conn;
        public OrderMenu()
        {
            
           
            InitializeComponent();
            conn = new MySqlConnection(connStr);
            if (OrderDetails.Receipt.Count == 0)
            {
                PriceLbl.Content = $"Price: £0.00";
                return;

            }
            else 
            {
                PriceLbl.Content = $"Price: £{OrderDetails.Receipt.Sum()}";
            }
            

            


        }

        private void OnImageButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CoffeeButtonClick(object sender, RoutedEventArgs e)
        {
            CoffeeMenu menu = new CoffeeMenu();
            menu.Show();
            this.Close();
        }

        private void LocationButtonClick(object sender, RoutedEventArgs e)
        {
            LocationMenu locationMenu = new LocationMenu();
            locationMenu.Show();
            this.Close();
        }

        private void AbooutUsButtonClick(object sender, RoutedEventArgs e)
        {
            AboutUsMenu aboutUsMenu = new AboutUsMenu();
            aboutUsMenu.Show();
            this.Close();
        }

        public int Limit = 0;




        private void CheckOutButton_Click(object sender, RoutedEventArgs e)
        {
            Limit++;
            if (Limit > 1)
            {
                Limit--;
                MessageBox.Show("order already placed");
            }
            else
            {
                conn.Open();
                if (CustomerNameTxt.Text == "" || CustomerAddressTxt.Text == "")
                {
                    MessageBox.Show("Please enter a Name and or Address");
                }
                else
                {
                    string NewReceipt = $"insert into receipt (price, customerID) " +
                        $"Values ('{OrderDetails.Receipt.Sum()}' ,  '{OrderDetails.CustomerID}') ";
                    MySqlCommand command = new MySqlCommand(NewReceipt, conn);
                    command.ExecuteNonQuery();
                    conn.Close();

                    DeliveryNameLbl.Content = CustomerNameTxt.Text;
                    DeliveryAddressLbl.Content = CustomerAddressTxt.Text;
                    DeliveryStatus.Content = "Delivery: On the way";
                    return;
                }
            }  
        }

    

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            RemoveCoffee.Items.Clear();
            for (int i = 0; i < OrderDetails.Receipt.Count; i++)
            {
                RemoveCoffee.Items.Add(OrderDetails.Receipt[i]);
            }
            PriceLbl.Content = $"Price: £{OrderDetails.Receipt.Sum()}";
        }

        private void RemoveCoffeeBtn_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                OrderDetails.Receipt.RemoveAt(RemoveCoffee.SelectedIndex);
                RemoveCoffee.Items.Remove(RemoveCoffee.SelectionBoxItem);
                PriceLbl.Content = $"Price: £{OrderDetails.Receipt.Sum()}";
            }
            catch 
            {
                MessageBox.Show("Cart is empty or nothing is selected");
            }
        }

        private void CancelOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerNameTxt.Text == "" || CustomerAddressTxt.Text == "")
            {
                MessageBox.Show("enter a name and or address");
            }
            else
            {
                conn.Open();
                string RemoveReciept = $"DELETE FROM  receipt  WHERE  OrderID = '{OrderIDTxt.Text}' ";
                MySqlCommand cmd = new MySqlCommand();
                MySqlCommand command = new MySqlCommand(RemoveReciept, conn);
                command.ExecuteNonQuery();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string CsOrderID = (rdr.GetString(0));
                    OrderIDLbl.Content = $"{CsOrderID}";
                }
                conn.Close();


            }
        }
    }
}
