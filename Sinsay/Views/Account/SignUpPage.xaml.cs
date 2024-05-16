using System.Windows;
using Sinsay.Sevices.AuthService;
using Sinsay.Models;
using Sinsay.Views.User;

namespace Sinsay.Views.Account
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Window
    {
        AuthService _authService= new();
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tb_Email.Text) && !String.IsNullOrEmpty(tb_Password.Password) && !String.IsNullOrEmpty(tb_UserName.Text) && !String.IsNullOrEmpty(tb_PhoneNumber.Text))
                {
                   
                    AppUser user = _authService.Register(email: tb_Email.Text, userName: tb_UserName.Text, password: tb_Password.Password, phoneNumber: tb_PhoneNumber.Text);
                    App.currentUser = user;
                    //user
                    if (user.RoleId == 2)
                    {
                        UserHomePage userHomePage = new UserHomePage();
                        userHomePage.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch { }
        }

        private void HLinkLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }
    }
}
