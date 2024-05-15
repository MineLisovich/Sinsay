using Sinsay.ViewsModels.AdminVM;
using System.Windows;

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsPaymentMethodData
{
    /// <summary>
    /// Interaction logic for AddPaymentMethod.xaml
    /// </summary>
    public partial class AddPaymentMethod : Window
    {
        public AddPaymentMethod()
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
        }
    }
}
