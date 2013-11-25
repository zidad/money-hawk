using System.Collections.Generic;
using System.Linq;
using System;

namespace MoneyHawk.Core
{
    [Serializable]
    public class IncomingInvoice
    {
        public int? Id { get; set; }
        ///concept-id	Integer	No	Read-only
         public int? ConceptId { get; set; }
        ///contact-id	Integer	Yes	Contact-id of existing contact
        public int? ContactId { get; set; }
        ///created-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
        public DateTime? CreatedAt { get; set; }
        ///currency	String	No	Default: EUR. For example: EUR, GBP or USD
        public string Currency { get; set; }
        ///due-date	Date	No	For example: 2011-02-25
        public DateTime? DueDate { get; set; }
        ///id	Integer	No	Read-only, the unique id of incoming invoice
        ///invoice-date	Date	Yes	For example: 2011-02-24
        public DateTime? InvoiceDate { get; set; }
        ///invoice-id	String	Yes	For example: 2011-1234. Must be unique for a contact!
        public string InvoiceId { get; set; }
        ///price-incl-tax	Decimal	No	Total price including tax for incoming invoice. Only needed if you don't use incoming invoice details.
       public decimal? PriceInclTax { get; set; }
        ///price-tax	Decimal	No	Total price tax for incoming invoice. Only needed if you don't use incoming invoice details.
        public decimal? PriceTax { get; set; }
        ///revision	Integer	No	Read-only, incremental integer, increases if incoming invoice is updated
        public int? Revision { get; set; }
        ///state	String	No	Read-only, can be: draft, open, late or paid
        public string State { get; set; }        
        ///total-paid	Decimal	No	Read-only
        public decimal? TotalPaid { get; set; }
        ///total-unpaid	Decimal	No	Read-only
        public decimal? TotalUnpaid { get; set; }
        ///updated-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
        public DateTime? UpdatedAt { get; set; }

        public List<Attachment> Attachments { get; set; }
        public List<Detail> Details { get; set; }
        public List<History> History { get; set; }
         
    }
}