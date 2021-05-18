using System;

namespace Healthware.Shared
{
    public class SessionActivity : BaseEntity
    {
        public User User { get; set; }
        public DateTime SessionStartDateTime { get; set; }
        public DateTime LastLoggedInDateTime { get; set; }
        public bool Active { get; set; }
    }
}
