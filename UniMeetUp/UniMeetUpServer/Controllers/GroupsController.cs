using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class GroupsController : ControllerBase
    {
        private readonly UniMeetUpServerContext _context;
        private Repository.IUmuRepository _umuRepository;
        public GroupsController(UniMeetUpServerContext context, IUmuRepository umuRepo)
        {
            _umuRepository = umuRepo;
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public IEnumerable<Group> GetGroup()
        {
            return _context.Group;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @group = await _context.Group.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return Ok(@group);
        }

        [HttpGet("{email}/all")]
        public async Task<IActionResult> GetGroups([FromRoute] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groups = _umuRepository.GetGroupsForUser(email);

            return Ok(groups);

        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup([FromRoute] int id, [FromBody] Group @group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @group.GroupId)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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
        
        // POST: api/Groups/createGroup
        [HttpPost("createGroup")]
        public async Task<IActionResult> PostGroup([FromBody] CreateGroupDTO @group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = Mapper.Map<Group>(group);
            _context.Group.Add(result);
            await _context.SaveChangesAsync();
            UserGroup ug = new UserGroup();
            ug.EmailAddress = group.EmailAddress;
            ug.GroupId = result.GroupId;
            _context.UserGroup.Add(ug);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGroup", result.GroupId, result);
        }

        [HttpPost("createUserGroup")]
        public async Task<IActionResult> PostUserGroup([FromBody] UserGroupForCreation @userGroup)
        {

            UserGroup ug = new UserGroup();
            ug.EmailAddress = userGroup.EmailAddress;
            ug.GroupId = userGroup.GroupId;
            _umuRepository.AddUserGroup(ug);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return Created("GetGroup", userGroup.GroupId);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @group = await _context.Group.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            _context.Group.Remove(@group);
            await _context.SaveChangesAsync();

            return Ok(@group);
        }

        private bool GroupExists(int id)
        {
            return _context.Group.Any(e => e.GroupId == id);
        }
    }
}