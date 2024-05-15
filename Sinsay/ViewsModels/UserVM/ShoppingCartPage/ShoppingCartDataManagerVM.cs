using Sinsay.Models;
using Sinsay.Sevices;
using Sinsay.Sevices.OrderServices;
using Sinsay.Sevices.PaymentMethodService;
using Sinsay.Sevices.PickiupPointService;
using Sinsay.Sevices.ShoppingCartService;
using Sinsay.Views.Admin;
using Sinsay.Views.User.WindowsShoppingCart.MakeOrder;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Sinsay.ViewsModels.UserVM.ShoppingCartPage
{
    public class ShoppingCartDataManagerVM : INotifyPropertyChanged
    {
        //initialization prop

        public static ShoppingCart SelectedShoppingCart { get; set; }
        public static PickupPoint SelectedPickupPoint { get; set; }
        public static PaymentMethod SelectedPaymentMethod { get; set; }

        public List<ShoppingCart> Items { get; set; }

        private decimal _totalPrice;

        public ShoppingCartDataManagerVM()
        {
            Items = shoppingCarts;
            _totalPrice = 0;
            foreach (var item in Items)
            {
                _totalPrice = _totalPrice + item.Clothes.Price;
            }
        }
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                    NotifyPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        //initialization data
        private List<ShoppingCart> shoppingCarts = ShoppingCartService.GetShoppingCart(userId: App.currentUser.Id);
        public List<ShoppingCart> ShoppingCarts
        {
            get { return shoppingCarts; }
            set { shoppingCarts = value; NotifyPropertyChanged(nameof(ShoppingCarts)); }
        }
        //PaymentMethod
        private List<PaymentMethod> allPaymentMethods = PaymentMethodService.GetAllPaymentMethod();
        public List<PaymentMethod> AllPaymentMethods
        {
            get { return allPaymentMethods; }
            set { allPaymentMethods = value; NotifyPropertyChanged(nameof(AllPaymentMethods)); }
        }
        //PickupPoint
        private List<PickupPoint> allPickupPoint = PickiupPointService.GetAllPickupPoint();
        public List<PickupPoint> AllPickupPoint
        {
            get { return allPickupPoint; }
            set { allPickupPoint = value; NotifyPropertyChanged(nameof(AllPickupPoint)); }
        }

        //Delete To ShopingCart
        private readonly RelayCommand deleteToShopingCart;
        public RelayCommand DeleteToShopingCart
        {
            get
            {
                return deleteToShopingCart ?? new RelayCommand(obj =>
                {
                    if (SelectedShoppingCart is not null)
                    {
                        bool result = ShoppingCartService.DeleteShoppingCartItem(SelectedShoppingCart.ClothersId);
                        if (result is true)
                        {

                            TotalPrice -= SelectedShoppingCart.Clothes.Price;

                            ShoppingCarts = ShoppingCartService.GetShoppingCart(userId: App.currentUser.Id);
                            Sinsay.Views.User.WindowsShoppingCart.ShoppingCartPage.ShoppingCartLV.ItemsSource = null;
                            Sinsay.Views.User.WindowsShoppingCart.ShoppingCartPage.ShoppingCartLV.Items.Clear();
                            Sinsay.Views.User.WindowsShoppingCart.ShoppingCartPage.ShoppingCartLV.ItemsSource = ShoppingCarts;
                            Sinsay.Views.User.WindowsShoppingCart.ShoppingCartPage.ShoppingCartLV.Items.Refresh();
                            MessageBox.Show("Товар успешно удалён из корзины", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Товар не был удалён из корзины", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }

                    }
                });
            }
        }
        //OpenCreateOrder
        private void OpenCreateOrderWND()
        {    
            CreateOrderPage wnd = new CreateOrderPage();
            wnd.ShowDialog();
        }
        private RelayCommand openCreateOrder;
        public RelayCommand OpenCreateOrder
        {
            get
            {
                
                return openCreateOrder ?? new RelayCommand(obj =>
                {
                    if (TotalPrice > 0)
                    {
                        OpenCreateOrderWND();
                    }
                    else
                    {
                        MessageBox.Show("Корзина пуста","Внимание",MessageBoxButton.OK,MessageBoxImage.Warning);
                    }
                    
                });
            }
        }
        //MakeOrder
        private RelayCommand makeOrder;
        public RelayCommand MakeOrder
        {
            get
            {
                return makeOrder ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;

                    if (SelectedPickupPoint is null)
                    {
                        MessageBox.Show("Укажите пункт выдачи");
                    }
                    else if (SelectedPaymentMethod is null)
                    {
                        MessageBox.Show("Укажите способ оплаты");
                    }
                    else
                    {
                        bool result = OrderService.CreateOrder(carts: ShoppingCarts,App.currentUser.Id,point: SelectedPickupPoint, payment: SelectedPaymentMethod, totalPrice: TotalPrice);
                        if (result is true)
                        {
                            MessageBox.Show("Заказ оформлен. Подробная информация на странице: Мои заказы", "Заказ оформлен", MessageBoxButton.OK, MessageBoxImage.Information);
                           
                        }
                        else
                        {
                            MessageBox.Show("Заказ не был оформлен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                            
                        }
                        TotalPrice = 0;
                        ShoppingCarts = ShoppingCartService.GetShoppingCart(userId: App.currentUser.Id);
                        Sinsay.Views.User.WindowsShoppingCart.ShoppingCartPage.ShoppingCartLV.ItemsSource = null;
                        Sinsay.Views.User.WindowsShoppingCart.ShoppingCartPage.ShoppingCartLV.Items.Clear();
                        Sinsay.Views.User.WindowsShoppingCart.ShoppingCartPage.ShoppingCartLV.ItemsSource = ShoppingCarts;
                        Sinsay.Views.User.WindowsShoppingCart.ShoppingCartPage.ShoppingCartLV.Items.Refresh();
                        wnd.Close();
                    }
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
