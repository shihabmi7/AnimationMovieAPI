using AnimationMovieAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimationMovieAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AspNetUsersContext _dbContext;
       
        public UserController(AspNetUsersContext context)
        {
            _dbContext = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUser>>> GetAllUsers()
        {
            if (_dbContext.AspNetUsers == null)
            {
                return NotFound();
            }
            return await _dbContext.AspNetUsers.DefaultIfEmpty().ToListAsync();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<AspNetUser>> GetUser(String id)
        {
            if (_dbContext.AspNetUsers == null)
            {
                return NotFound();
            }

            var aUser = await _dbContext.AspNetUsers.FindAsync(id);
            if(aUser == null)
            {
                return NotFound();
            }
            return aUser;
        }

        
        [HttpPost]
        public async Task<ActionResult<AspNetUser>> PostUser(AspNetUser aUser)
        {

            _dbContext.AspNetUsers.Add(aUser);
            await _dbContext.SaveChangesAsync();

            // both method name and parms of nameof(*) must be Get!
            // else you got the error!
            return CreatedAtAction(nameof(PostUser), new { id = aUser.Id }, aUser);
        }

        [HttpDelete]
        public async Task<ActionResult<AspNetUser>> DeleteUser(String id)
        {

            if (_dbContext.AspNetUsers == null) { 
            
                return NotFound();
            }

            var aUser = await _dbContext.AspNetUsers.FindAsync(id);

            if (aUser == null) { 
            return NotFound();

            }
            _dbContext.AspNetUsers.Remove(aUser);
            await _dbContext.SaveChangesAsync();

            return NoContent();

         
        }

      
        [HttpPut("{id}")]
        public async Task<ActionResult<AspNetUser>> PutMovie(String id, AspNetUser aUser)
        {

            if (id != aUser.Id)
            {

                return BadRequest();
            }


            _dbContext.Entry(aUser).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }


        private bool MovieExists(String id)
        {

            return (_dbContext.AspNetUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
