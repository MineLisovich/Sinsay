using System.ComponentModel.DataAnnotations.Schema;

namespace Sinsay.Models
{
    public class PickupPoint
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City? City { get; set; }
    }
}
