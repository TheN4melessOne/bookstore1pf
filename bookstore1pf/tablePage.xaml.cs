using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для tablePage.xaml
    /// </summary>
    public partial class tablePage : Page
    {
        Entities DBcontext;
        List<Books> books;
        ObservableCollection<TableBook> booksView;
        List<TableBook> selectedBooks;
        Users pageUser;

        //string connectionString = "data source=DESkTOP-THCE3F8;initial catalog=Bookstore3;integrated security=True;trustservercertificate=True";
        public tablePage()
        {
            InitializeComponent();
            selectedBooks = new List<TableBook>();
            CreateOrder.Visibility = Visibility.Collapsed;
            ExitTheCart.Visibility = Visibility.Collapsed;
            CreateTable();
            //MessageBox.Show($"Ваше имя - {pageUser.userLogin}");
        }

        void CreateTable()
        {
            DBcontext = new Entities();

            books = DBcontext.Books
                                .Include(b => b.Authors)
                                .Include(b => b.Order_composition)
                                .Include(b => b.Publishing_houses)
                                .Include(b => b.Genres)
                                .ToList();
            
            booksView = new ObservableCollection<TableBook>();
            foreach (var book in books)
            {
                booksView.Add(new TableBook
                {
                    title = book.title,
                    author = book.Authors.first_name + " " +
                    book.Authors.last_name + " " + book.Authors.patronymic + " " + book.Authors.pseudonym,
                    publishingHouse = book.Publishing_houses.PublisingHouseName,
                    description = book.bookDescription,
                    publicationDate = book.publication_date.ToString(),
                    id = book.id,
                    price = book.Price.ToString()
                });
            }

            mainTable.ItemsSource = booksView;
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var n in mainTable.SelectedItems.Cast<TableBook>())
            {
                selectedBooks.Add(n);
            }

            if (mainTable.ItemsSource == selectedBooks)
            {
                mainTable.ItemsSource = null;
                mainTable.ItemsSource = selectedBooks;
            }
        }

        private void GoToCart_Click(object sender, RoutedEventArgs e)
        {
            mainTable.ItemsSource = selectedBooks;
            pageName.Text = "Корзина";
            Remove.Visibility = Visibility.Visible;
            GoToCart.Visibility = Visibility.Collapsed;
            CreateOrder.Visibility = Visibility.Visible;
            ExitTheCart.Visibility = Visibility.Visible;
            //NavigationService.Navigate(new Uri("CartPage.xaml", UriKind.Relative));
        }

        private void ExitTheCart_Click(object sender, RoutedEventArgs e)
        {
            mainTable.ItemsSource = booksView;
            pageName.Text = "Каталог";
            CreateOrder.Visibility = Visibility.Collapsed;
            Remove.Visibility = Visibility.Collapsed;
            ExitTheCart.Visibility = Visibility.Collapsed;
            CartButton.Visibility = Visibility.Visible;
            GoToCart.Visibility = Visibility.Visible;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderPage neworderPage= new OrderPage(selectedBooks);
            NavigationService.Navigate(neworderPage);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBooks.Count != 0)
            {
                foreach (var n in mainTable.SelectedItems.Cast<TableBook>())
                {
                    selectedBooks.Remove(selectedBooks.Find(s => s.id == n.id));
                }
            }
            else
            {
                MessageBox.Show("Попытка удаления прервана, корзина уже пуста!", "Попытка удаления прервана", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if(mainTable.ItemsSource == selectedBooks)
            {
                mainTable.ItemsSource = null;
                mainTable.ItemsSource = selectedBooks;
            }
        }
    }
}
