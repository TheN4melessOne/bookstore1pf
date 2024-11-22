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
using static bookstore1pf.tablePage;

namespace bookstore1pf
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        List<TableBook> selectedBooks;
        public OrderPage(List<TableBook> selectedBooks1)
        {
            InitializeComponent();
            mainTable.ItemsSource = selectedBooks1;
        }

        public OrderPage()
        {
            InitializeComponent();
        }
    }
}
