using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankService2.Entity
{
    public enum StatusValue
    {
        Active = 1,
        Deactive = 0,
        Deleted = -1
    }
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string PartnerCode { get; set; }
        public string PartnerPassword { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string CustomerCode { get; set; }
        public int OrderAmount { get; set; }
        public double AccountBalance { get; set; }
        public string OrderCode { get; set; }
        public int PinCode { get; set; }
        public StatusValue Status { get; set; }
        public string senderCode { get; set; }
        public string receiverCode { get; set; }
        public override string ToString()
        {
            return "CustomerCode " + CustomerCode + " AccountNumber " + AccountNumber + " PartnerCode " + PartnerCode;
        }
    }
}
