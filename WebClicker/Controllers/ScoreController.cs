using Microsoft.AspNetCore.Mvc;
using WebClicker.Services;

namespace WebClicker.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoreController : Controller
{
    private readonly IUserService _userService;

    public ScoreController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("/users/{userId:int}/score")]
    public ActionResult<int> GetUserScore(int userId)
    {
        var user = _userService.Users.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound();

        return Ok(user.Money);
    }

    [HttpPost("/users/{userId:int}/addscore")]
    public ActionResult<int> AddScoreToUser(int userId, int amount)
    {
        var user = _userService.Users.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound();

        user.AddMoney(amount);

        return Ok(amount);
    }
}
