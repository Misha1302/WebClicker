using WebClicker.Data;

namespace WebClicker.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new List<User>();
    public IReadOnlyList<User> Users => _users;

    public User AddUser()
    {
        int maxId = 0;

        if (_users.Count > 0)
            maxId = _users.Max(u => u.Id);

        User user = new User(maxId + 1, 0);

        _users.Add(user);

        return user;
    }
}
