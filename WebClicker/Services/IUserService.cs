using WebClicker.Data;

namespace WebClicker.Services;

public interface IUserService
{
    IReadOnlyList<User> Users { get; }

    User AddUser();
}
