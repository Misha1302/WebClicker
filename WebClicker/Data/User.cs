namespace WebClicker.Data;

public class User
{
    public int Id { get; }
    public int Money { get; private set; }

    public User(int id, int money)
    {
        Id = id;
        Money = money;
    }

    public void AddMoney(int amount) =>
        Money += amount;

    public override string ToString() =>
        $"{Id}::{Money}";
}
