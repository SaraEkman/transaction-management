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
            var newTransaction = transaction.ProcessTransaction();
            return StatusCode(201, newTransaction);
        }
    }
}
