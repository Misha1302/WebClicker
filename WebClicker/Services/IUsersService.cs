using WebClicker.Data;

namespace WebClicker.Services;

public interface IUsersService
{
    IReadOnlyList<User> Users { get; }

    User AddUser();
}
