using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoneyHawk.Core
{
    public class Receipt
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("administration_id")]
        public long AdministrationId { get; set; }

        [JsonProperty("contact_id")]
        public long? ContactId { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("entry_number")]
        public int EntryNumber { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("exchange_rate")]
        public string ExchangeRate { get; set; }

        [JsonProperty("revenue_invoice")]
        public bool RevenueInvoice { get; set; }

        [JsonProperty("prices_are_incl_tax")]
        public bool PricesAreInclTax { get; set; }

        [JsonProperty("origin")]
        public object Origin { get; set; }

        [JsonProperty("paid_at")]
        public DateTime? PaidAt { get; set; }

        [JsonProperty("tax_number")]
        public string TaxNumber { get; set; }

        [JsonProperty("total_price_excl_tax")]
        public decimal? TotalPriceExclTax { get; set; }

        [JsonProperty("total_price_excl_tax_base")]
        public decimal? TotalPriceExclTaxBase { get; set; }

        [JsonProperty("total_price_incl_tax")]
        public decimal? TotalPriceInclTax { get; set; }

        [JsonProperty("total_price_incl_tax_base")]
        public decimal? TotalPriceInclTaxBase { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("details")]
        public IList<Line> Details { get; set; }

        [JsonProperty("payments")]
        public IList<object> Payments { get; set; }

        [JsonProperty("notes")]
        public IList<object> Notes { get; set; }

        [JsonProperty("attachments")]
        public IList<object> Attachments { get; set; }

        [JsonProperty("events")]
        public IList<Event> Events { get; set; }
    }
}