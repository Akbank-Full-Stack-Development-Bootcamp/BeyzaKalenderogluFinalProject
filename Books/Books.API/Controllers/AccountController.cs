using Books.API.Models;
using Books.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Books.Models;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService userService;
        private IConfiguration configuration;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = userService.GetAllUsers();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            // userLoginModel -- data object that came from user interface
            var user = userService.GetUser(userLoginModel.Username, userLoginModel.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Wrong username or password." });
            }
            // TODO 1: In here, JWT will be generated and assigned to user.

            string issuer = configuration.GetSection("Bearer")["Issuer"];
            string audience = configuration.GetSection("Bearer")["Audience"];
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole)
            };

            //var key = "Bana bi kahve acilinden.";
            var key = configuration.GetSection("Bearer")["SecurityKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer : issuer,
                audience : audience,
                claims : claims,
                notBefore : DateTime.Now,
                expires : DateTime.Now.AddMinutes(60),
                signingCredentials : credential
                );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token)});
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var result = userService.GetAllUsers();
        //    return Ok(result);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var authorListResponse = userService.GetUserById(id);
        //    if (authorListResponse != null)
        //    {
        //        return Ok(authorListResponse);
        //    }

        //    return NotFound();
        //}

        //[HttpPost]
        //// gets dto as an input
        //public IActionResult AddUser(User request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //sends the request to db by using service
        //        int userId = userService.AddUser(request);
        //        //goes to GetById method - creates link in header 
        //        return CreatedAtAction(nameof(GetById), routeValues: new { id = userId }, value: null);

        //    }

        //    return BadRequest(ModelState);
        //}
    }
}
