using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoneyHawk.Core
{
    public class SalesInvoice
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("administration_id")]
        public long AdministrationId { get; set; }

        [JsonProperty("contact_id")]
        public long? ContactId { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonProperty("recurring_sales_invoice_id")]
        public long? RecurringSalesInvoiceId { get; set; }

        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("document_style_id")]
        public long? DocumentStyleId { get; set; }

        [JsonProperty("identity_id")]
        public long? IdentityId { get; set; }

        [JsonProperty("draft_id")]
        public long? DraftId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("invoice_date")]
        public DateTime? InvoiceDate { get; set; }

        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("payment_conditions")]
        public string PaymentConditions { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("discount")]
        public string Discount { get; set; }

        [JsonProperty("original_sales_invoice_id")]
        public object OriginalSalesInvoiceId { get; set; }

        [JsonProperty("paid_at")]
        public object PaidAt { get; set; }

        [JsonProperty("sent_at")]
        public string SentAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("details")]
        public IList<Line> Details { get; set; }

        [JsonProperty("payments")]
        public IList<object> Payments { get; set; }

        [JsonProperty("total_paid")]
        public string TotalPaid { get; set; }

        [JsonProperty("total_unpaid")]
        public string TotalUnpaid { get; set; }

        [JsonProperty("total_unpaid_base")]
        public string TotalUnpaidBase { get; set; }

        [JsonProperty("prices_are_incl_tax")]
        public bool PricesAreInclTax { get; set; }

        [JsonProperty("total_price_excl_tax")]
        public decimal? TotalPriceExclTax { get; set; }

        [JsonProperty("total_price_excl_tax_base")]
        public decimal? TotalPriceExclTaxBase { get; set; }

        [JsonProperty("total_price_incl_tax")]
        public decimal? TotalPriceInclTax { get; set; }

        [JsonProperty("total_price_incl_tax_base")]
        public decimal? TotalPriceInclTaxBase { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("custom_fields")]
        public IList<object> CustomFields { get; set; }

        [JsonProperty("notes")]
        public IList<object> Notes { get; set; }

        [JsonProperty("attachments")]
        public IList<object> Attachments { get; set; }

        [JsonProperty("events")]
        public IList<Event> Events { get; set; }
    }
}