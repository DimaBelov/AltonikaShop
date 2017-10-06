using System;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AltonikaShop.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Auth([FromBody] User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Json(_userService.Auth(user));
        }
    }
}
