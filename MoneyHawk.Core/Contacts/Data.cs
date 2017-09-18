using Newtonsoft.Json;

namespace MoneyHawk.Core
{
    public class Data
    {
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("email_message")]
        public string EmailMessage { get; set; }
    }
}