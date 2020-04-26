
using KMS.DB;
using KMS.DB.Abstract;
using KMS.Model;
using KMS.Utitlities;
using System;
using System.Collections.Generic;
using System.Data;

namespace KMS.BL
{
    /// <summary>
    ///  TODO : We can think on this to use AutoMapper with Datatable instead of manually mapping values.
    ///  https://stackoverflow.com/questions/18376313/setting-up-a-common-nuget-packages-folder-for-all-solutions-when-some-projects-a
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public List<string> PopulateUsersName(string userName)
        {
            DataTable dataTable = userRepository.GetUsersName(userName);
            return PopulateUserNamesDto(dataTable);
        }

        private static List<string> PopulateUserNamesDto(DataTable dataTable)
        {
            List<string> names = new List<string>();

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string name = dataTable.Rows[i]["UserName"].ToString();
                    names.Add(name);
                }
            }
            return names;
        }

        public List<UserVM> PopulateUsers()
        {
            DataTable result = userRepository.GetUsers();
            return PopulateUserListDto(result);
        }

        private static List<UserVM> PopulateUserListDto(DataTable result)
        {
            List<UserVM> users = new List<UserVM>();

            if (result != null && result.Rows.Count > 0)
            {
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    UserVM user = new UserVM();
                    user.UserId = Convert.ToInt32(result.Rows[i]["UserId"]);
                    user.UserName = Convert.ToString(result.Rows[i]["UserName"]);
                    user.Email = Convert.ToString(result.Rows[i]["Email"]);
                    user.PrimaryPhone = Convert.ToString(result.Rows[i]["PrimaryPhone"]);
                    user.AadhaarUrl = Convert.ToString(result.Rows[i]["UploadAadhaar"]);
                    user.IsActive = Convert.ToBoolean(result.Rows[i]["IsActive"] == DBNull.Value ? "false" : "true");
                    user.TakenCredit = Convert.ToInt32(result.Rows[i]["Balance Amount"] == DBNull.Value ? 0 : Convert.ToInt32(result.Rows[i]["Balance Amount"]));
                    users.Add(user);
                }
            }
            return users;
        }

        //public UserVM Login(string email, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
