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
        public OrderEditing()
        {
            InitializeComponent();
            DBcontext = new Entities();

            OrderTable.ItemsSource = new ObservableCollection<Orders> (DBcontext.Orders.ToList());
            OrderCompositionTable.ItemsSource = new ObservableCollection<Order_composition>(DBcontext.Order_composition.ToList());
        }
    }
}
