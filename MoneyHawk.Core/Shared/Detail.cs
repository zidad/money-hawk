using System.Linq;
using System;

namespace MoneyHawk.Core
{
    public class Detail
    {
        /// amount	String	No	For example: 1 x or 2 hours
        public string Amount { get; set; }
        
        /// created-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
        public DateTime? CreatedAt { get; set; }
        
        /// description	String	Yes	Description of invoice detail, for example: Table ABC format 140x90
        public string Description { get; set; }
        
        /// id	Integer	No	Read-only, unique id of invoice detail
        public int? Id { get; set; }
        
        /// invoice-id	Integer	No	Read-only, unique id of invoice
        public int? InvoiceId { get; set; }
        
        /// ledger-account-id	Integer	No	For MoneyBird Plus users, you can provide a ledger-account-id
        public int? LedgerAccountId { get; set; }
        
        /// price	Decimal	No	Default: 0.0. For example: 19.95
        public decimal? Price { get; set; }
        
        /// row-order	Integer	No	Give a row a fixed position in table
        public int? RowOrder { get; set; }
        
        /// tax	Decimal	No	Default: 0.0. For example: 0.19 for 19% TAX
        public decimal? Tax { get; set; }
        
        /// total-price-excl-tax	Decimal	No	Read-only
        public decimal? TotalPriceExclTax { get; set; }
        
        /// total-price-incl-tax	Decimal	No	Read-only
        public decimal? TotalPriceInclTax { get; set; }
        
        /// updated-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
        public DateTime? UpdatedAt { get; set; }    
    }
}