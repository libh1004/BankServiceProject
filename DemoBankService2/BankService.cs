using DemoBankService2.Entity;
using DemoBankService2.Helper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DemoBankService2
{
    public class BankService : IBankService
    {
        public static List<Account> listAccount = new List<Account>();
        private ConnectionHelper _connectionHelper = new ConnectionHelper();
        private MD5Helper _md5Helper = new MD5Helper();
        private Account _account = null;
        public string GetInfo(string username, string password)
        {

            MySqlConnection connection = new MySqlConnection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = $"select * from account where Phone = "
            var inforCustomer = new Account()
            {

            }
            throw new NotImplementedException();
        }

        public TransactionHistory WithDrawal(string username, string password, double amount)
        {
            throw new NotImplementedException();
        }

        public TransactionHistory Deposit(string username, string password, double amount)
        {
            throw new NotImplementedException();
        }

        public TransactionHistory Tranfer(string username, string password, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
