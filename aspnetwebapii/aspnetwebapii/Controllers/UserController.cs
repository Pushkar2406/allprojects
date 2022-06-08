using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetwebapii.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetwebapii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext context;




        public UserController(UserDbContext db)
        {
            context = db;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await context.users.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            context.users.Add(user);
            await context.SaveChangesAsync();
            return Ok(await context.users.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var usr = await context.users.FindAsync(id);
            if (usr == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(usr);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(User request)
        {
            var dbUsr = await context.users.FindAsync(request.UserId);
            if (dbUsr == null)
            {
                return BadRequest("User Not Found");
            }
            dbUsr.UserName = request.UserName;
            dbUsr.Useremail = request.Useremail;
            await context.SaveChangesAsync();
            return Ok(await context.users.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dbUsr = await context.users.FindAsync(id);
            if (dbUsr == null)
            {
                return BadRequest("User Not Found");
            }
            context.users.Remove(dbUsr);
            await context.SaveChangesAsync();
            return Ok(await context.users.ToListAsync());
        }
    }



}
    
