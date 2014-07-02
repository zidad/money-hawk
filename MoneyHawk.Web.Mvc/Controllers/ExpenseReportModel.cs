using System;
using System.ComponentModel;

namespace MoneyHawk.Web.Controllers
{
    public class ExpenseReportModel
    {
        [DisplayName("Datum")]
        public DateTime? InvoiceDate { get; set; }

        [DisplayName("Naam")]
        public string Description { get; set; }

        [DisplayName("incl btw")]
        public decimal? TotalPriceIncTax { get; set; }

        [DisplayName("%")]
        public decimal? Tax { get; set; }

        [DisplayName("ex")]
        public decimal? TotalPriceExclTax { get; set; }

        [DisplayName("btw")]
        public decimal? TotalPriceInclTax { get; set; }

        [DisplayName("soort")]
        public string Kind1 { get; set; }

        [DisplayName("soort")]
        public string Kind2 { get; set; }

        [DisplayName("factuurnummer")]
        public string Invoice { get; set; }

        [DisplayName("contact nr")]
        public int ContactId { get; set; }

        [DisplayName("contact naa")]
        public string Contact { get; set; }

        [DisplayName("grootboekrekening")]
        public string LedgerId { get; set; }

        [DisplayName("grootboekrekeningnaam")]
        public string Ledger { get; set; }

        [DisplayName("prijs")]
        public decimal? Price { get; set; }
    }
}