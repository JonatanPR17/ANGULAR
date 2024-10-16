using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_domain.Auth.Models;

namespace vet_tomy_domain.Auth.Services
{
    public interface IAuthenticationService
    {
        public LoginResponse Login(LoginRequest login);

        public void Register(RegisterRequest data);
    }
}
