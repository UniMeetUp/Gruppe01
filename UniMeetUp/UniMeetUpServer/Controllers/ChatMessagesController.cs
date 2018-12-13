using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ChatMessagesController : ControllerBase
    {
        private readonly UniMeetUpServerContext _context;
        private IUmuRepository _umuRepository;

        public ChatMessagesController(UniMeetUpServerContext context, IUmuRepository repo)
        {
            _context = context;
            _umuRepository = repo;
        }

        // GET: api/ChatMessages
        [HttpGet]
        public IEnumerable<ChatMessage> GetChatMessage()
        {
            return _context.ChatMessage;
        }

        // GET: api/ChatMessages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatMessage = await _context.ChatMessage.FindAsync(id);

            if (chatMessage == null)
            {
                return NotFound();
            }

            return Ok(chatMessage);
        }

        // PUT: api/ChatMessages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatMessage([FromRoute] int id, [FromBody] ChatMessage chatMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatMessage.ChatMessageId)
            {
                return BadRequest();
            }

            _context.Entry(chatMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatMessageExists(id))
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

        // POST: api/ChatMessages
        [HttpPost]
        public async Task<IActionResult> PostChatMessage([FromBody] ChatMessage chatMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ChatMessage.Add(chatMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatMessage", new { id = chatMessage.ChatMessageId }, chatMessage);
        }

        // DELETE: api/ChatMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatMessage = await _context.ChatMessage.FindAsync(id);
            if (chatMessage == null)
            {
                return NotFound();
            }

            _context.ChatMessage.Remove(chatMessage);
            await _context.SaveChangesAsync();

            return Ok(chatMessage);
        }

        private bool ChatMessageExists(int id)
        {
            return _context.ChatMessage.Any(e => e.ChatMessageId == id);
        }

        // GET: api/ChatMessages/Group/8
        [HttpGet("Group/{id}")]
        public IEnumerable<MessageForLoadDTO> GetChatMessages([FromRoute] int id)
        {
            return _umuRepository.GetMessagesByGroupId(id);
        }
    }
}