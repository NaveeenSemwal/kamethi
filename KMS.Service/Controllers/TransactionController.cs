using KMS.BL;
using KMS.Model;
using System.Web.Http;

namespace KMS.Service.Controllers
{
    public class TransactionController : ApiController
    {
        IMonthlyTransactionService transactionService;
        public TransactionController()
        {
            transactionService = new MonthlyTransactionService();
        }

        [HttpPost]
        public int Insert(MonthlyTransactionInsert monthlyTransaction)
        {
            int result = transactionService.Save(monthlyTransaction);
            return result;
        }
    }
}
