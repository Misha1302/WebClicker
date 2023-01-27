using Microsoft.AspNetCore.Mvc;
using WebClicker.Data;

namespace WebClicker.Controllers;

[ApiController]
[Route("[controller]")]
public class ClickerController
{
    private const int StartMoney = 0;
    private static readonly List<PlayerData> _playersData = new();

    [HttpGet("/users{id:int}/score")]
    public int GetMoney(int id)
    {
        var playerData = _playersData.Find(x => x.Id == id);
        return playerData?.Money ?? int.MinValue;
    }

    [HttpGet("newUser")]
    public bool RegisterNewUser(int id)
    {
        var playerData = _playersData.Find(x => x.Id == id);
        if (playerData != null) return false;

        _playersData.Add(new PlayerData(id, StartMoney));
        return true;
    }

    [HttpGet("/users{id:int}/addScore")]
    public bool AddMoney(int id)
    {
        var playerData = _playersData.Find(x => x.Id == id);
        if (playerData == null) return false;

        playerData.Money++;
        return true;
    }
}