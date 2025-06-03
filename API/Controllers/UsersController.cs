
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

//[ApiController]
//[Route("api/[controller]")] // api/users - name of the controller without 'Controller' in name
[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController
{
    //[AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {

        var users = await userRepository.GetMembersAsync();

        return Ok(users);
    }

    //[Authorize]
    [HttpGet("{username}")] 
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {

        var user = await userRepository.GetMemberAsync(username);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }
}
