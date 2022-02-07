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
    public class AccountModel
    {
        private ConnectionHelper _connectionHelper = new ConnectionHelper();
        private MD5Helper _md5Helper = new MD5Helper();
        private Account _account = null;
       
        public Boolean CreateNewAccount(Account account)
        {
            MySqlConnection connection = _connectionHelper.Connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText =
                    "insert into account(AccountNumber, PasswordHash, Salt, CustomerCode, OrderAmount, AccountBalance, Phone, OrderCode, PinCode, Status, SenderCode, ReceiverCode) values " +
                    "(@AccountNumber, @PasswordHash, @Salt, @CustomerCode, @OrderAmount, @AccountBalance, @Phone, @OrderCode, @PinCode, @Status, @SenderCode, @ReceiverCode)";
                cmd.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
                cmd.Parameters.AddWithValue("@PasswordHash", account.PasswordHash);
                cmd.Parameters.AddWithValue("@Salt", account.Salt);
                cmd.Parameters.AddWithValue("@CustomerCode", account.CustomerCode);
                cmd.Parameters.AddWithValue("@OrderAmount", account.OrderAmount);
                cmd.Parameters.AddWithValue("@AccountBalance", account.AccountBalance);
                cmd.Parameters.AddWithValue("@Phone", account.Phone);
                cmd.Parameters.AddWithValue("@OrderCode", account.OrderCode);
                cmd.Parameters.AddWithValue("@PinCode", account.PinCode);
                cmd.Parameters.AddWithValue("@Status", account.Status);
                cmd.Parameters.AddWithValue("@SenderCode", account.SenderCode);
                cmd.Parameters.AddWithValue("@ReceiverCode", account.ReceiverCode);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException e)
            {
                return false;
            }
        }
        public Account Login(string account, string password)
        {
            // kiem tra xem trong db co thong tin (partnercode) vua nhap ko
            // 1. truy van trong db
            // 2. kiem tra xem passwordhash va password trong db co trung khop ko, neu = lay ra du lieu, neu ko thi password wrong
            // kiem tra xem trong db co thong tin accountnumber ko
            // 1. truy van trong db
            // 2. kiem tra xem passwordhash va password trong db co trung khop ko, neu = lay ra du lieu, neu ko thi password wrong
            // neu tat ca deu ko  =>  chua dang ky tai khoan, chuyen den phan dang ky tai khoan
            // neu login fail qua 3 lan => gui ma OTP vao so dien thoai da dang ky.

            MySqlConnection connection = new MySqlConnection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            try
            {
                command.CommandText = $"select * from account where Phone = '{_account.Phone}'";
                MySqlDataReader result = command.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        var salt = result["salt"];
                        var passwordHash = _md5Helper.PasswordHash(password, salt.ToString());
                        if (passwordHash.Equals(result["PasswordHash"].ToString()))
                        {
                            command.CommandText = $"select * from account where PasswordHash = '{passwordHash}'";
                            MySqlDataReader accountData = command.ExecuteReader();
                            if (accountData.HasRows)
                            {
                                while (accountData.Read())
                                {
                                    Account _account = new Account()
                                    {
                                        AccountNumber = accountData["AccountNumber"].ToString(),
                                        PasswordHash = accountData["PasswordHash"].ToString(),
                                        Salt = accountData["Salt"].ToString(),
                                        CustomerCode = accountData["CustomerCode"].ToString(),
                                        OrderAmount = int.Parse(accountData["OrderAmount"].ToString()),
                                        AccountBalance = double.Parse(accountData["AccountBalance"].ToString()),
                                        OrderCode = accountData["OrderCode"].ToString(),
                                        //PinCode = int.Parse(accountData["PinCode"].ToString()),
                                        //Status = int.Parse(accountData["Status"].ToString())
                                    };
                                    accountData.Close();
                                    return _account;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong password. Please enter again.");
                        }
                    }
                }
                else
                {
                    result.Close();
                    command.CommandText = $"select * from account where AccountNumber = '{_account.AccountNumber}'";
                    MySqlDataReader account2 = command.ExecuteReader();
                    if (account2.HasRows)
                    {
                        while (account2.Read())
                        {
                            var salt = account2["salt"];
                            var passwordHash = _md5Helper.PasswordHash(password, salt.ToString());
                            if (passwordHash.Equals(account2["PasswordHash"]))
                            {
                                command.CommandText = $"select * from account where PasswordHash = '{passwordHash}'";
                                Account _account2 = new Account()
                                {
                                    AccountNumber = account2.ToString(),
                                    PasswordHash = account2["PasswordHash"].ToString(),
                                    Salt = account2["Salt"].ToString(),
                                    CustomerCode = account2["CustomerCode"].ToString(),
                                    OrderAmount = int.Parse(account2["OrderAmount"].ToString()),
                                    AccountBalance = double.Parse(account2["AccountBalance"].ToString()),
                                    OrderCode = account2["OrderCode"].ToString(),
                                };
                                account2.Close();
                                return _account2;
                            }
                            else
                            {
                                Console.WriteLine("Wrong password. Please enter again.");
                                _account = null;
                                return null;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No registered with account: {account}");
                        account2.Close();
                        _account = null;
                        return null;
                    }

                }
                return _account;
            }
            catch (MySqlException e)
            {
                _account = null;
                return null;
            }

        }
    }
}
