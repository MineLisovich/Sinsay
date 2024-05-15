using Sinsay.ViewsModels.AdminVM;
using System.Windows;


namespace Sinsay.Views.Admin.WindowsManagerData.WindowsClothesData
{
    /// <summary>
    /// Interaction logic for AddClothes.xaml
    /// </summary>
    public partial class AddClothes : Window
    {
        public AddClothes()
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
        }
    }
}
