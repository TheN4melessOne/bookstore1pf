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
    /// Логика взаимодействия для registrationPage1.xaml
    /// </summary>
    public partial class registrationPage1 : Page
    {
        Entities DBcontext;
        public registrationPage1()
        {
            DBcontext = new Entities();
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            Users newUser = DBcontext.Users.ToList().Find(x => x.userPassword == "покупатель");
            tablePage newtablePage = new tablePage(newUser);
            NavigationService.Navigate(newtablePage);
            //this.NavigationService.Navigate(new Uri("tablePage.xaml", UriKind.Relative));
        }
    }
}
