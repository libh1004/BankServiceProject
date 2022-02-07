using DemoBankService2.Entity;
using DemoBankService2.Helper;
using DemoBankService2.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankService2.Service
{
    public class AccountService
    {
        private Random _random = new Random();
        private MD5Helper _md5Helper = new MD5Helper();
        private AccountModel _accountModel = new AccountModel();

        public void CreateAccountService(Account account)
        {
            var salt = _random.Next(100000000, 999999999).ToString();
            // create code card 
            var accountNumber = _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString() +
                _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString();
            // encrypt password
            var passwordHash = _md5Helper.PasswordHash(account.PasswordHash, salt);
            // create new object user with full infor
            var accountCreate = new Account()
            {
                AccountNumber = account.AccountNumber,
                PasswordHash = account.PasswordHash,
                Salt = account.Salt,
                OrderCode = account.OrderCode,
                OrderAmount = account.OrderAmount,
                AccountBalance = account.AccountBalance,
                PinCode = account.PinCode,
                Status = account.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var created = _accountModel.CreateNewAccount(accountCreate);
            if (created)
            {
                Console.WriteLine($"Create new successful account, your account number is: {accountNumber}");
            }
            else
            {
                Console.WriteLine("Create error!");
            }
        }

    }
}
