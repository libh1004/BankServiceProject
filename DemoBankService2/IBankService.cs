using DemoBankService2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DemoBankService2
{
    [ServiceContract(Namespace = "DemoBankService2")]
    public interface IBankService
    {
        [OperationContract]
        Account Register(Account account);
        [OperationContract]
        Account Login(string username, string password);
        [OperationContract]
        string GetInfo(string username, string password);
        [OperationContract]
        TransactionHistory WithDrawal(string username, string password, double amount);
        [OperationContract]
        TransactionHistory Deposit(string username, string password, double amount);
        [OperationContract]
        TransactionHistory Tranfer(string username, string password, double amount);
    }
}
