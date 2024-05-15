using Sinsay.ViewsModels.AdminVM;
using System.Windows;

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsUserData
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
        }
    }
}
