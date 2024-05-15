using Sinsay.Models;
using Sinsay.ViewsModels.AdminVM;
using System.Windows;

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsClothesData
{
    /// <summary>
    /// Interaction logic for EditClothes.xaml
    /// </summary>
    public partial class EditClothes : Window
    {
        public EditClothes(Clothes clothes)
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
            AdminDataManagerVM.ClothesName = clothes.Name;
            AdminDataManagerVM.ClothesDescription = clothes.Description;
            AdminDataManagerVM.ClothesPrice = clothes.Price;
            AdminDataManagerVM.ClothesCount = clothes.Count;
        }
    }
}
