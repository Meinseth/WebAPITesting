using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITesting.Models;

namespace WebAPITesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public MoviesController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{userGuid}")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies(Guid userGuid)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movies = await _context.Movies.Where(movie => movie.User.Guid == userGuid).ToListAsync();

            if (movies == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<MovieDto>>(movies);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> PostMovie(Movie movie)
        {

            if(movie == null || movie.User == null)
            {
                return BadRequest("No movie or user");
            }
            var movieResult = _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return _mapper.Map<MovieDto>(movieResult);
        }
    }
}
