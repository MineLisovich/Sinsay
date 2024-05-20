using Sinsay.Models;
using Sinsay.Sevices;

namespace Sinsay.Domain.Predefined
{
    public class PD_Users
    {
        AppUser user_admin = new()
        {
            Id = 1,
            Email = "admin@sinsay.ru",
            UserName = "Админ",
            PasswordHash = PasswordHashService.CreateHash("admin1234"),
            PhoneNumber = "+767644566",
            RoleId = 1,
            LastVisit = null,
            isBloced = false
        };

        AppUser user_user = new()
        {
            Id = 2,
            Email = "user@sinsay.ru",
            UserName = "Иванов",
            PasswordHash = PasswordHashService.CreateHash("user1234"),
            PhoneNumber = "+789324325676",
            RoleId = 2,
            LastVisit = null,
            isBloced = false
        };

        public readonly List<AppUser> users;
        public PD_Users()
        {
            users = new()
            {
                user_admin, user_user
            };
        }
    }
}
