using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace MoneyHawk.Core.Invoices
{
    [DataContract]
    public class Invoice
    {
        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "contact_id")]
        public int? ContactId { get; set; }

        [DataMember(Name = "customer_id")]
        public string CustomerId { get; set; }

        [DataMember(Name = "lastname")]
        public string LastName { get; set; }

        [DataMember(Name = "firstname")]
        public string FirstName { get; set; }

        [DataMember(Name = "attention")]
        public string Attention { get; set; }

        [DataMember(Name = "invoice_id")]
        public string InvoiceId { get; set; }

        [DataMember(Name = "company_name")]
        public string Companyname { get; set; }

        [DataMember(Name = "address1")]
        public string Address1 { get; set; }

        [DataMember(Name = "address2")]
        public string Address2 { get; set; }

        [DataMember(Name = "zipcode")]
        public string ZipCode { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "send_method")]
        public string SendMethod { get; set; }

        [DataMember(Name = "language")]
        public string Language { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "po_number")]
        public string PoNumber { get; set; }

        [DataMember(Name = "invoice_hash")]
        public string InvoiceHash { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "contact_name")]
        public string ContactName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "invoice_email")]
        public string InvoiceEmail { get; set; }

        [DataMember(Name = "invoice_email_reminder")]
        public string InvoiceEmailReminder { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "pay_url")]
        public string PayUrl { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "tax_number")]
        public string TaxNumber { get; set; }

        [DataMember(Name = "show_tax_number")]
        public bool? ShowTaxNumber { get; set; }

        [DataMember(Name = "invoice_profile_version_id")]
        public int? InvoiceProfileVersionId { get; set; }

        [DataMember(Name = "invoice_profile_id")]
        public int? InvoiceProfileId { get; set; }

        [DataMember(Name = "discount")]
        public decimal? Discount { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "total_price_incl_tax")]
        public decimal? TotalPriceInclTax { get; set; }

        [DataMember(Name = "show_tax")]
        public bool? ShowTax { get; set; }

        [DataMember(Name = "due_date_interval")]
        public int? DueDateInterval { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [DataMember(Name = "invoice_date")]
        public DateTime? InvoiceDate { get; set; }

        [DataMember(Name = "show_customer_id")]
        public bool? ShowCustomerId { get; set; }

        [DataMember(Name = "original_invoice_id")]
        public int? OriginalInvoiceId { get; set; }

        [DataMember(Name = "recurring_template_id")]
        public int? RecurringTemplateId { get; set; }

        [DataMember(Name = "original_estimate_id")]
        public int? OriginalEstimateId { get; set; }

        [DataMember(Name = "concept_id")]
        public int? ConceptId { get; set; }

        [DataMember(Name = "days_open")]
        public int? DaysOpen { get; set; }

        [DataMember(Name = "revision")]
        public int? Revision { get; set; }

        [DataMember(Name = "total_paid")]
        public decimal? TotalPaid { get; set; }

        [DataMember(Name = "total_price_excl_tax")]
        public decimal? TotalPriceExclTax { get; set; }

        [DataMember(Name = "total_tax")]
        public decimal? TotalTax { get; set; }

        [DataMember(Name = "total_unpaid")]
        public decimal? TotalUnpaid { get; set; }

        [DataMember(Name = "payments")]
        public List<InvoicePayment> Payments { get; set; }

        [DataMember(Name = "history")]
        public List<History> History { get; set; }

        [DataMember(Name = "details")]
        public List<Details> Details { get; set; }
    }
}