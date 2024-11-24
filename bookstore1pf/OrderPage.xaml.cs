using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
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
using static bookstore1pf.tablePage;

namespace bookstore1pf
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        Entities DBcontext;
        List<TableBook> selectedBooks;
        int OrderSum;
        public OrderPage(List<TableBook> selectedBooks1)
        {
            InitializeComponent();
            DBcontext = new Entities();
            selectedBooks = selectedBooks1;
            mainTable.ItemsSource = selectedBooks;

            var datacontext = DBcontext.order_pick_up_points
                .Include(o => o.Cities)
                .ToList();

            List<string> ComboItems = new List<string>();
            foreach (order_pick_up_points point in datacontext)
            {
                ComboItems.Add(point.Cities.city_name);
            }
            ComboPoint.ItemsSource = ComboItems;

            OrderSum = 0;
            foreach (TableBook selected in selectedBooks)
            {
                OrderSum += int.Parse(selected.price);
            }
            SumBlock.Text = OrderSum.ToString();
        }

        public OrderPage()
        {
            InitializeComponent();
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            var datacontext1 = DBcontext.order_pick_up_points
                                        .Include(p => p.Cities)
                                        .ToList();

            if (selectedBooks.Count != 0)
            {
                if (ComboPoint.SelectedItem != null)
                {
                    Orders newOrder = new Orders();
                    newOrder.date_of_the_order = DateTime.Now;
                    newOrder.order_pick_up_point_id = datacontext1.Find(p => p.Cities.city_name == ComboPoint.SelectedItem.ToString()).id;
                    newOrder.status_id = 1;
                    newOrder.customer_id = App.UserId;

                    DBcontext.Orders.Add(newOrder);
                    DBcontext.SaveChanges();

                    List <Order_composition> composition = new List<Order_composition>();
                    foreach (TableBook selected in selectedBooks)
                    {
                        if (composition.Find(c => c.book_id == selected.id) != null)
                        {
                            composition.Find(c => c.book_id == selected.id).Amount += 1;
                        }
                        else
                        {
                            Order_composition part = new Order_composition();
                            part.book_id = selected.id;
                            part.order_id = newOrder.id;
                            part.Amount = 1;
                            composition.Add(part);
                        }
                    }

                    foreach (Order_composition part in composition)
                    {
                        DBcontext.Order_composition.Add(part);
                        DBcontext.SaveChanges();
                    }

                    MessageBox.Show($"Код вашего заказа: {newOrder.id}\nНа сумму {OrderSum}","Заказ оформлен", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите пункт выдачи заказа", "Попытка оформления заказа прервана", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Корзина уже пуста, невозможно оформить заказ", "Попытка оформления заказа прервана", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var n in mainTable.SelectedItems.Cast<TableBook>())
            {
                selectedBooks.Add(n);
            }

            OrderSum = 0;
            foreach (TableBook selected in selectedBooks)
            {
                OrderSum += int.Parse(selected.price);
            }
            SumBlock.Text = OrderSum.ToString();

            if (mainTable.ItemsSource == selectedBooks)
            {
                mainTable.ItemsSource = null;
                mainTable.ItemsSource = selectedBooks;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBooks.Count != 0)
            {
                foreach (var n in mainTable.SelectedItems.Cast<TableBook>())
                {
                    selectedBooks.Remove(selectedBooks.Find(s => s.title == n.title));
                }

                OrderSum = 0;
                foreach (TableBook selected in selectedBooks)
                {
                    OrderSum += int.Parse(selected.price);
                }
                SumBlock.Text = OrderSum.ToString();
            }
            else
            {
                MessageBox.Show("Попытка удаления прервана, корзина уже пуста!", "Попытка удаления прервана", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (mainTable.ItemsSource == selectedBooks)
            {
                mainTable.ItemsSource = null;
                mainTable.ItemsSource = selectedBooks;
            }
        }
    }
}
