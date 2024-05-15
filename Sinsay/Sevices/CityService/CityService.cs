using Sinsay.Domain;
using Sinsay.Models;

namespace Sinsay.Sevices.CityService
{
    public static class CityService
    {
        

        public static List<City> GetAllCities()
        {
            using (AppDbContext db = new())
            {
                List<City> cities = db.Citys.ToList();
                return cities;
            }
             
        }

        public static List<City> SearchCityList(string search)
        {
            using (AppDbContext db = new())
            {
                
                    List<City> cities = db.Citys.Where(x => x.Name.Contains(search)).ToList();
                    return cities;
            }
        }
        public static bool AddCity(string name)
        {
            try
            {
                City city = new()
                {
                    Name = name
                };
                using (AppDbContext db = new())
                {
                    db.Citys.Add(city);
                    db.SaveChanges();
                }
                 
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool EditCity(City city, string cityName)
        {
            try
            {
                using (AppDbContext db = new())
                {
                    City? getcity = db.Citys.FirstOrDefault(x => x.Id == city.Id);
                    getcity.Name = cityName;
                    db.SaveChanges();
                }
               
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteCity(int id)
        {
            using (AppDbContext db = new())
            {
                City? city = db.Citys.FirstOrDefault(x => x.Id == id);
                if (city is null) { return false; }
                try
                {
                    db.Citys.Remove(city);
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
