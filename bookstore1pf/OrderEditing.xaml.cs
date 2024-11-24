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
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace bookstore1pf
{
    public partial class OrderEditing : Page
    {
        Entities DBcontext;
        List<TableOrder> orders;
        TableOrder temporder;
        TableComp tempComp;
        List<TableComp> comps;
        int newAmount;
        int roleId;
        public class TableOrder
        {
            public int id { get; set; }
            public DateTime date { get; set; }
            public string orderPoint { get; set; }
            public int customerId { get; set; }
            public string status { get; set; }
            public Orders order { get; set; }

        }

        public class TableComp
        {
            public int id { get; set; }
            public int orderId { get; set; }
            public int amount { get; set; }
            public string bookName { get; set; }
            public Order_composition comp { get; set; }
        }

        public OrderEditing()
        {
            InitializeComponent();
        }

        public OrderEditing(int role)
        {
            InitializeComponent();
            DBcontext = new Entities();
            roleId = role;

            var orderContext = DBcontext.Orders
                .Include(o => o.Order_composition)
                .Include(o => o.Customers)
                .Include(o => o.order_pick_up_points)
                .Include(o => o.Statuses)
                .ToList();
            orders = new List<TableOrder>(orderContext.Select(o => new TableOrder
            {
                id = o.id,
                date = (DateTime)o.date_of_the_order,
                orderPoint = o.order_pick_up_points.Cities.city_name,
                customerId = (int)o.customer_id,
                status = o.Statuses.status_name,
                order = o
            }));

            var compContext = DBcontext.Order_composition
                .Include(o => o.Orders)
                .Include(o => o.Books)
                .ToList();
            comps = new List<TableComp>(compContext.Select(o => new TableComp
            {
                id = o.id,
                orderId = (int)o.order_id,
                amount = o.Amount,
                bookName = o.Books.title,
                comp = o
            }));

            OrderCompositionTable.ItemsSource = comps;
            OrderTable.ItemsSource = orders;

            var comboPointContext = DBcontext.order_pick_up_points
                .Include(o => o.Cities)
                .ToList();
            List<string> PointItems = new List<string>();
            foreach (order_pick_up_points point in comboPointContext)
            {
                PointItems.Add(point.Cities.city_name);
            }
            ComboPoints.ItemsSource = PointItems;

            var comboStatusContext = DBcontext.Statuses.ToList();
            List<string> StatusItems = new List<string>();
            foreach (Statuses status in comboStatusContext)
            {
                StatusItems.Add(status.status_name);
            }
            ComboStatuses.ItemsSource = StatusItems;

            var comboTitleContext = DBcontext.Books.ToList();
            List<string> TitleItems = new List<string>();
            foreach (Books book in comboTitleContext)
            {
                TitleItems.Add(book.title);
            }
            ComboTitle.ItemsSource = TitleItems;

            if (roleId == 2)
            {
                Delete.Visibility = Visibility.Collapsed;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(OrderTable.SelectedItem != null)
            {
                temporder = orders.Find(o => o.id == ((TableOrder)OrderTable.SelectedItem).id);
                DBcontext.Orders.Remove(temporder.order);

                DBcontext.Order_composition.RemoveRange(DBcontext.Order_composition.Where(o => o.order_id == temporder.id).ToList());

                DBcontext.SaveChanges();
                orders.Remove(temporder);

                temporder = null;
                OrderTable.ItemsSource = null;
                OrderTable.ItemsSource = orders;
                OrderCompositionTable.ItemsSource = null;
                OrderCompositionTable.ItemsSource = comps;
            }
            else if (OrderCompositionTable.SelectedItem != null)
            {
                tempComp = comps.Find(o => o.id == ((TableComp)OrderCompositionTable.SelectedItem).id);
                DBcontext.Order_composition.Remove(tempComp.comp);

                if(DBcontext.Order_composition.ToList().Find(o => o.order_id == tempComp.orderId) == null)
                {
                    DBcontext.Orders.RemoveRange(DBcontext.Orders.Where(o => o.id == tempComp.orderId).ToList());
                    orders.RemoveAll(c => c.id == tempComp.orderId);
                }

                comps.Remove(tempComp);
                DBcontext.SaveChanges();

                tempComp = null;
                OrderCompositionTable.ItemsSource = null;
                OrderCompositionTable.ItemsSource = comps;
                OrderTable.ItemsSource = null;
                OrderTable.ItemsSource = orders;
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления", "Запись не выбрана", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (temporder != null)
            {
                temporder.orderPoint = (string)ComboPoints.SelectedValue;
                temporder.status = (string)ComboStatuses.SelectedValue;

                var points = DBcontext.order_pick_up_points
                    .Include(p => p.Cities)
                    .ToList();
                var statuses = DBcontext.Statuses.ToList();

                temporder.order.order_pick_up_point_id = points.Find(p => p.Cities.city_name == temporder.orderPoint).id;
                temporder.order.status_id = statuses.Find(p => p.status_name == temporder.status).id;
                DBcontext.SaveChanges();

                OrderTable.ItemsSource = null;
                OrderTable.ItemsSource = orders;

                temporder = null;
            }
            else if (tempComp != null)
            {
                tempComp.bookName = (string)ComboTitle.SelectedValue;
                tempComp.amount = newAmount;

                var books = DBcontext.Books.ToList();

                tempComp.comp.book_id = books.Find(p => p.title == tempComp.bookName).id;
                tempComp.comp.Amount = newAmount;
                DBcontext.SaveChanges();

                OrderCompositionTable.ItemsSource = null;
                OrderCompositionTable.ItemsSource = comps;
                tempComp = null;
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования", "Запись не выбрана", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrderTable.SelectedItem != null)
            {
                temporder = orders.Find(o => o.id == ((TableOrder)OrderTable.SelectedItem).id);
                ComboStatuses.SelectedValue = ((TableOrder)OrderTable.SelectedItem).status;
                ComboPoints.SelectedValue = ((TableOrder)OrderTable.SelectedItem).orderPoint;
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования", "Запись не выбрана", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditComp_Click(object sender, RoutedEventArgs e)
        {
            if (OrderCompositionTable.SelectedItem != null)
            {
                tempComp = comps.Find(o => o.id == ((TableComp)OrderCompositionTable.SelectedItem).id);
                ComboTitle.SelectedValue = ((TableComp)OrderCompositionTable.SelectedItem).bookName;
                BoxAmount.Text = ((TableComp)OrderCompositionTable.SelectedItem).amount.ToString();
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования", "Запись не выбрана", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BoxAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(int.TryParse(BoxAmount.Text, out newAmount))
            {

            }
            else
            {
                MessageBox.Show("Введите корректное число", "Некорректный ввод", MessageBoxButton.OK, MessageBoxImage.Error);
                BoxAmount.Text = tempComp.amount.ToString();
            }

        }
    }
}
