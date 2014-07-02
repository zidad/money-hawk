using System.Runtime.Serialization;
using MoneyHawk.Core.Invoices;

namespace MoneyHawk.Core
{
    [DataContract]
    public class InvoiceWrapper
    {
        [DataMember(Name = "invoice")]
        public Invoice Invoice { get; set; }
    }
}