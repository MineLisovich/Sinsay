using Sinsay.Models;
using Sinsay.ViewsModels.AdminVM;
using System.Windows;

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsPickupPointData
{
    /// <summary>
    /// Interaction logic for EditPickupPoint.xaml
    /// </summary>
    public partial class EditPickupPoint : Window
    {
        public EditPickupPoint(PickupPoint point)
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
            AdminDataManagerVM.SelectedPickupPoint = point;
            AdminDataManagerVM.NamePickupPoint = point.Name;
            AdminDataManagerVM.AddressPickupPoint = point.Address;
            AdminDataManagerVM.SelectListCityPickupPoint = point.City;
        }
    }
}
