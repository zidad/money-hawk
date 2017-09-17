using System;
using Newtonsoft.Json;

namespace MoneyHawk.Core
{
    /// <summary>
    /// https://developer.moneybird.com/api/tax_rates/
    /// GET /tax_rates(.:format)
    /// </summary>
    public class TaxRate
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("administration_id")]
        public long AdministrationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("percentage")]
        public decimal? Percentage { get; set; }

        [JsonProperty("tax_rate_type")]
        public string TaxRateType { get; set; }

        [JsonProperty("show_tax")]
        public bool ShowTax { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Percentage)}: {Percentage}, {nameof(TaxRateType)}: {TaxRateType}, {nameof(ShowTax)}: {ShowTax}";
        }
    }
}