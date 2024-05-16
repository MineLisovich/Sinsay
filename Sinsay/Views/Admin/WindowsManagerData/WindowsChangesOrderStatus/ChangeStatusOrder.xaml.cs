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

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsChangesOrderStatus
{
    /// <summary>
    /// Interaction logic for ChangeStatusOrder.xaml
    /// </summary>
    public partial class ChangeStatusOrder : Window
    {
        public ChangeStatusOrder()
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
        }
    }
}
