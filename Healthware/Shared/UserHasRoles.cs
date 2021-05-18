using System.ComponentModel.DataAnnotations;

namespace Healthware.Shared
{
    public class UserHasRoles
    {
        [Key]
        public long Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
