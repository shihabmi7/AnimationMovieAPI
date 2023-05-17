﻿using AnimationMovieAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimationMovieAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _dbContext;

        public MoviesController(MovieContext _dbContext) { 
        
            this._dbContext = _dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {

            if (_dbContext.Movies == null)
            {
                return NotFound();
            }
            return await _dbContext.Movies.ToListAsync();
        }


        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id) {

            if ((_dbContext.Movies == null)) {
                return NotFound();
                }

            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null) {
                return NotFound();
                    }

            return movie;        
        }
        
      
        // Post: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie) {

             _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id}, movie);        
        }        
        
        
        // Put: api/Movies/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> PutMovie(int id, Movie movie) {

            if (id != movie.Id) {

                return BadRequest();
            }
            _dbContext.Entry(movie).State = EntityState.Modified;

            try {
               await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {

                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            } 
            return NoContent();        
        }


        private bool MovieExists(int id) {

            return (_dbContext.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // Delete: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {

            if (_dbContext.Movies == null) {

                return NotFound();
            }

            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
