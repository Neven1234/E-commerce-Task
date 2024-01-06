using Azure;
using DomainLayer.Dto;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;
using System.Security.Cryptography;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _Iuser;

        public UserController(IUserService user)
        {
            this._Iuser = user;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            if (await _Iuser.UserExist(userRegisterDTO.Username))
            {
                return Ok("user already exist");
            }
            var userToCreat = new User
            {
                Username = userRegisterDTO.Username,
                Email = userRegisterDTO.Email
            };
            var result = await _Iuser.Register(userToCreat, userRegisterDTO.Password);
            return Ok("User Created Successfully");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {


            var Token = await _Iuser.LoginAsync(userLoginDTO.Username, userLoginDTO.Password);
            if (Token == null)
            {
                return Ok("Username or password is wrong");
            }
            var refreshToken = GenerateRefreshToken();
            setRefreshToken(refreshToken);
            return Ok(Token);
        }
        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7)

            };
            return refreshToken;
        }
        private void setRefreshToken(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires,
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

    }
}
