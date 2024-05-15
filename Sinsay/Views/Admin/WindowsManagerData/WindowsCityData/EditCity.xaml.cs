using Sinsay.Models;
using Sinsay.ViewsModels.AdminVM;
using System.Windows;

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsCityData
{
    /// <summary>
    /// Interaction logic for EditCity.xaml
    /// </summary>
    public partial class EditCity : Window
    {
        public EditCity(City city)
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
            AdminDataManagerVM.SelectedCity = city;
            AdminDataManagerVM.NameCity = city.Name;
        }
    }
}
