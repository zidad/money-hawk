using System.Runtime.Serialization;

namespace MoneyHawk.Core
{
    [DataContract]
    public class IncomingInvoiceWrapper
    {
        [DataMember(Name="incoming_invoice")]
        public IncomingInvoice IncomingInvoice { get; set; }
    }
}