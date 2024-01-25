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
    /// Interaction logic for CoffeeMenu.xaml
    /// </summary>
    public partial class CoffeeMenu : Window
    {
        string connStr = "server=ND-COMPSCI;" +
              "user=TL_S2200767;" +
              "database=TL_S2200767_b;" +
              "port=3306;" +
              "password=Notre111005";
        List<string> product;
        public CoffeeMenu()
        {
            InitializeComponent();
            product = new List<string>();
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string selectProducts = $"SELECT CoffeeName FROM coffee;";
            MySqlCommand cmd = new MySqlCommand(selectProducts, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                product.Add(rdr.GetString(0));
            }
            Product.ItemsSource = product;
            conn.Close();
        }

        private void CoffeeButtonClick(object sender, RoutedEventArgs e)
        {
            //IF ALREADY ON THE COFFEE MENU THIS WILL DO NOTHING...
            MessageBox.Show("you are on the coffee menu.");
        }

        private void OnImageButtonClick(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LocationButtonClick(object sender, RoutedEventArgs e)
        {
            LocationMenu locationMenu = new LocationMenu();
            locationMenu.Show();
            this.Close();
        }
        private void Product_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string Priceselect = $"SELECT price,size FROM coffee WHERE coffeename = '{Product.SelectedValue}';";
            MySqlCommand cmd = new MySqlCommand(Priceselect, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string Prices = (rdr.GetString(0));
                string Sizes = (rdr.GetString(1));
                CoffeeSize.Text = $"{Sizes}";
                CoffeePrice.Text = $"{Prices}";


            }

            conn.Close();

        }

        private void AbooutUsButtonClick(object sender, RoutedEventArgs e)
        {
            AboutUsMenu aboutUsMenu = new AboutUsMenu();
            aboutUsMenu.Show();
            this.Close();
        }

        private void CheckoutBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderMenu orderMenu = new OrderMenu();    
            orderMenu.Show();
            this.Close();
        }

        private void Add_Coffee_Click(object sender, RoutedEventArgs e)
        {
            OrderDetails.Receipt.Add(float.Parse(CoffeePrice.Text));
        }
    }
}
