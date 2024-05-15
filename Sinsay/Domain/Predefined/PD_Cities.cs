using Sinsay.Models;

namespace Sinsay.Domain.Predefined
{
    public class PD_Cities
    {
        City city1 = new()
        {
            Id = 1,
            Name = "Москва",
        };

        public readonly List<City> cities;

        public PD_Cities()
        {
            cities = new()
            {
                city1
            };
        }
    }
}
