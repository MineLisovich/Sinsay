using Sinsay.ViewsModels.AdminVM;
using System.Windows;


namespace Sinsay.Views.Admin.WindowsManagerData.WindowsOrderStatusData
{
    /// <summary>
    /// Interaction logic for AddOrderStatus.xaml
    /// </summary>
    public partial class AddOrderStatus : Window
    {
        public AddOrderStatus()
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
        }
    }
}
