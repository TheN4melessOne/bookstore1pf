using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;

namespace bookstore1pf
{
    /// <summary>
    /// Логика взаимодействия для authorization.xaml
    /// </summary>
    public partial class authorization : Page
    {
        Entities DBcontext;
        List<Users> pageUsers;
        String login;
        String password;

        
        public authorization()
        {
            InitializeComponent();
            DBcontext = new Entities();
            pageUsers = DBcontext.Users
                                 .Include(u => u.Roles)
                                 .Include(u => u.Customers)
                                 .ToList();


        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            login = loginBox.Text;
            password = passwordBox.Text;

            Users newUser = pageUsers.Find(x => x.userPassword == password && x.userLogin == login);

            if (newUser != null)
            {
                switch(newUser.roleId)
                {
                    case 1://administrator
                        {
                            break;
                        }
                    case 2://moderator
                        {
                            OrderEditing orderEditing = new OrderEditing();
                            NavigationService.Navigate(orderEditing);
                            App.UserId = newUser.id;
                            break;
                        }
                    case 3://customer
                        {
                            tablePage newtablePage = new tablePage();
                            NavigationService.Navigate(newtablePage);
                            App.UserId = newUser.id;
                            break;
                        }
                    default: { break; }
                }
                MessageBox.Show("Авторизация прошла успешно", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else 
            {
                MessageBox.Show("Такого пользователя не существует!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
