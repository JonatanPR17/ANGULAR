using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Auth.Models
{
    public class UserAppProfile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Mail { get; set; }
        public RolAppProfile? Rol { get; set; }
    }
}
