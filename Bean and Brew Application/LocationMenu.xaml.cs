using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Bean_and_Brew_Application
{
    /// <summary>
    /// Interaction logic for LocationMenu.xaml
    /// </summary>
    public partial class LocationMenu : Window
    {
        public LocationMenu()
        {

            InitializeComponent();
            LocationCMB.Items.Add("Leeds");
            LocationCMB.Items.Add("Harrogate");
            LocationCMB.Items.Add("Knaresborough");
        }

        private void OnImageButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CoffeeButtonClick(object sender, RoutedEventArgs e)
        {

            CoffeeMenu coffeeMenu = new CoffeeMenu();
            coffeeMenu.Show();
            this.Close();
        }

        private void LocationButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are already on the Location page.");
            //already on this window
        }

        private void AbooutUsButtonClick(object sender, RoutedEventArgs e)
        {
            AboutUsMenu aboutUsMenu = new AboutUsMenu();
            aboutUsMenu.Show();
            this.Close();
        }
        static string Location = "Leeds";

        private void LocationCMB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LocationCMB.SelectedValue.ToString() == "Leeds") 
            {
                LeedsCoffeeShop.Visibility = Visibility.Visible;
                HarrogateCoffeeShop.Visibility = Visibility.Hidden;
                KnaresboroughCoffeeShop.Visibility = Visibility.Hidden;
                Location = "Leeds";


                LeedsLbl.Visibility = Visibility.Visible;
                HarrogateLbl.Visibility = Visibility.Hidden;
                KnaresboroughLbl.Visibility = Visibility.Hidden;
            }
            else if(LocationCMB.SelectedValue.ToString() == "Harrogate")
            {
                HarrogateCoffeeShop.Visibility = Visibility.Visible;
                LeedsCoffeeShop.Visibility = Visibility.Hidden;
                KnaresboroughCoffeeShop.Visibility= Visibility.Hidden;
                Location = "Harrogate";
                

                HarrogateLbl.Visibility = Visibility.Visible;
                LeedsLbl.Visibility = Visibility.Hidden;
                KnaresboroughLbl.Visibility = Visibility.Hidden;
            }
            else if(LocationCMB.SelectedValue.ToString() == "Knaresborough")
            {
                HarrogateCoffeeShop.Visibility = Visibility.Hidden;
                LeedsCoffeeShop.Visibility = Visibility.Hidden;
                KnaresboroughCoffeeShop.Visibility = Visibility.Visible;

                KnaresboroughLbl.Visibility = Visibility.Visible;
                HarrogateLbl.Visibility = Visibility.Hidden;
                LeedsLbl.Visibility = Visibility.Hidden;
                Location = "Knaresborough";

            }
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync($"http://api.weatherapi.com/v1/current.json?key=12177a31ece44e8b80d91047232311&q={Location}&aqi=no").Result;
            var JsonObject = JsonNode.Parse(response);
            Trace.WriteLine(JsonObject);
            string location = JsonObject["location"]["name"].ToString();
            string temperature = JsonObject["current"]["temp_c"].ToString();
            string weather = JsonObject["current"]["condition"]["text"].ToString();
            LocationWeatherTxt.Text = $"The weather in {location} is {temperature}c and its {weather}";
        }
    }
}
