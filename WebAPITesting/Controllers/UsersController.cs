using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;
using WebAPITesting.Models;

namespace WebAPITesting.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UsersController(DatabaseContext context, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUserDto>> LoginUser([FromBody] AppUserLogin loginUser)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password,false,lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(loginUser.Email);
                    return _mapper.Map<AppUserDto>(user);
                }

                
            }
            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUserDto>> RegisterUser([FromBody] AppUserRegister registerUser)
        {
            if(ModelState.IsValid) 
            {
                if (EmailExists(registerUser.Email!))
                {
                    return Content("Email exist");
                }
                var newUser = new AppUser { 
                    Firstname = registerUser.Firstname, 
                    Lastname = registerUser.Lastname,
                    UserName = registerUser.Email, 
                    Email = registerUser.Email 
                };
                var result = await _userManager.CreateAsync(newUser, registerUser.Password);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(registerUser.Email);
                    return _mapper.Map<AppUserDto>(user);
                }

                return BadRequest();
            }
            
            return BadRequest();
        }

        private bool EmailExists(string email)
        {
            return (_context.Users?.Any(user => user.Email == email)).GetValueOrDefault();
        }
    }
}
