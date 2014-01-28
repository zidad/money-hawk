using System.Linq;
using System;
using System.Runtime.Serialization;

namespace MoneyHawk.Core
{
    [DataContract]
    public class Details
    {
        /// amount	String	No	For example: 1 x or 2 hours
        [DataMember(Name="amount")]
        public string Amount { get; set; }
        
        /// created-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
        [DataMember(Name = "created-at")]
        public DateTime? CreatedAt { get; set; }
        
        /// description	String	Yes	Description of invoice detail, for example: Table ABC format 140x90
        [DataMember(Name = "description")]
        public string Description { get; set; }
        
        /// id	Integer	No	Read-only, unique id of invoice detail
        [DataMember(Name = "id")]
        public int? Id { get; set; }
        
        /// invoice-id	Integer	No	Read-only, unique id of invoice
        [DataMember(Name = "invoice-id")]
        public int? InvoiceId { get; set; }
        
        /// ledger-account-id	Integer	No	For MoneyBird Plus users, you can provide a ledger-account-id
        [DataMember(Name = "ledger-account-id")]
        public int? LedgerAccountId { get; set; }
        
        /// price	Decimal	No	Default: 0.0. For example: 19.95
        [DataMember(Name = "price")]
        public decimal? Price { get; set; }
        
        /// row-order	Integer	No	Give a row a fixed position in table
        [DataMember(Name = "row-order")]
        public int? RowOrder { get; set; }
        
        /// tax	Decimal	No	Default: 0.0. For example: 0.19 for 19% TAX
        [DataMember(Name = "tax")]
        public decimal? Tax { get; set; }
        
        /// total-price-excl-tax Decimal	No	Read-only
        [DataMember(Name = "total-price-excl-tax")]
        public decimal? TotalPriceExclTax { get; set; }
        
        /// total-price-incl-tax	Decimal	No	Read-only
        [DataMember(Name = "total-price-incl-tax")]
        public decimal? TotalPriceInclTax { get; set; }
        
        /// updated-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
        [DataMember(Name = "updated-at")]
        public DateTime? UpdatedAt { get; set; }    
    }
}