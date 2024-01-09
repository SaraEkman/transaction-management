using Microsoft.AspNetCore.Mvc;

namespace app_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : Controller
    {

        [HttpGet]
        public List<Transaction> Get()
        {
            return TransactionDatabase.Transactions;
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> Get(string id)
        {
            var transaction = TransactionDatabase.Transactions.FirstOrDefault(t => t.Transaction_id == Guid.Parse(id));

            if (transaction == null)
            {
                return NotFound();
            }
            return transaction;
        }

        [HttpPost]

        public IActionResult Post([FromBody] TransactionRequest transaction)
        {
            int balance = 0;
            if (TransactionDatabase.Accounts.Where(a => a.Account_id == transaction.Account_id).Count() == 0)
            {
                TransactionDatabase.Accounts.Add(new Account
                {
                    Account_id = transaction.Account_id,
                    Balance = transaction.Amount
                });
                balance = transaction.Amount;
            }
            else
            {
                balance = TransactionDatabase.Accounts.Where(a => a.Account_id == transaction.Account_id).First().Balance + transaction.Amount;
                TransactionDatabase.Accounts.Where(a => a.Account_id == transaction.Account_id).First().Balance += transaction.Amount;
            }
            var newTran = new Transaction
            {
                Transaction_id = Guid.NewGuid(),
                Account_id = transaction.Account_id,
                Amount = transaction.Amount,
                Created_at = DateTime.UtcNow,
                Current_account_balance = balance
            };

            TransactionDatabase.Transactions.Add(newTran);

            return StatusCode(201, newTran);
        }
    }
}
