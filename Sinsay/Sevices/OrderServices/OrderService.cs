using Sinsay.Domain;
using Sinsay.Models;

namespace Sinsay.Sevices.OrderServices
{
    public static class OrderService
    {
        public static bool CreateOrder(List<ShoppingCart> carts, int userId, PickupPoint point, PaymentMethod payment, decimal totalPrice)
        {
            try
            {
                string nameItem = "";
                foreach (ShoppingCart cart in carts)
                {
                    nameItem = string.Join(", ", carts.Select(cart => cart.Clothes.Name));
                }
                Order order = new()
                {
                    AppUserId = userId,
                    Name = nameItem,
                    OrderDate = DateTime.Now,
                    OrderStatusId = 1,
                    PickupPointId = point.Id,
                    PaymentMethodId = payment.Id,
                    TotalPrice = totalPrice
                };
                using(AppDbContext db = new())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();

                    //Удаляем из корзины 

                    List<ShoppingCart> shoppingCarts = db.ShoppingCarts.Where(x=>x.AppUserId == userId).ToList();
                    foreach(ShoppingCart cart in shoppingCarts)
                    {
                        db.Remove(cart);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch { return false; }
        }
    }
}
