using KMS.DB.Abstract;
using KMS.Utitlities;
using System.Data;
using System.Data.SqlClient;

namespace KMS.DB
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public DataTable GetUsersName(string userName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Usp_getname";
                cmd.Parameters.AddWithValue("@UserName", userName);

                return Execute(ConfigurationHelper.ConnectionString, cmd);
            }
        }

        public DataTable GetUsers()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Proc_GetUser";
                return Execute(ConfigurationHelper.ConnectionString, cmd);
            }
        }
    }
}
