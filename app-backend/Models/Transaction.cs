using System.ComponentModel.DataAnnotations;

namespace app_backend
{
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



        public Transaction(int balance, Guid account_id, int amount)
        {
            Transaction_id = Guid.NewGuid();
            Account_id = account_id;
            Amount = amount;
            Created_at = DateTime.UtcNow;
            Current_account_balance = balance;
        }
    }

}