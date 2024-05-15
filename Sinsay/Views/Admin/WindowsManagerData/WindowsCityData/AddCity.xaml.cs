using Sinsay.ViewsModels.AdminVM;
using System.Windows;

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsCityData
{
    /// <summary>
    /// Interaction logic for AddCity.xaml
    /// </summary>
    public partial class AddCity : Window
    {
        public AddCity()
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
        }
    }
}
