using DemoBankService2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankService2.Model
{
    public class AccountModel
    {
        private BankService bankService = new BankService();
        private Account _account = new Account();
        public string GetInfo(string username, string password)
        {
            // login success => get information user.
            if (bankService.Login(username, password) != null)
            {
                Account account = new Account()
                {
                    PartnerCode = ,

                }
            }
            return null;
        }
        public bool Deposit(string username, string password, double amount)
        {
            if (bankService.Login(username, password) != null)
            {
                if(_account.Status == 1)
                {
                    double newBalance = amount + _account.AccountBalance;
                    Console.WriteLine($"New balance is {newBalance}");
                }
            }
            return true;
        }
        public bool WithDrawal(string username, string password, double amount)
        {
            if (bankService.Login(username, password) != null)
            {
                if (amount < _account.AccountBalance)
                {
                    double newBalance = _account.AccountBalance - amount;
                    Console.WriteLine($"New balance is {newBalance}");
                }
            }
            return true;
        }

        public bool Tranfer(string username, string password, double amount, string senderBalance, string receiverBalance)
        {
            if(bankService.Login(username, password) != null)
            {
                if(_account.receiverCode == "Active" && amount < _account.)
                {

                }
            }
            return true;
        }

    }
}
