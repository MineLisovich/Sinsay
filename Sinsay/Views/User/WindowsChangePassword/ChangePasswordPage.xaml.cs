using Sinsay.ViewsModels.UserVM.MainPage;
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

namespace Sinsay.Views.User.WindowsChangePassword
{
    /// <summary>
    /// Interaction logic for ChangePasswordPage.xaml
    /// </summary>
    public partial class ChangePasswordPage : Window
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
            DataContext = new MainPageDataManagerVM();
        }
    }
}
