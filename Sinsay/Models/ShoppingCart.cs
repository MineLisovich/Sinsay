using System.ComponentModel.DataAnnotations.Schema;

namespace Sinsay.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        [ForeignKey(nameof(AppUser))]
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        [ForeignKey(nameof(Clothes))]
        public int ClothersId { get; set; }
        public Clothes? Clothes { get; set; }
    }
}
