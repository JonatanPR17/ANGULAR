using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_domain.Auth.Models;
using vet_tomy_domain.Auth.Repositories;
using vet_tomy_domain.Auth.Services;

namespace vet_tomy_data.Auth.Repository
{
    public class AuthenticationRepositoryImpl : IAuthenticationRepository
    {

        private readonly IAuthenticationService _authService;

        public AuthenticationRepositoryImpl(IAuthenticationService authService) 
        {
            _authService = authService;
        }
        public LoginResponse Login(LoginRequest login)
        {
            return _authService.Login(login);
        }

        public void Register(RegisterRequest data)
        {
            _authService.Register(data);
        }
    }
}
