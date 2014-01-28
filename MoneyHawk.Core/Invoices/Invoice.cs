using System.Collections.Generic;
using System.Linq;
using System;

namespace MoneyHawk.Core.Invoices
{

    [Serializable]
    public class Invoice
    {
        public int? Id { get; set; }
        public int? ContactId { get; set; }
        public string CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Attention { get; set; }
        public string InvoiceId { get; set; }
        public string Companyname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Sendmethod { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public string PoNumber { get; set; }
        public string InvoiceHash { get; set; }
        public string State { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string InvoiceEmail { get; set; }
        public string InvoiceEmailReminder { get; set; }
        public string Name { get; set; }
        public string PayUrl { get; set; }
        public string Url { get; set; }
        public string TaxNumber { get; set; }
        public bool? ShowTaxNumber { get; set; }
        public int? InvoiceProfileVersionId { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal? TotalPriceInclTax { get; set; }
        public bool? ShowTax { get; set; }
        public int? DueDateInterval { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? InvoiceProfileId { get; set; }
        public bool? ShowCustomerId { get; set; }
        public int? OriginalInvoiceId { get; set; }
        public int? RecurringTemplateId { get; set; }
        public int? OriginalEstimateId { get; set; }
        public int? ConceptId { get; set; }
        public int? DaysOpen { get; set; }
        public int? Revision { get; set; }
        public decimal? TotalPaid { get; set; }
        public decimal? TotalPriceExclTax { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalUnpaid { get; set; }
        public List<InvoicePayment> Payments { get; set; }
        public List<History> History { get; set; }
        public List<Details> Details { get; set; }
    }
}