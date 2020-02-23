using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.DataAccess;
using UserService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private UsersDBContext _dbContext;
        public UsersController(UsersDBContext dBContext) {
            _dbContext = dBContext;
        }
        // GET: api/users/
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            Console.WriteLine("Worked");
            return Ok(await _dbContext.Users.ToListAsync());
        }

        // GET api/users/5
        [HttpGet("{Id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // insert user
                    _dbContext.Users.Add(user);
                    await _dbContext.SaveChangesAsync();

                    // send event

                    // return result
                    return CreatedAtRoute("GetUserById", new { userId = user.Id }, user);
                }
                return BadRequest();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to persist changes. " +
                    "Try again, and if the problem persists " +
                    "please, see your system administrator.");
                return StatusCode(StatusCodes.Status500InternalServerError);
                throw;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
