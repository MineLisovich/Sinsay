

using Sinsay.Models;

namespace Sinsay.Domain.Predefined
{
    public class PD_PickupPoints
    {
        PickupPoint pickupPoint1 = new()
        {
            Id = 1,
            Name = "ТЦ Атлант",
            Address = "ул. Колотушкина 12, 2 этаж п.215",
            CityId = 1,
        };

        public readonly List<PickupPoint> pickupPoints;

        public PD_PickupPoints()
        {
            pickupPoints = new()
            {
                pickupPoint1
            };
        }
    }
}
