using Microsoft.AspNetCore.Mvc;
using WebClicker.Data;
using WebClicker.Dto;
using WebClicker.Services;

namespace WebClicker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpPost("createuser")]
        public ActionResult<UserDto> CreateUser()
        {
            var user = _userService.AddUser();
            return Ok(new UserDto(user));
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserDto> GetUser(int id)
        {
            var user = _userService.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            return Ok(new UserDto(user));
        }

        [HttpGet()]
        public ActionResult<List<UserDto>> GetUsers()
        {
            var users = _userService.Users;

            if (users == null)
                return NotFound();

            var usersDto = new List<UserDto>();

            foreach (var user in users)
                usersDto.Add(new UserDto(user));


            return Ok(usersDto);
        }
    }
}
