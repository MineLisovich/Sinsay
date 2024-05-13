using System.ComponentModel.DataAnnotations.Schema;

namespace Sinsay.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public DateTime? LastVisit { get; set; }
        public bool isBloced { get; set; } = false;
    }
}
