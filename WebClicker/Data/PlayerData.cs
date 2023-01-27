namespace WebClicker.Data;

public class PlayerData
{
    public int Money { get; set; }
    public int Id { get; set; }

    public PlayerData(int id, int money)
    {
        Id = id;
        Money = money;
    }

    public override string ToString()
    {
        return $"{Id}::{Money}";
    }
}