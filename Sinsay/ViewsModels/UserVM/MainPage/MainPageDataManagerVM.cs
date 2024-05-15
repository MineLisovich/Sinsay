using Sinsay.Models;
using Sinsay.Sevices;
using Sinsay.Sevices.ClothesService;
using Sinsay.Sevices.ShoppingCartService;
using Sinsay.Views.User;
using System.ComponentModel;
using System.Windows;

namespace Sinsay.ViewsModels.UserVM.MainPage
{
    public class MainPageDataManagerVM : INotifyPropertyChanged
    {

        //initialization prop
        public static Clothes SelectedClothes { get; set; }
        public static string SearchClothes { get; set; }


        //initialization data
        private List<Clothes> allClothes = ClothesService.GetAllClothes();
        public List<Clothes> AllClothes
        {
            get { return allClothes; }
            set { allClothes = value; NotifyPropertyChanged(nameof(AllClothes)); }
        }

        //Add To ShopingCart
        private RelayCommand addToShopingCart;
        public RelayCommand AddToShopingCart
        {
            get
            {
                return addToShopingCart ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;
                    if (SelectedClothes is not null)
                    {
                        result = ShoppingCartService.AddToShoppingCart(userId: App.currentUser.Id, clothesId: SelectedClothes.Id);
                        if (result is true)
                        {
                            MessageBox.Show("Товар успешно добавлен в корзину","Успех",MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Товар не был добавлен в корзину", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                      
                    }
                });
            }
        }

        //Search Clothes
        //searh
        private RelayCommand searchClothesCom;
        public RelayCommand SearchClothesCom
        {
            get
            {
                return searchClothesCom ?? new RelayCommand(obj =>
                {
                    AllClothes = ClothesService.SearchClothesList(SearchClothes);
                    UserHomePage.AllClothes.ItemsSource = null;
                    UserHomePage.AllClothes.Items.Clear();
                    UserHomePage.AllClothes.ItemsSource = AllClothes;
                    UserHomePage.AllClothes.Items.Refresh();
                });
            }
        }

        private RelayCommand clearSearchClothesCom;
        public RelayCommand ClearSearchClothesCom
        {
            get
            {
                return clearSearchClothesCom ?? new RelayCommand(obj =>
                {
                    AllClothes = ClothesService.GetAllClothes();
                    UserHomePage.AllClothes.ItemsSource = null;
                    UserHomePage.AllClothes.Items.Clear();
                    UserHomePage.AllClothes.ItemsSource = AllClothes;
                    UserHomePage.AllClothes.Items.Refresh();
                    SearchClothes = null;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
