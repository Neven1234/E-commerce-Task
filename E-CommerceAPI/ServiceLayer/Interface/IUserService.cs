using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IUserService
    {
        Task<User> Register(User user, string password);
        Task<string> LoginAsync(string username, string password);
        Task<bool> UserExist(string username);
    }
}
