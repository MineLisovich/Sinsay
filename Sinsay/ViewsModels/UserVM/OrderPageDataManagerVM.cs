using Sinsay.Models;
using Sinsay.Sevices;
using Sinsay.Sevices.OrderServices;
using Sinsay.Views.User.WindowsOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sinsay.ViewsModels.UserVM
{
    public class OrderPageDataManagerVM : INotifyPropertyChanged
    {

        //initialization prop
        public static Order SelectedOrder { get; set; }
        public static string SearchOrderName { get; set; }

        //initialization data
        private List<Order> allOrders = OrderService.GetOrgersForUserArea(App.currentUser.Id);
        public List<Order> AllOrders 
        { 
            get { return allOrders; }
            set { allOrders = value; NotifyPropertyChanged(nameof(AllOrders)); }
        }

        //CancelOrder
        private RelayCommand cancelOrder;
        public RelayCommand CancelOrder
        {
            get
            {
                return cancelOrder ?? new RelayCommand(obj =>
                {
                    if (SelectedOrder is not null)
                    {
                        bool result = OrderService.CancelOrderForUserArea(SelectedOrder.Id);
                        if(result is true)
                        {
                            AllOrders = OrderService.GetOrgersForUserArea(App.currentUser.Id);
                            OrderPage.AllUserOrdersLV.ItemsSource = null;
                            OrderPage.AllUserOrdersLV.Items.Clear();
                            OrderPage.AllUserOrdersLV.ItemsSource = AllOrders;
                            OrderPage.AllUserOrdersLV.Items.Refresh();
                            MessageBox.Show("Вы отменили заказ", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Заказ не был отменён", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                });
            }
        }
        // SearchOrdersCom ClearSearchOrdersCom
        private RelayCommand searchOrdersCom;
        public RelayCommand SearchOrdersCom
        {
            get
            {
                return searchOrdersCom ?? new RelayCommand(obj =>
                {
                    AllOrders = OrderService.SearchOrderList(userId:App.currentUser.Id, search: SearchOrderName);
                    OrderPage.AllUserOrdersLV.ItemsSource = null;
                    OrderPage.AllUserOrdersLV.Items.Clear();
                    OrderPage.AllUserOrdersLV.ItemsSource = AllOrders;
                    OrderPage.AllUserOrdersLV.Items.Refresh();
                });
            }
        }
        private RelayCommand clearSearchOrdersCom;
        public RelayCommand ClearSearchOrdersCom
        {
            get
            {
                return clearSearchOrdersCom ?? new RelayCommand(obj =>
                {
                    AllOrders = OrderService.GetOrgersForUserArea(userId: App.currentUser.Id);
                    OrderPage.AllUserOrdersLV.ItemsSource = null;
                    OrderPage.AllUserOrdersLV.Items.Clear();
                    OrderPage.AllUserOrdersLV.ItemsSource = AllOrders;
                    OrderPage.AllUserOrdersLV.Items.Refresh();
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
