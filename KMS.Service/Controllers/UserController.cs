using KMS.BL;
using KMS.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace KMS.Service.Controllers
{
    /// <summary>
    /// https://www.c-sharpcorner.com/article/dependency-injection-using-unity-resolve-dependency-of-dependencies/
    /// https://www.tutlane.com/tutorial/aspnet-mvc/asp-net-mvc-bundling-and-minification
    /// 
    /// </summary>
    public class UserController : ApiController
    {
        IUserService userService;
        public UserController()
        {
            userService = new UserService();
        }

        /// <summary>
        /// https://localhost:44307/kms/User/GetAll
        /// </summary>
        /// <returns></returns>
        public List<string> GetNames(string name)
        {
            List<string> users = userService.PopulateUsersName(name);
            return users;
        }


        public List<UserVM> GetAll()
        {
            List<UserVM> users = userService.PopulateUsers();
            return users;
        }
        //public UserVM Login(string email,string password)
        //{
        //    return new UserVM();
        //}

    }
}
