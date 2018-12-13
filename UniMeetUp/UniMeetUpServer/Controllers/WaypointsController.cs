using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommonLib.Models;
using UniMeetUpServer.Models;
using UniMeetUpServer.Repository;

namespace UniMeetUpServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaypointsController : ControllerBase
    {
        private readonly UniMeetUpServerContext _context;
        private IUmuRepository _umuRepository;

        public WaypointsController(UniMeetUpServerContext context, IUmuRepository repository)
        {
            _context = context;
            _umuRepository = repository;
        }

        // GET: api/Waypoints
        [HttpGet]
        public IEnumerable<Waypoint> GetWaypoint()
        {
            return _context.Waypoint;
        }

        // GET: api/Waypoints/5
        [HttpGet("{id}")]
        public IActionResult GetWaypoint([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var waypoint = _umuRepository.GetWaypointById(id);

            if (waypoint == null)
            {
                return NotFound();
            }

            return Ok(waypoint);
        }

        // PUT: api/Waypoints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaypoint([FromRoute] int id, [FromBody] Waypoint waypoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != waypoint.WaypointId)
            {
                return BadRequest();
            }

            _context.Entry(waypoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaypointExists(id))
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

        // POST: api/Waypoints/update
        [HttpPost("{groupId}/update")]
        public async Task<IActionResult> UpdateLocation([FromRoute] string groupId, [FromBody] Waypoint location)
        {
            if (location == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            _umuRepository.UpdateWayPointForGroup(location);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Waypoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaypoint([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var waypoint = await _context.Waypoint.FindAsync(id);
            if (waypoint == null)
            {
                return NotFound();
            }

            _context.Waypoint.Remove(waypoint);
            await _context.SaveChangesAsync();
            return Ok(waypoint);
        }

        private bool WaypointExists(int id)
        {
            return _context.Waypoint.Any(e => e.WaypointId == id);
        }
    }
}