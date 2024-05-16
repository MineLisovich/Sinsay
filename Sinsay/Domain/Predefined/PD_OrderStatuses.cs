using Sinsay.Models;

namespace Sinsay.Domain.Predefined
{
    public class PD_OrderStatuses
    {
        OrderStatus orderSt1 = new()
        {
            Id = 1,
            Name = "Принят в обработку"
        };

        OrderStatus orderSt2 = new()
        {
            Id = 2,
            Name = "Подтверждён"
        };
        OrderStatus orderSt3 = new()
        {
            Id = 3,
            Name = "Доставляется в ПВЗ"
        };
        OrderStatus orderSt4 = new()
        {
            Id = 4,
            Name = "Готов к выдаче"
        };

        OrderStatus orderSt5 = new()
        {
            Id = 5,
            Name = "Отменён"
        };
        public readonly List<OrderStatus> orders;
        public PD_OrderStatuses()
        {
            orders = new()
            {
                orderSt1, orderSt2, orderSt3, orderSt4, orderSt5
            };
        }
    }
}
