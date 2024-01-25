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
    /// Interaction logic for AboutUsMenu.xaml
    /// </summary>
    public partial class AboutUsMenu : Window
    {
        public AboutUsMenu()
        {
            InitializeComponent();
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
            LocationMenu locationMenu = new LocationMenu();
            locationMenu.Show();
            this.Close();
        }

        private void AbooutUsButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are on the About us Page.");
        }

        private int Limit = 0;
        private void SizeIncreaseBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (Limit != 3) 
            {
                AboutUsBio.FontSize *= 2;
                Limit++; 
              
            }
            
            
        }

        private void SizeDecreaseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Limit != 0)
            {
                AboutUsBio.FontSize /= 2;
                Limit--;
            }
        }

        public int HCLimit = 0;

        private void HighContrastBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HCLimit == 1)
            {
                AboutUsBio.Background = Brushes.Black;
                AboutUsBio.Foreground = Brushes.Yellow;
                HCLimit--;
            }
            else
            {
                AboutUsBio.Background = Brushes.White;
                AboutUsBio.Foreground = Brushes.Black;

                HCLimit++;
            }
        }
    }
}
