using Sinsay.Models;

namespace Sinsay.Domain.Predefined
{
    public class PD_PaymentMethods
    {
        PaymentMethod paymentMethod1 = new()
        { 
            Id = 1,
            Name = "Оплата картой при получении"
        };
        PaymentMethod paymentMethod2 = new()
        {
            Id = 2,
            Name = "Оплата наличными при получении"
        };

        public readonly List<PaymentMethod> paymentMethods;

        public PD_PaymentMethods()
        {
            paymentMethods = new()
            {
                paymentMethod1, paymentMethod2
            };
        }
    }
}
