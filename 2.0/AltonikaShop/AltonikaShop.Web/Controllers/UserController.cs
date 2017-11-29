using System;
using AltonikaShop.Data.Repositories.Interfaces;
using AltonikaShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AltonikaShop.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Auth([FromBody] User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Json(_userRepository.Auth(user));
        }
    }
}
