using Sinsay.Models;
using Sinsay.ViewsModels.AdminVM;
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
