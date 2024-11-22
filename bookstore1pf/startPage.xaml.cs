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

namespace bookstore1pf
{
    /// <summary>
    /// Логика взаимодействия для startPage.xaml
    /// </summary>
    public partial class startPage : Page
    {
        
        public startPage()
        {
            InitializeComponent();
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("registrationPage1.xaml", UriKind.Relative));
        }

        private void authorization_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("authorization.xaml", UriKind.Relative));
        }
    }
}
