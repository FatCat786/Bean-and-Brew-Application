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

namespace Bean_and_Brew_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float PromoCoffee1 = 4.99f;
        float PromoCoffee2 = 6.99f;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void OnImageButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are already on the main menu.");

        }

        private void CoffeeButtonClick(object sender, RoutedEventArgs e)
        {
            CoffeeMenu coffeeMenu = new CoffeeMenu();
            coffeeMenu.Show();
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

        private void PromoOrderClick(object sender, RoutedEventArgs e)
        {
            OrderDetails.Receipt.Add(PromoCoffee1);
           

        }

        private void PromoOrderClick2(object sender, RoutedEventArgs e)
        {
            OrderDetails.Receipt.Add(PromoCoffee2);
            
        }
    }
}
