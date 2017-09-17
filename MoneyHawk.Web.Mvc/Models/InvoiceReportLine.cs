using System;
using System.ComponentModel;

namespace MoneyHawk.Web.Controllers
{
    [DisplayName("Inkomsten")]
    public class InvoiceReportLine
    {
        [DisplayName("factnr")]
        public string InvoiceNumber { get; set; }

        [DisplayName("Datum")]
        public DateTime? InvoiceDate { get; set; }

        [DisplayName("Klant")]
        public string CustomerName { get; set; }

        [DisplayName("Omzet 21%")]
        public decimal? TotalPriceExclTax { get; set; }

        [DisplayName("btw %")]
        public decimal? TaxPercentage { get; set; }

        [DisplayName("inc btw")]
        public decimal? TotalPriceInclTax { get; set; }

        [DisplayName("Btw 21%")]
        public decimal? TotalTax { get; set; }

        [DisplayName("Ontvangst")]
        public string Paid { get; set; }


        public override string ToString()
        {
            return $"{nameof(InvoiceNumber)}: {InvoiceNumber}, {nameof(InvoiceDate)}: {InvoiceDate}, {nameof(CustomerName)}: {CustomerName}, {nameof(TotalPriceExclTax)}: {TotalPriceExclTax}, {nameof(TaxPercentage)}: {TaxPercentage}, {nameof(TotalPriceInclTax)}: {TotalPriceInclTax}, {nameof(TotalTax)}: {TotalTax}, {nameof(Paid)}: {Paid}";
        }
    }
}