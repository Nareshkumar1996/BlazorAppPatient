using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthware.Shared
{
    public class Role
    {
        [Key]
        public long Id { get; set; }
        public string RoleName { get; set; }
    }
}
