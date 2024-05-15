using Sinsay.Models;
using Sinsay.Sevices.ShoppingCartService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinsay.ViewsModels.UserVM.ShoppingCartPage
{
    public class ShoppingCartDataManagerVM : INotifyPropertyChanged
    {
        //initialization prop
        public static decimal TotalPrice {  get; set; }
        public static ShoppingCart SelectedShoppingCart { get; set; }

        public List<ShoppingCart> Items { get; set; }

        public ShoppingCartDataManagerVM()
        {
            Items = shoppingCarts;
            TotalPrice = 0;
            foreach (var item in Items)
            {
                TotalPrice = TotalPrice + item.Clothes.Price;
            }
        }
        

        //initialization data
        private List<ShoppingCart> shoppingCarts = ShoppingCartService.GetShoppingCart(userId: App.currentUser.Id);
        public List<ShoppingCart> ShoppingCarts
        {
            get { return shoppingCarts; }
            set { shoppingCarts = value; NotifyPropertyChanged(nameof(ShoppingCarts)); }
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
