using app_backend;

public static class TransactionDatabase
{
    public static List<Transaction> Transactions { get; } = new List<Transaction>();
    public static List<Account> Accounts { get; } = new List<Account>();
}