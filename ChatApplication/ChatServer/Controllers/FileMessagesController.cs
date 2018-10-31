using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatLib;
using ChatServer.Models;

namespace ChatServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileMessagesController : ControllerBase
    {
        private readonly ChatServerContext _context;

        public FileMessagesController(ChatServerContext context)
        {
            _context = context;
        }

        // GET: api/FileMessages
        [HttpGet]
        public IEnumerable<FileMessage> GetFileMessage()
        {
            return _context.FileMessage;
        }

        // GET: api/FileMessages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fileMessage = await _context.FileMessage.FindAsync(id);

            if (fileMessage == null)
            {
                return NotFound();
            }

            return Ok(fileMessage);
        }

        // PUT: api/FileMessages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileMessage([FromRoute] int id, [FromBody] FileMessage fileMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fileMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(fileMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileMessageExists(id))
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

        // POST: api/FileMessages
        [HttpPost]
        public async Task<IActionResult> PostFileMessage([FromBody] FileMessage fileMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FileMessage.Add(fileMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFileMessage", new { id = fileMessage.Id }, fileMessage);
        }

        // DELETE: api/FileMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fileMessage = await _context.FileMessage.FindAsync(id);
            if (fileMessage == null)
            {
                return NotFound();
            }

            _context.FileMessage.Remove(fileMessage);
            await _context.SaveChangesAsync();

            return Ok(fileMessage);
        }

        private bool FileMessageExists(int id)
        {
            return _context.FileMessage.Any(e => e.Id == id);
        }
    }
}