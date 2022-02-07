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
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Phone { get; set; }
        public string OrderCode { get; set; }
        public int OrderAmount { get; set; }
        public double AccountBalance { get; set; }  
        public int PinCode { get; set; }
        public StatusValue Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public override string ToString()
        {
            return $" AccountNumber {AccountNumber}, Phone {Phone}";
        }
    }
}
