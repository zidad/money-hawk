using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoneyHawk.Core
{
    public class Line
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("administration_id")]
        public long AdministrationId { get; set; }

        [JsonProperty("tax_rate_id")]
        public long? TaxRateId { get; set; }

        [JsonProperty("ledger_account_id")]
        public long? LedgerAccountId { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        [JsonProperty("period")]
        public object Period { get; set; }

        [JsonProperty("row_order")]
        public int RowOrder { get; set; }

        [JsonProperty("total_price_excl_tax_with_discount")]
        public decimal? TotalPriceExclTaxWithDiscount { get; set; }

        [JsonProperty("total_price_excl_tax_with_discount_base")]
        public decimal? TotalPriceExclTaxWithDiscountBase { get; set; }

        [JsonProperty("tax_report_reference")]
        public IList<string> TaxReportReference { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Amount)}: {Amount}, {nameof(Description)}: {Description}, {nameof(Price)}: {Price}, {nameof(Period)}: {Period}";
        }
    }
}