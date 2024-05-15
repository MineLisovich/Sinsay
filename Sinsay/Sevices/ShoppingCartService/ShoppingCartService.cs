using Microsoft.EntityFrameworkCore;
using Sinsay.Domain;
using Sinsay.Models;

namespace Sinsay.Sevices.ShoppingCartService
{
    public static class ShoppingCartService
    {


        public static List<ShoppingCart> GetShoppingCart (int userId)
        {
            using (AppDbContext db = new())
            {
                List<ShoppingCart>  carts = db.ShoppingCarts.Include(x=>x.AppUser).Include(x=>x.Clothes).Where(x=>x.AppUserId == userId).ToList();
                return carts;
            }
        }

        public static bool AddToShoppingCart (int userId, int clothesId)
        {
            try
            {
                ShoppingCart cart = new()
                {
                    AppUserId = userId,
                    ClothersId = clothesId
                };
                using (AppDbContext db =new())
                {
                    db.ShoppingCarts.Add(cart);
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteShoppingCartItem(int clothesId)
        {
            using (AppDbContext db = new())
            {
                ShoppingCart? item = db.ShoppingCarts.FirstOrDefault(x => x.ClothersId == clothesId);
                if (item is null) { return false;  }
                try
                {
                    db.ShoppingCarts.Remove(item);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
