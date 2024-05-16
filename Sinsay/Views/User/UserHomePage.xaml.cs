using Sinsay.Views.Admin.WindowsManagerData.WindowsClothesData;
using Sinsay.Views.User.WindowsOrder;
using Sinsay.Views.User.WindowsShoppingCart;
using Sinsay.ViewsModels.UserVM.MainPage;
using System.Windows;
using System.Windows.Controls;


namespace Sinsay.Views.User
{
    /// <summary>
    /// Interaction logic for UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage : Window
    {
        public static ListView AllClothes;
        public UserHomePage()
        {
            InitializeComponent();
            DataContext = new MainPageDataManagerVM();
            AllClothes = ViewAllClothesUserArea;
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

        private void shoppingCart_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartPage shoppingCartPage = new ShoppingCartPage();
            shoppingCartPage.Show();
            this.Close();
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            OrderPage orderPage = new OrderPage();
            orderPage.Show();
            this.Close();
        }
    }
}
