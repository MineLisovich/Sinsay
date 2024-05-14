using Sinsay.Domain;
using Sinsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinsay.Sevices.PaymentMethodService
{
    public static class PaymentMethodService
    {
        public static List<PaymentMethod> GetAllPaymentMethod()
        {
            using (AppDbContext db = new())
            {
                List<PaymentMethod> paymentMethod = db.PaymentMethods.ToList();
                return paymentMethod;
            }

        }

        public static bool AddPaymentMethod(string name)
        {
            try
            {
                PaymentMethod paymentMethod = new()
                {
                    Name = name
                };
                using (AppDbContext db = new())
                {
                    db.PaymentMethods.Add(paymentMethod);
                    db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool EditPaymentMethod(PaymentMethod paymentMethod, string name)
        {
            try
            {
                using (AppDbContext db = new())
                {
                    PaymentMethod? getpaymentMethod = db.PaymentMethods.FirstOrDefault(x => x.Id == paymentMethod.Id);
                    getpaymentMethod.Name = name;
                    db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeletePaymentMethod(int id)
        {
            using (AppDbContext db = new())
            {
                PaymentMethod? paymentMethod = db.PaymentMethods.FirstOrDefault(x => x.Id == id);
                if (paymentMethod is null) { return false; }
                try
                {
                    db.PaymentMethods.Remove(paymentMethod);
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
