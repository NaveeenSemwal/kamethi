using KMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.BL
{
   public interface IUserService
    {
        List<string> PopulateUsersName(string userName);

        List<UserVM> PopulateUsers();
        //UserVM Login(string email,string password);
    }
}
