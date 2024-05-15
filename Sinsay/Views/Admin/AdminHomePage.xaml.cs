using Sinsay.ViewsModels.AdminVM;
using System.Windows;
using System.Windows.Controls;


namespace Sinsay.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : Window
    {
        public static ListView AllCitiesLV;
        public static ListView AllOrderStatusLV;
        public static ListView AllPaymentMethodLV;
        public static ListView AllPickupPointLV;
        public static ListView AllAppUsers;
        public static ListView AllClothes;
        public AdminHomePage()
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
            AllCitiesLV = ViewAllCities;
            AllOrderStatusLV = ViewAllOrderStatus;
            AllPaymentMethodLV = ViewAllPaymentMethods;
            AllPickupPointLV = ViewAllPickupPoint;
            AllAppUsers = ViewAllAppUsers;
            AllClothes = ViewAllClothes;
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
    }
}
