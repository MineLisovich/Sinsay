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
using System.Windows.Navigation;
using Sinsay.Sevices.AuthService;
using Sinsay.Models;
using Sinsay.Views.Admin;
using Sinsay.Views.User;
using Microsoft.IdentityModel.Tokens;

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
    }
}
