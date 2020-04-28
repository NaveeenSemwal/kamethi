using KMS.DB;
using KMS.DB.Abstract;
using KMS.Model;

namespace KMS.BL
{
    public class MonthlyTransactionService  : IMonthlyTransactionService
    {
        IMonthlyTransactionRepository monthlyTransactionService;
        public MonthlyTransactionService() 
        {
            monthlyTransactionService = new MonthlyTransactionRepository();
        }

        public int Save(MonthlyTransactionInsert monthlyTransaction)
        {
           int result= monthlyTransactionService.Save(monthlyTransaction);
            return result;
        }
    }
}
