using Microsoft.AspNetCore.Mvc;
using WebClicker.Data;
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
        public IActionResult CreateUser()
        {
            var user = _userService.AddUser();
            return Ok(user);
        }

        [HttpGet("{id:int}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userService.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet()]
        public ActionResult<List<User>> GetUsers()
        {
            var users = _userService.Users;

            if (users == null)
                return NotFound();

            return Ok(users);
        }
    }
}
