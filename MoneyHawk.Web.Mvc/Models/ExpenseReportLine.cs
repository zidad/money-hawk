using System;
using System.ComponentModel;

namespace MoneyHawk.Web.Controllers
{
    [DisplayName("Expenses")]
    public class ExpenseReportLine
    {
        [DisplayName("Datum")]
        public DateTime? InvoiceDate { get; set; }

        [DisplayName("Naam")]
        public string Description { get; set; }

        [DisplayName("incl btw")]
        public decimal? TotalPriceInclTax { get; set; }

        [DisplayName("%")]
        public decimal? TaxPercentage { get; set; }

        [DisplayName("ex")]
        public decimal? TotalPriceExclTax { get; set; }

        [DisplayName("btw")]
        public decimal? Tax { get; set; }

        [DisplayName("soort")]
        public string Kind1 { get; set; }

        [DisplayName("soort")]
        public string Kind2 { get; set; }

        [DisplayName("factuurnummer")]
        public string Invoice { get; set; }

        [DisplayName("contact nr")]
        public long ContactId { get; set; }

        [DisplayName("contact naa")]
        public string Contact { get; set; }

        [DisplayName("grootboekrekening")]
        public string LedgerId { get; set; }

        [DisplayName("grootboekrekeningnaam")]
        public string Ledger { get; set; }

        public override string ToString()
        {
            return $"{nameof(InvoiceDate)}: {InvoiceDate}, {nameof(Description)}: {Description}, {nameof(Tax)}: {Tax}, {nameof(TotalPriceExclTax)}: {TotalPriceExclTax}, {nameof(TotalPriceInclTax)}: {TotalPriceInclTax}, {nameof(Kind1)}: {Kind1}, {nameof(Kind2)}: {Kind2}, {nameof(Invoice)}: {Invoice}, {nameof(ContactId)}: {ContactId}, {nameof(Contact)}: {Contact}, {nameof(LedgerId)}: {LedgerId}, {nameof(Ledger)}: {Ledger}, {nameof(TaxPercentage)}: {TaxPercentage}";
        }
    }
}