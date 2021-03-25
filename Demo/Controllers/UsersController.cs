using Domain.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Auth;
using Microsoft.AspNetCore.Authorization;
using Service.Users;
using System;

namespace Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase

    {
        private IUsersService _userService;
        private IAuthService _authService;
        public UsersController(IUsersService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }



        [HttpPost]
        [Route("[action]")]
        public IActionResult SignUp([FromBody] LoginDTO model)
        {
            return Ok(_authService.SignUp(model));
        }

        [HttpPost]
        [Route("[action]")]
        [EnableCors("LoginCors")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            var result = _authService.LogIn(model);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            var result = _userService.FindById(id);
            return Ok(result);
        }
    }
}
