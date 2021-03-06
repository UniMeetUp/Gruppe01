﻿using System.Collections.Generic;
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
    public class FileMessagesController : ControllerBase
    {
        private readonly UniMeetUpServerContext _context;
        private IUmuRepository _umuRepository;

        public FileMessagesController(UniMeetUpServerContext context, IUmuRepository umu)
        {
            _context = context;
            _umuRepository = umu;
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

            if (id != fileMessage.FileMessageId)
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

            return CreatedAtAction("GetFileMessage", new { id = fileMessage.FileMessageId }, fileMessage);
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

        // GET: api/FileMessages/Group/id
        [HttpGet("Group/{id}")]
        public IEnumerable<FileMessageForFileFolderDTO> GetGroupFileMessage([FromRoute] int id)
        {
            return _umuRepository.GetGroupFileMessagesNameAndId(id);
        }

        // GET: api/FileMessages/Download/id
        [HttpGet("Download/{id}")]
        public async Task<IActionResult> GetFileToDownloadById([FromRoute] int id)
        {
            return Ok(_umuRepository.GetFileToDownloadById(id));
        }

        private bool FileMessageExists(int id)
        {
            return _context.FileMessage.Any(e => e.FileMessageId == id);
        }
    }
}