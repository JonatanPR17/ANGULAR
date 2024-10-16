using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Auth.Models;
using vet_tomy_domain.Auth.Services;
using vet_tomy_domain.Errors;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace vet_tomy_data.Auth.Service
{
    /// <summary>
    /// Heredando
    /// </summary>
    public class AuthenticationServiceDbImpl : IAuthenticationService
    {
        private readonly VetDbContext _db;
        private readonly ILogger<AuthenticationServiceDbImpl> _logger;
        //private readonly IConfigurationRoot _conf;
        public AuthenticationServiceDbImpl(VetDbContext db, ILogger<AuthenticationServiceDbImpl> logger) 
        {
            _db = db;
            _logger = logger;
        }

        //optimizando codigo
        //implementar el cifrado y validacion
        public LoginResponse Login(LoginRequest login)
        {
            /*
            var user = _db.User.Where(
                //Select * from usario where email ="adsa" and clave=!fgrefwd" ans State = true
                (u) => u.Mail == login.Mail && u.Password == login.Password && u.State
                ).FirstOrDefault();

            //top 5 , es take 5

            if (user != null) 
            {
                var person = _db.Person.Where(p=>p.Id == user.PersonId).FirstOrDefault();
                var role = _db.Role.Where(r=>r.Id == user.RolId).FirstOrDefault();

            }*/

            var user = _db.User.Where(f=>f.Mail == login.Mail).FirstOrDefault();

            if (user == null) 
            {
                throw new Exception("Credenciales incorrectas");
            }

            //Hashear el password
            login.Password = GenerateSaltedHash(login.Password, user.Salt);

            if (login.Password == null) 
            {
                throw new MessageExeption("soy nulo");
            }

            _logger.LogInformation($"HASHED PASSWORD ====> {login.Password} no se nada pipipi");

            var request = _db.User.Join(
                _db.Person,
                (u) => u.PersonId,
                (p) => p.Id,
                (u, p) => new { user1 = u, person1 = p }
                ).Join(
                _db.Role,
                    (up) => up.user1.RolId,
                    (r) => r.Id,
                    (up, r) => new { user = up.user1 , person= up.person1 , role = r }
                ).Where(
                    (upr) => upr.user.Mail == login.Mail && upr.user.Password == login.Password && upr.user.State
                ).FirstOrDefault();

            if (request == null) 
            {
                throw new MessageExeption($"Credenciales incorrectas pero correctas");
            }


            var profile = new UserAppProfile
            {
                Id = request.person.Id,
                Name = request.person.Name,
                LastName = request.person.LastName,
                Mail = request.user.Mail,
                Rol = new RolAppProfile
                {
                    Id = request.role.Id,
                    Name = request.role.Name,
                }
            };

            return new LoginResponse
            {
                Token = GetJWT(profile),
                Profile = profile,
            };
        }
        public void Register(RegisterRequest data)
        {
            int CUSTOMER_ROL = 3;

            //Crear persona
            var person = new PersonTable { 
                Name = data.Name,
                LastName = data.LastName,
                DocumentType = "htrgefwd",
                DocumentNumber = "yhtrgefw",
                BussinessName = "yhtrgefwq",
                Address = "nytbrvecw",
                CellPhoneNumber = "mnutyrbevcwsxa",
                State = true,
            };
            _db.Person.Add(person);
            _db.SaveChanges();


            //Crear salt
            string salt = CreateSalt();

            //Reemplazar la contraseña

            data.Password = GenerateSaltedHash(data.Password, salt);

            //Crear usuario
            //Poniendo por defecto el rol 3, el mas bajo

            var user = new UserTable
            {
                PersonId = person.Id,
                RolId = CUSTOMER_ROL,
                Mail = data.Mail,
                Password = data.Password,
                Salt = salt,
                State = true,
            };

            _db.User.Add(user);
            _db.SaveChanges();

        }
        /*private static string GenerateSaltedHash(string passwordStr, string saltStr) 
        {
            //var utf8 = new UTF8Encoding();

            byte[] password = Encoding.ASCII.GetBytes(passwordStr);
            byte[] salt = Encoding.ASCII.GetBytes(saltStr);


            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = 
                new byte[password.Length + salt.Length];
            for (int i = 0; i < password.Length; i++) 
            {
                plainTextWithSaltBytes[i] = password[i];    
            }
            for (int i = 0; i< salt.Length; i++)
            {
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            }

            byte[] hashedPwd =  algorithm.ComputeHash(plainTextWithSaltBytes);
            return Convert.ToBase64String(hashedPwd);

        }*/

        private static string GenerateSaltedHash(string passwordStr, string saltStr)
        {
            //var utf8 = new UTF8Encoding();

            byte[] password = Encoding.ASCII.GetBytes(passwordStr);
            byte[] salt = Encoding.ASCII.GetBytes(saltStr);




            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
                new byte[password.Length + salt.Length];

            for (int i = 0; i < password.Length; i++)
            {
                plainTextWithSaltBytes[i] = password[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            }

            byte[] hashedPwd = algorithm.ComputeHash(plainTextWithSaltBytes);
            return Convert.ToBase64String(hashedPwd);
        }


        private static string CreateSalt(int size = 64)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }


        private string GetJWT(UserAppProfile profile) 
        {
            //Crear los claims (crear payload)
            ClaimsIdentity claims = GenerateClaims(profile);
            //Definir el timepo de expiracion
            int expireInMinuts = 30; //Debe venir de la configuracion
            //jALAS LA HORA LOCAL CON UTCnow + los minutos que le damos
            DateTime expire = DateTime.UtcNow.AddMinutes(expireInMinuts);
            string KEY = "ctvybunim,ñlmknjhvgcvjg7h65j4k3llj5hj643klñ26hj54kl33&%$·$$/&%$·!)=)(/&%$/&%$";
            //Generar el token
            return GenerateToken(claims, expire, KEY);

        }

        //Generar los claims
        //Creamos el Payload data (llave valor)
        private ClaimsIdentity GenerateClaims(UserAppProfile profile) 
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity ();
            //Rol Id
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.Role, profile.Rol.Id.ToString())
                );
            //Id
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.NameIdentifier, profile.Id.ToString()));
            //Email
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.Email, profile.Mail.ToString())
                );
            //Name
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.Name, profile.Name.ToString())
                );
            //Agregar lo que quieras
            return claimsIdentity;
        }


        private string GenerateToken(ClaimsIdentity claimsIdentity, DateTime expires, string secret) 
        {
            var Key = Encoding.UTF8.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = expires,
                //creando credenciales para generar el token
                //Usando nuestros secretkey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(createdToken);
            return token;

        }


    }
}
