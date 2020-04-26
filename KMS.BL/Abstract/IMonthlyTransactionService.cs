using KMS.Model;

namespace KMS.BL
{
    public interface IMonthlyTransactionService
    {
        int Save(MonthlyTransactionInsert monthlyTransaction);
    }
}
