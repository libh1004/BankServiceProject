using DemoBankService2.Entity;
using DemoBankService2.Helper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankService2.Model
{
    public class TransactionModel
    {
        private ConnectionHelper _connectionHelper = new ConnectionHelper();
        public AccountModel Deposit(string accountNumber, double money, double newBalance)
        {
            Account account = null;
            var connection = _connectionHelper.Connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText = $"update account set balance = {newBalance} where AccountBalance = '{accountNumber}";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    $"insert into transactionhistory(Id, Code, Name, Amount, Fee, SenderCode, ReceiverCode, Type, Message, CreatedAt, UpdatedAt)" +
                    $" values (@Id, @Code, @Name, @Amount, @Fee, @SenderCode, @ReceiverCode, @Type, @Message, @CreatedAt, @UpdatedAt)";
                cmd.Parameters.AddWithValue("@Id", new TransctionService().Create)
            }
            catch ()
            {

            }
            return null;
        }
    }
}
