using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommonLib.Models;
using UniMeetUpServer.DTO;
using UniMeetUpServer.Models;
using UniMeetUpServer.Repository;

namespace UniMeetUpServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UniMeetUpServerContext _context;
        private IUmuRepository _umuRepository;
        public UsersController(UniMeetUpServerContext context, IUmuRepository umuRepo)
        {
            _umuRepository = umuRepo;
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return _context.User;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] string id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.EmailAddress)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost("create")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.EmailAddress }, user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> RequestLogin([FromBody] UserForLoginDTO userForLogin)
        {
            if (userForLogin == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _umuRepository.GetUserById(userForLogin.Email);

            if (user == null)
            {
                return BadRequest();
            }

            if (user.HashedPassword == userForLogin.Password)
            {
                return Ok();
            }

            return BadRequest();

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        //NOT WORKING AS INTENDED. 500. SERVER ERROR
        // POST: api/Users/CreateAccount
        [HttpPost("CreateAccount")]
        public async Task<IActionResult> PostUserForCreateAccount([FromBody] UserToPostDTO user)
        {
            _umuRepository.PostUserWithEmailNameAndPassword(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.Email }, user);
        }

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.EmailAddress == id);
        }
    }
}