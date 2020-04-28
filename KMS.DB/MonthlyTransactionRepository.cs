using KMS.BL.Utility;
using KMS.DB.Abstract;
using KMS.Model;
using KMS.Utitlities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.DB
{
    public class MonthlyTransactionRepository :   BaseRepository, IMonthlyTransactionRepository
    {
        public int Save(MonthlyTransactionInsert monthlyTransaction)
        {
            DataTable inputTable = ListtoDataTableConverter.ToDataTable(monthlyTransaction.MonthlyTransactions);


            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertMonthlyTransaction";

                cmd.Parameters.AddWithValue("@MonthlyTransaction", inputTable);

                cmd.Parameters.AddWithValue("@KamethiNumber", monthlyTransaction.KamethiNumber);

                cmd.Parameters.AddWithValue("@HostId", monthlyTransaction.HostId);

                cmd.Parameters.AddWithValue("@TotalTakenAmount", monthlyTransaction.TotalTakenAmount);

                cmd.Parameters.AddWithValue("@TotalDepositAmount", monthlyTransaction.TotalDepositeAmount);

                cmd.Parameters.AddWithValue("@RemainingBalance", monthlyTransaction.TotalBalanceAmount);

                return Execute(cmd,ConfigurationHelper.ConnectionString);


            }
        }
    }
}
