using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IFriendWebservice.Models;

namespace IFriendWebservice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        //private readonly FriendDatabaseContext _context;

        private FriendDatabaseContext _context = new FriendDatabaseContext();

        //public FriendsController(FriendDatabaseContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Friends
        [HttpGet]
        public IEnumerable<Friends> GetFriends()
        {
            return _context.Friends;
        }

        // GET: api/Friends/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFriends([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var friends = await _context.Friends.FindAsync(id);

            if (friends == null)
            {
                return NotFound();
            }

            return Ok(friends);
        }

        // PUT: api/Friends/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriends([FromRoute] int id, [FromBody] Friends friends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friends.FriendsId)
            {
                return BadRequest();
            }

            _context.Entry(friends).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendsExists(id))
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

        // POST: api/Friends
        [HttpPost]
        public async Task<IActionResult> PostFriends([FromBody] Friends friends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Friends.Add(friends);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriends", new { id = friends.FriendsId }, friends);
        }

        // DELETE: api/Friends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFriends([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var friends = await _context.Friends.FindAsync(id);
            if (friends == null)
            {
                return NotFound();
            }

            _context.Friends.Remove(friends);
            await _context.SaveChangesAsync();

            return Ok(friends);
        }

        private bool FriendsExists(int id)
        {
            return _context.Friends.Any(e => e.FriendsId == id);
        }
    }
}