using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPITesting.Models;

namespace WebAPITesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UsersController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginUser([FromBody] UserLogin loginUser)
        {
            if (_context.Users == null)
                return NotFound();

            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == loginUser.Email && user.Password == loginUser.Password);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User registerUser)
        {
            if (_context.Users == null)
                return NotFound();

            if (EmailExists(registerUser.Email))
            {
                return Content("Email exist");
            }

            _context.Users.Add(registerUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(RegisterUser), new { id = registerUser.Id }, registerUser);

        }

        private bool UserExists(long id)
        {
            return (_context.Users?.Any(user => user.Id == id)).GetValueOrDefault();
        }

        private bool EmailExists(string email)
        {
            return (_context.Users?.Any(user => user.Email == email)).GetValueOrDefault();
        }
    }
}
