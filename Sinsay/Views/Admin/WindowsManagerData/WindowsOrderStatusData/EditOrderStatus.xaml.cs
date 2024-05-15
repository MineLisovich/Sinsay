using Sinsay.Models;
using Sinsay.ViewsModels.AdminVM;
using System.Windows;


namespace Sinsay.Views.Admin.WindowsManagerData.WindowsOrderStatusData
{
    /// <summary>
    /// Interaction logic for EditOrderStatus.xaml
    /// </summary>
    public partial class EditOrderStatus : Window
    {
        public EditOrderStatus(OrderStatus status)
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
            AdminDataManagerVM.SelectedOrderStatus = status;
            AdminDataManagerVM.NameOrderStatus = status.Name;
        }
    }
}
