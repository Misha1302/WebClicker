using WebClicker.Data;

namespace WebClicker.Dto;

public struct UserDto
{
    public int Id { get; set; }
    public int Money { get; set; }

    public UserDto(User user)
    {
        Id = user.Id;
        Money = user.Money;
    }
}
