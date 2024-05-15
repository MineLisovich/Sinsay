using Sinsay.Domain;
using Sinsay.Models;

namespace Sinsay.Sevices.ClothesService
{
    public static class ClothesService
    {
        public static List<Clothes> GetAllClothes()           
        {
            using (AppDbContext db = new())
            {
                List<Clothes> clothes = db.Clothes.ToList();
                return clothes;
            }
        }

        public static List<Clothes> SearchClothesList(string search)
        {
            using (AppDbContext db = new())
            {

                List<Clothes> clothes = db.Clothes.Where(x => x.Name.Contains(search)).ToList();
                return clothes;
            }
        }

        public static bool AddClothes(string name, string descr, int count, decimal price)
        {
            try
            {
                Clothes clothes = new()
                {
                    Name = name,
                    Description = descr,
                    Price = price,
                    Count = count,
                };
                using (AppDbContext db = new())
                {
                    db.Clothes.Add(clothes);
                    db.SaveChanges();
                }
                return true;
            }
            catch { return false; }
        }

        public static bool EditClothes(Clothes clothes, string name, string descr, int count, decimal price)
        {
            try
            {
                using (AppDbContext db = new())
                {
                    Clothes? getClothes = db.Clothes.FirstOrDefault(x => x.Id == clothes.Id);
                    if (getClothes is null) { return false; }
                    getClothes.Name = name;
                    getClothes.Description = descr;
                    getClothes.Price = price;
                    getClothes.Count = count;
                    db.SaveChanges();
                }
                return true;
            }
            catch { return false; }
        }
        public static bool DeleteClothes (int id)
        {
            using(AppDbContext db =new())
            {
                Clothes? clothes = db.Clothes.FirstOrDefault(x => x.Id == id);
                if (clothes is null) { return false; }
                try
                {
                    db.Clothes.Remove(clothes);
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }
    }
}
