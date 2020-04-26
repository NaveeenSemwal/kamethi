using KMS.Model;
using System;
using System.Configuration;

namespace KMS.Utitlities
{
    public sealed class ConfigurationHelper
    {
        public static string GetConnectionString(string connectionstring)
        {
            string connection = ConfigurationManager.ConnectionStrings[connectionstring].ToString();
            if (connection == null || (connection != null && connection.Length == 0))
                throw (new ApplicationException(connectionstring + " key is missing from your web.config"));
            return connection;
        }

        public static string ConnectionString
        {
            get { return GetConnectionString(ConfigKeys.ConnectionString); }
        }
    }
}
