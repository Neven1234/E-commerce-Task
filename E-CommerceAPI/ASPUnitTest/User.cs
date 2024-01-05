using DomainLayer.Dto;
using E_CommerceAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Implementation;
using ServiceLayer.Interface;

namespace ASPUnitTest
{
    public class User
    {
        private readonly UserController _controller;
        private readonly IUserService _userService;

        public User(UserController controller,IUserService userService )
        {
            this._controller = controller;
            this._userService = userService;
        }
        UserLoginDTO LoginDTO { get; set; }
       
    }
}