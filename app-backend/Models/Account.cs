public class Account
{
    public Guid Account_id { get; set; }
    public int Balance { get; set; }

    public int UpdateBalance(int amount)
    {
        return this.Balance += amount;
    }
}