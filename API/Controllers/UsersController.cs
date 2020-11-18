using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entity;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController: ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context) {
            _context = context;
        }
        [HttpGet]
        public Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var users =  await _context.Users.ToListAsync(); 
            return users;
        }

//api/Users/3
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUsers(int id){
            
            return  _context.Users.Find(id); 
        }
    }
}