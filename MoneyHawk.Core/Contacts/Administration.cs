using Newtonsoft.Json;

namespace MoneyHawk.Core
{
    /// <summary>
    /// https://developer.moneybird.com/api/administration/
    /// GET /:version/administrations(.:format)
    /// </summary>
    public class Administration
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }
    }
}