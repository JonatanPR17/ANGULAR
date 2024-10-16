using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Auth.Models
{
    public class LoginRequest
    {
        public string Mail {  get; set; }
        public string Password { get; set; }
    }
}
