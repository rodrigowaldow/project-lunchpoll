using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LunchPoll.Models;

namespace LunchPoll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LunchLocalController : ControllerBase
    {
        private readonly LunchLocalContext _context;

        public LunchLocalController(LunchLocalContext context)
        {
            _context = context;
        }

        // GET: api/LunchLocal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LunchLocal>>> GetLunchLocals()
        {
            return await _context.LunchLocals.ToListAsync();
        }

        // GET: api/LunchLocal/TotalVotes
        [HttpGet]
        [Route("TotalVotes")]
        public int GetTotalVoteCount()
        {
            return _context.LunchLocals.Sum(e => e.VoteCount);
        }

        // PUT: api/LunchLocal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLunchLocal(int id, LunchLocal lunchLocal)
        {
            if (id != lunchLocal.LocalId)
            {
                return BadRequest();
            }

            _context.Entry(lunchLocal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LunchLocalExists(id))
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

        // POST: api/LunchLocal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LunchLocal>> PostLunchLocal(LunchLocal lunchLocal)
        {
            _context.LunchLocals.Add(lunchLocal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLunchLocal", new { id = lunchLocal.LocalId }, lunchLocal);
        }

        // DELETE: api/LunchLocal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLunchLocal(int id)
        {
            var lunchLocal = await _context.LunchLocals.FindAsync(id);
            if (lunchLocal == null)
            {
                return NotFound();
            }

            _context.LunchLocals.Remove(lunchLocal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LunchLocalExists(int id)
        {
            return _context.LunchLocals.Any(e => e.LocalId == id);
        }
    }
}
