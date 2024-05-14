using Sinsay.Domain;
using Sinsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinsay.Sevices.OrderServices
{
    public static class OrderStatusService
    {
        public static List<OrderStatus> GetAllOrderStatus()
        {
            using (AppDbContext db = new())
            {
                List<OrderStatus> orderStatuses = db.OrderStatus.ToList();
                return orderStatuses;
            }
        }

        public static bool AddOrderStatus(string name)
        {
            try
            {
                OrderStatus orderStatus = new() { Name = name};
                using (AppDbContext db = new())
                {
                    db.OrderStatus.Add(orderStatus);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool EditOrderStatus(OrderStatus orderStatus, string name)
        {
            try
            {
                using (AppDbContext db = new())
                {
                   OrderStatus? status = db.OrderStatus.FirstOrDefault(x => x.Id == orderStatus.Id);
                    if (status is null) { return false; }
                    status.Name = name;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteOrderStatus(int id) 
        {
            try
            {
                using (AppDbContext db = new())
                {
                    OrderStatus? status = db.OrderStatus.FirstOrDefault(x=>x.Id == id);
                    if (status is null) { return false;}
                    db.OrderStatus.Remove(status); 
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
