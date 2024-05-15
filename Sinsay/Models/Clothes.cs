using Microsoft.EntityFrameworkCore;

namespace Sinsay.Models
{
    public class Clothes
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Count { get; set; }
        [Precision(5, 2)]
        public decimal Price { get; set; }
    }
}
