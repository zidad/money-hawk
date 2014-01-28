using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoneyHawk.Core
{

    [DataContract]
    public class IncomingInvoiceWrapper
    {
        [DataMember(Name="incoming_invoice")]
        public IncomingInvoice IncomingInvoice { get; set; }
    }

    [DataContract]
    public class IncomingInvoice
    {
        [DataMember(Name = "id")]
        public int? Id { get; set; }
        ///concept-id	Integer	No	Read-only
        [DataMember(Name = "concept_id")]
        public int? ConceptId { get; set; }
        ///contact-id	Integer	Yes	Contact-id of existing contact
        [DataMember(Name = "contact_id")]
        public int? ContactId { get; set; }
        ///created-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
        [DataMember(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }
        ///currency	String	No	Default: EUR. For example: EUR, GBP or USD
        [DataMember(Name = "currency")]
        public string Currency { get; set; }
        ///due-date	Date	No	For example: 2011-02-25
        [DataMember(Name = "due_date")]
        public DateTime? DueDate { get; set; }
        ///id	Integer	No	Read-only, the unique id of incoming invoice
        ///invoice-date	Date	Yes	For example: 2011-02-24
        [DataMember(Name = "invoice_date")]
        public DateTime? InvoiceDate { get; set; }
        ///invoice-id	String	Yes	For example: 2011-1234. Must be unique for a contact!
        [DataMember(Name = "invoice_id")]
        public string InvoiceId { get; set; }
        ///price-incl-tax	Decimal	No	Total price including tax for incoming invoice. Only needed if you don't use incoming invoice details.
        [DataMember(Name = "price_incl_tax")]
        public decimal? PriceInclTax { get; set; }
        ///price-tax	Decimal	No	Total price tax for incoming invoice. Only needed if you don't use incoming invoice details.
        [DataMember(Name = "price_tax")]
        public decimal? PriceTax { get; set; }
        ///revision	Integer	No	Read-only, incremental integer, increases if incoming invoice is updated
        [DataMember(Name = "revision")]
        public int? Revision { get; set; }
        ///state	String	No	Read-only, can be: draft, open, late or paid
        [DataMember(Name = "state")]
        public string State { get; set; }        
        ///total-paid	Decimal	No	Read-only
        [DataMember(Name = "total_paid")]
        public decimal? TotalPaid { get; set; }
        ///total-unpaid	Decimal	No	Read-only
        [DataMember(Name = "total_unpaid")]
        public decimal? TotalUnpaid { get; set; }
        ///updated-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
        [DataMember(Name = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [DataMember(Name="attachments")]
        public List<Attachment> Attachments { get; set; }
        
        [DataMember(Name = "details")]
        public List<Details> Details { get; set; }
        
        [DataMember(Name = "history")]
        public List<History> History { get; set; }
        
        [DataMember(Name = "payments")]
        public List<Payment> Payments { get; set; }
         
    }
}