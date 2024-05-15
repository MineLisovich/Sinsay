using Sinsay.ViewsModels.AdminVM;
using System.Windows;

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsPickupPointData
{
    /// <summary>
    /// Interaction logic for AddPickupPoint.xaml
    /// </summary>
    public partial class AddPickupPoint : Window
    {
        public AddPickupPoint()
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
        }
    }
}
