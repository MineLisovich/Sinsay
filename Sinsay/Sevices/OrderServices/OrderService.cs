using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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


                    //Электронный чек
                    SendEmailService send = new();
                    AppUser? getuser = db.Users.FirstOrDefault(x=>x.Id == userId);
                    send.SendEmailAsync(email: getuser.Email, subject: "Заказ оформлен", message:"Заказ оформлен \n Перечень товара: " + nameItem +"\n"+"Итоговая стоимость: " + order.TotalPrice);

                }
                return true;
            }
            catch { return false; }
        }

        public static List<Order> GetOrgersForUserArea(int userId)
        {
            using (AppDbContext db = new())
            {
                List<Order> orders = db.Orders.Include(x => x.AppUser).Include(x => x.OrderStatus).Include(x => x.PickupPoint).Include(x => x.PaymentMethod).Where(x => x.AppUserId == userId).ToList();
                return orders;
            }
        }

        public static bool CancelOrderForUserArea(int orderId)
        {
            try
            {
                using (AppDbContext db = new())
                {
                    Order? getOrder = db.Orders.FirstOrDefault(x=>x.Id == orderId);
                    getOrder.OrderStatusId = 5;
                    db.SaveChanges();

                    //Электронный чек
                    SendEmailService send = new();
                    AppUser? getuser = db.Users.FirstOrDefault(x => x.Id == getOrder.AppUserId);
                    send.SendEmailAsync(email: getuser.Email, subject: "Заказ отменён", message: "Вы отменили заказ");
                }
                return true;
            }
            catch { return false; }
        }

        public static List<Order> SearchOrderList(int userId, string search)
        {
            using (AppDbContext db = new())
            {
                List<Order> orders = db.Orders.Include(x => x.AppUser).Include(x => x.OrderStatus).Include(x => x.PickupPoint).Include(x => x.PaymentMethod).Where(x => x.AppUserId == userId && x.Name.Contains(search)).ToList();
                return orders;
            }
        }
    }
}
