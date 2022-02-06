using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankService2.Entity
{
    public class TransactionHistory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }
        public string SenderCode { get; set; }
        public string ReceiverCode { get; set; }
        public int Type { get; set; }
        public string Message { get; set; }
    }
}
