using Sinsay.Views.User.WindowsShoppingCart;
using Sinsay.ViewsModels.UserVM;
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

namespace Sinsay.Views.User.WindowsOrder
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Window
    {
        public static ListView AllUserOrdersLV;
        public OrderPage()
        {
            InitializeComponent();
            DataContext = new OrderPageDataManagerVM();
            AllUserOrdersLV = ViewAllUserOrder;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }

        private void shoppingCart_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartPage shoppingCartPage = new ShoppingCartPage();
            shoppingCartPage.Show();
            this.Close();
        }

        private void clothes_Click(object sender, RoutedEventArgs e)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TbUserName.Text = $"Привет, {App.currentUser.UserName}";
        }
    }
}
