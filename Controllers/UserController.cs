using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Models.DTOs;
using MovieApi.MovieService;
using MovieApi.UsersService;

namespace MovieApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersInterface usersInterface) : ControllerBase
    {
        private readonly IUsersInterface _usersInterface = usersInterface;

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<UserDto>>> CreateUser(UserCreateDto newUser)
        {
            return Ok(await _usersInterface.CreateUser(newUser));
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserCreateDto login)
        {
            return Ok(await _usersInterface.Login(login));
        }
    }
}