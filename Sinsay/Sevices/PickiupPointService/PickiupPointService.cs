using Microsoft.EntityFrameworkCore;
using Sinsay.Domain;
using Sinsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinsay.Sevices.PickiupPointService
{
    public static class PickiupPointService
    {
        public static List<PickupPoint> GetAllPickupPoint()
        {
            using (AppDbContext db = new())
            {
                List<PickupPoint> pickupPoints = db.PickupPoints.Include(x=>x.City).ToList();
                return pickupPoints;
            }
        }

        public static bool AddPickupPoint (string name, string address, City _city)
        {
            try
            {
                PickupPoint pickupPoint = new()
                {
                    Name = name,
                    Address = address,
                    CityId = _city.Id
                };
                using (AppDbContext db = new())
                {
                    db.PickupPoints.Add(pickupPoint);
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool EditPickupPoint (PickupPoint pickupPoint, string name, string address, City _city)
        {
            try
            {
                using (AppDbContext db = new())
                {
                    PickupPoint? point = db.PickupPoints.FirstOrDefault(x=>x.Id == pickupPoint.Id);
                    if (point is null) { return false;  }
                    point.Name = name;
                    point.Address = address;
                    point.CityId = _city.Id;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeletePickupPoint (int id)
        {
            using (AppDbContext db = new())
            {
                PickupPoint? point = db.PickupPoints.FirstOrDefault (x=>x.Id == id);
                if (point is null) { return false; }
                try
                {
                    db.PickupPoints.Remove(point);
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }
    }
}
