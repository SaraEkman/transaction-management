using System.ComponentModel.DataAnnotations;

namespace app_backend
{
    public class TransactionRequest
    {
        public Guid Account_id { get; set; }
        public int Amount { get; set; }

    }

    public class Transaction
    {
        [Required]
        public Guid Transaction_id { get; set; }
        [Required]
        public Guid Account_id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime Created_at { get; set; }
        public int Current_account_balance { get; set; }

    }

    public class Account
    {
        public Guid Account_id { get; set; }
        public int Balance { get; set; }
    }

    public static class TransactionDatabase
    {
        public static List<Transaction> Transactions { get; } = new List<Transaction>();
        public static List<Account> Accounts { get; } = new List<Account>();
    }
}