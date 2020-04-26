using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace KMS.DB.Abstract
{
    /// <summary>
    /// Abstarct base class with protected and virtual members.
    /// </summary>
    public abstract class BaseRepository
    {
        /// <summary>
        /// This function will be using in INSERT, UPDATE, DELETE  (DML operations)
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected virtual int Execute(SqlCommand command, string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    command.Connection = connection;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Trace.TraceError("Error occured while saving record in Execute() " + ex.Message);
                throw ex;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
            }
        }

        /// <summary>
        /// This function will be using in SELECT
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="command"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected virtual DataTable Execute(string connectionString, SqlCommand command)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    command.Connection = connection;
                    connection.Open();

                    using (DataTable dt = new DataTable())
                    {
                        using (SqlDataAdapter sqlAdopter = new SqlDataAdapter(command))
                        {
                            sqlAdopter.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Error occured while getting record in Execute() " + ex.Message);
                throw ex;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
            }
        }

    }
}
