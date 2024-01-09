using Microsoft.AspNetCore.Mvc;

namespace app_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        [HttpGet("{id}")]
        public Account Get(string id)
        {
            return TransactionDatabase.Accounts.Single(a => a.Account_id == Guid.Parse(id));
        }
    }
}
