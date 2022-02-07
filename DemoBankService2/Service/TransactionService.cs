using DemoBankService2.Entity;
using DemoBankService2.Helper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankService2.Service
{
    public class TransactionService
    {
        private ConnectionHelper _connectionHelper = new ConnectionHelper();
        private Random _random = new Random();
        public int CreateRandomNumbers()
        {
            return int.Parse(_random.Next(10, 99).ToString() + _random.Next(10, 99).ToString() +
                _random.Next(100, 999).ToString());
        }
        public Account CheckUserExist(string accountNumber)
        {
            var connection = _connectionHelper.Connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            Account account = null;
            try
            {
                cmd.CommandText = $"select * from account where AccountNumber = '{accountNumber}'";
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        account = new Account()
                        {
                            AccountNumber = result["AccountNumber"].ToString(),
                            Phone = result["Phone"].ToString(),
                        };
                    }
                }
                result.Close();
            }catch(MySqlException e)
            {
                Console.WriteLine("Connection error!");
            }
            return account;
        }
    }
}
