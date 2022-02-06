using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankService2.ViewModel
{
    [DataContract]
    public class AccountViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string PartnerCode { get; set; }
        [DataMember]
        public string PartnerPassword { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }
        [DataMember]
        public string Salt { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public int OrderAmount { get; set; }
        [DataMember]
        public double AccountBalance { get; set; }
        [DataMember]
        public string OrderCode { get; set; }
        [DataMember]
        public int PinCode { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime UpdatedAt { get; set; }
    }
}
