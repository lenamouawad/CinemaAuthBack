using cinemas.Models;
using cinemas.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace cinemas.Services
{
    public class UsersService
    {

        private LoginRepository repository;
        public UsersService(LoginRepository repository)
        {
            this.repository = repository;
        }

        public Login FindUserByUsername(string username)
        {
            return this.repository.FindUserByUsername(username);
        }

        public Login FindUser(Login user)
        {
            return this.repository.FindUser(user);
        }

        public AuthenticatedResponse Login(Login login)
        {
            AuthenticatedResponse response = new AuthenticatedResponse();

            Login user = FindUser(login);

            // Si l'utilisateur existe et son mdp est correct :
            if (user != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };

                if (user.Username == "admin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ma clé super secrète"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7266",
                    audience: "https://localhost:7266",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60), // A changer ?
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);   
                response = new AuthenticatedResponse { Token = tokenString };                
            }

            return response;
        }

        public List<Login> CreateUser(Login login)
        {
            return this.repository.CreateUser(login);
        }


        public List<Login> GetAllUsers()
        {
            return this.repository.GetAllUsers();

        }

        public List<Login> DeleteAllUsers()
        {
            return this.repository.DeleteAllUsers();
        }
    }
}
