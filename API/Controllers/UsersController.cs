
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

//[ApiController]
//[Route("api/[controller]")] // api/users - name of the controller without 'Controller' in name
public class UsersController(DataContext context) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){

        var users = await context.Users.ToListAsync();

        return users;
    }

    [Authorize]
    [HttpGet("{id:int}")] //  /api/users/3
    public async Task<ActionResult<AppUser>> GetUser(int id){

        var user = await context.Users.FindAsync(id); // might be null if not found!!!

        if (user == null){
            return NotFound();
        }

        return user;
    }
}
