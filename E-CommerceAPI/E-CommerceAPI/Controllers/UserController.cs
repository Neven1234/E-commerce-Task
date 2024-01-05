using DomainLayer.Dto;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;

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
            if(await _Iuser.UserExist(userRegisterDTO.Username))
            {
                return Ok("user already exist");
            }
            var userToCreat = new User
            {
                Username = userRegisterDTO.Username,
                Email = userRegisterDTO.Email
            };
            var result =await _Iuser.Register(userToCreat, userRegisterDTO.Password);
             return Ok("User Created Successfully");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {

           
            var Token=await _Iuser.LoginAsync(userLoginDTO.Username,userLoginDTO.Password);
            if(Token == null)
            {
                return Ok("Username or password is wrong");
            }
            return Ok(new
            { Token = Token }
            );
        }
        
    }
}
