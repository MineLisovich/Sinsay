using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sinsay.Models
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey(nameof(AppUser))]
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public required string Name { get; set; }

        public required DateTime OrderDate { get; set; }

        [ForeignKey(nameof(OrderStatus))]
        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }

        [ForeignKey(nameof(PickupPoint))]
        public int PickupPointId { get; set; }
        public PickupPoint? PickupPoint { get; set; }

        [Precision(20, 2)]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(PaymentMethod))]
        public int PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }
}
