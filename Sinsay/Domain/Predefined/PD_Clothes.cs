using Sinsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinsay.Domain.Predefined
{
    public class PD_Clothes
    {
        Clothes clothes1 = new() 
        { 
            Id = 1,
            Name = "Шляпа",
            Description = "Шляпа модная",
            Count = 100,
            Price = 134.34m,
        };
        Clothes clothes2 = new()
        {
            Id = 2,
            Name = "Штаны",
            Description = "Штаны дьявола",
            Count = 100,
            Price = 666.66m,
        };
        Clothes clothes3 = new()
        {
            Id = 3,
            Name = "Майка",
            Description = "Майка алкаша",
            Count = 100,
            Price = 99.00m,
        };
        Clothes clothes4 = new()
        {
            Id = 4,
            Name = "Шлёпки",
            Description = "Шлёпки ковбойские",
            Count = 100,
            Price = 664.34m,
        };
        Clothes clothes5 = new()
        {
            Id = 5,
            Name = "Кепарик",
            Description = "Кепарик чёткий",
            Count = 100,
            Price = 34.34m,
        };

        public readonly List<Clothes> clothes;  

        public PD_Clothes()
        {
            clothes = new()
            {
                clothes1, clothes2, clothes3, clothes4, clothes5
            };
        }
    }
}
