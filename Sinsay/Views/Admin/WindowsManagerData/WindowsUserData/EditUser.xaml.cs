using Sinsay.Models;
using Sinsay.ViewsModels.AdminVM;
using System.Windows;

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsUserData
{
    /// <summary>
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser(AppUser user)
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
            AdminDataManagerVM.UserEmail = user.Email;
            AdminDataManagerVM.UserName = user.UserName;
            AdminDataManagerVM.UserPhoneNumber = user.PhoneNumber;
            AdminDataManagerVM.SelectListRolesUser = user.Role;
        }
    }
}
