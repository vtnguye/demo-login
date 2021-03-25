using AutoMapper;
using Domain.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Service.Users;

namespace Demo.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class UsersController : ControllerBase

    {
        private IJwtManager _jwt;
        private IUsersService _userService;
        private IMapper _mapper;
        public UsersController(IUsersService userService, IMapper mapper, IJwtManager jwt)
        {
            _userService = userService;
            _mapper = mapper;
            _jwt = jwt;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll());
        }

        [HttpPost]
        [Route ("[action]")]
        public IActionResult SignUp([FromBody] LoginDTO model)
        {
            return Ok(_userService.SignUp(model));
        }

        [HttpPost]
        [Route("[action]")]
        [EnableCors("LoginCors")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            var result = _userService.LogIn(model);
            if (result)
            {
                var response = _mapper.Map<UserDTO>(model);
                var token = _jwt.GenerateJSONWebToken(response);
                response.Token = token;

                return Ok(response);

            }
            return Ok("Login Failed");
        }
    }
}
