using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.DB.Abstract
{
    public interface IUserRepository
    {
        DataTable GetUsersName(string userName);

        DataTable GetUsers();
    }
}
