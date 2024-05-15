using Sinsay.Models;
using Sinsay.ViewsModels.UserVM.ShoppingCartPage;
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

namespace Sinsay.Views.User.WindowsShoppingCart.MakeOrder
{
    /// <summary>
    /// Interaction logic for CreateOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Window
    {
        public CreateOrderPage()
        {
            InitializeComponent();
            DataContext = new ShoppingCartDataManagerVM();
           
        }
    }
}
