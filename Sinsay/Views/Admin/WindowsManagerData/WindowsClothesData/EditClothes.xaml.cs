using Sinsay.Models;
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
