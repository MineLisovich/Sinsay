using Sinsay.ViewsModels.UserVM.ShoppingCartPage;
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

namespace Sinsay.Views.User.WindowsShoppingCart
{
    /// <summary>
    /// Interaction logic for ShoppingCartPage.xaml
    /// </summary>
    public partial class ShoppingCartPage : Window
    {
        public static ListView ShoppingCartLV;
        public ShoppingCartPage()
        {
            InitializeComponent();
            DataContext = new ShoppingCartDataManagerVM();
            ShoppingCartLV = ViewShoppingCart;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TbUserName.Text = $"Привет, {App.currentUser.UserName}";
           
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }

        private void clothes_Click(object sender, RoutedEventArgs e)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
            this.Close();
        }
    }
}
