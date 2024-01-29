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
            var account = TransactionDatabase.Accounts.FirstOrDefault(a => a.Account_id == transaction.Account_id);

            if (account == null)
            {
                account = new Account
                {
                    Account_id = transaction.Account_id,
                    Balance = transaction.Amount
                };
                TransactionDatabase.Accounts.Add(account);
            }
            else
            {
                account.UpdateBalance(transaction.Amount);
            }
            var newTransaction = new Transaction(account.Balance, account.Account_id, transaction.Amount);
            TransactionDatabase.Transactions.Add(newTransaction);
            return StatusCode(201, newTransaction);
        }
    }
}
