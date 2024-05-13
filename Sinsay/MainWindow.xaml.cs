using Sinsay.Models;
using Sinsay.Sevices.AuthService;
using Sinsay.Views.Account;
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

namespace Sinsay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       AuthService _authService = new();
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void HLinkRegistrationClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                if(!String.IsNullOrEmpty(tb_Email.Text) && !String.IsNullOrEmpty(tb_Password.Password))
                {
                     AppUser user = _authService.SignIn(email: tb_Email.Text, password: tb_Password.Password);
                     App.currentUser = user;        
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
