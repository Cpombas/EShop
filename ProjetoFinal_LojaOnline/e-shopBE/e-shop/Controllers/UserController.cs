using e_shop.DbContexts;
using e_shop.Entities;
using e_shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using static e_shop.Models.ListUserDTO;

namespace e_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EShopContext _context;
        
        public UserController(EShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ListUserDTO>> GetUsers()
        {
            var users = await _context.User.Include("Role").
                Select(u => new ListUserDTO(u)).ToListAsync();

            return users;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserByID (int id)
        {
            var user = await _context.User.Include("Role").
                FirstOrDefaultAsync(u => u.UserId == id);

            return user == null ? NotFound() : Ok(new ListUserDTO(user));
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await _context.User. //Include("Role").
                FirstOrDefaultAsync(u => u.UserName == name);

            return user == null ? NotFound() : Ok(new ListUserDTO(user));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newUser = new User
            {
                UserName = user.UserName,
                Password = user.Password,
                RoleId = user.RoleId
            };

            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserByID), new { id = newUser.UserId }, user);
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO user)
        {
            if (id != user.UserId) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var userDB = _context.User.Find(id);

            userDB.UserName = user.UserName;
            userDB.RoleId = user.RoleId;

            _context.Entry(userDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
