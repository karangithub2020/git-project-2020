using BusinessComponent.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent.Implement
{
    public class SQLLogin : ILogin
    {
        string _connectionString = string.Empty;
        public SQLLogin(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool Login(string userID, string pin)
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var sqlCommand = new SqlCommand($"select count(*) from Login where userID = '{userID}' and Password = '{pin}'", sqlConnection)
            {
                CommandType = System.Data.CommandType.Text
            };

            try
            {
                sqlCommand.Connection.Open();
                var result = sqlCommand.ExecuteScalar();
                return (result != null && (int)result > 0);
            }
            finally
            {
                sqlCommand.Connection.Close();
            }
        }
    }
}
