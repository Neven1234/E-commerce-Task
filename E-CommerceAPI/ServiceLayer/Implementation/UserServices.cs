using Azure;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer;
using ServiceLayer.Interface;
using ServiceLayer.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class UserServices : IUserService
    {
        private readonly IRepository<User, int> _repository;
        private readonly JWTOptions _configuration;

        public UserServices(IRepository<User, int> repository, IOptions<JWTOptions> configuration)
        {
            this._repository = repository;
            this._configuration = configuration.Value;
        }
        public async Task<string> LoginAsync(string username, string password)
        {
            var user= await _repository.GetAsync(x=>x.Username == username);
            if(user == null)
            {
                return null;
            }
            if (!VerifayPassword(password, user.PasswordSalt, user.PasswordHash))
            {
                return null;
            }
            var authClaims = new List<Claim>
            {
                new Claim("name",user.Username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var jwtToken = getToken(authClaims);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var expiration = DateTime.Now.AddDays(1);
           
            return token;
        }

       

        public async Task<User> Register(User user, string password)
        {
            
            byte[] PasswordHash, PasswordSalt;
            CreatePasswordHash(password, out PasswordHash, out PasswordSalt);
            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;
            user.LastLogin= DateTime.Now;
            var userCreated = await _repository.Add(user);
            return userCreated;
        }

        public async Task<bool> UserExist(string username)
        {
            var userExist=await _repository.GetAll(x=>x.Username == username);
            if(userExist.Count()!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper functions
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
        private bool VerifayPassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
       

        private JwtSecurityToken getToken(List<Claim> authClims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration.SecretKey));
            var token = new JwtSecurityToken(
                issuer: this._configuration.ValidIssuer,
                audience: this._configuration.ValidAudience,
                expires: DateTime.Now.AddHours(3),
                claims: authClims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );
    
            return token;

        }
       
       

    }
}
