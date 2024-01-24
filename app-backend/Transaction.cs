using System.ComponentModel.DataAnnotations;

namespace app_backend
{
    public class TransactionRequest
    {
        public Guid Account_id { get; set; }
        public int Amount { get; set; }

        public Transaction ProcessTransaction()
        {
            int balance = UpdateBalance();
            return CreateTransaction(balance);
        }

        private int UpdateBalance()
        {
            var account = TransactionDatabase.Accounts.FirstOrDefault(a => a.Account_id == this.Account_id);

            if (account == null)
            {
                account = new Account
                {
                    Account_id = this.Account_id,
                    Balance = this.Amount
                };
                TransactionDatabase.Accounts.Add(account);
            }
            else
            {
                account.Balance += this.Amount;
            }

            return account.Balance;
        }

        private Transaction CreateTransaction(int balance)
        {
            var newTransaction = new Transaction
            {
                Transaction_id = Guid.NewGuid(),
                Account_id = this.Account_id,
                Amount = this.Amount,
                Created_at = DateTime.UtcNow,
                Current_account_balance = balance
            };

            TransactionDatabase.Transactions.Add(newTransaction);
            return newTransaction;
        }

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