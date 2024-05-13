namespace Sinsay.Models
{
    public class Clothes
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public bool IsVisible { get; set; } = true;
        public string? Image {  get; set; }
    }
}
