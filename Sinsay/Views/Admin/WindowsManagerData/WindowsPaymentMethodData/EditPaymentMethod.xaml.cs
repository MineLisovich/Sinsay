using Sinsay.Models;
using Sinsay.ViewsModels.AdminVM;
using System.Windows;

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsPaymentMethodData
{
    /// <summary>
    /// Interaction logic for EditPaymentMethod.xaml
    /// </summary>
    public partial class EditPaymentMethod : Window
    {
        public EditPaymentMethod(PaymentMethod method)
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
            AdminDataManagerVM.SelectedPaymentMethod = method;
            AdminDataManagerVM.NamePaymentMethod = method.Name;
        }
    }
}
