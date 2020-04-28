using KMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.DB.Abstract
{
   public interface IMonthlyTransactionRepository
    {

        int Save(MonthlyTransactionInsert monthlyTransaction);
    }
}
