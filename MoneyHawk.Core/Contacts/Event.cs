using System;
using Newtonsoft.Json;

namespace MoneyHawk.Core
{
    public class Event
    {
        [JsonProperty("administration_id")]
        public long AdministrationId { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("link_entity_id")]
        public object LinkEntityId { get; set; }

        [JsonProperty("link_entity_type")]
        public object LinkEntityType { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"{nameof(UserId)}: {UserId}, {nameof(Action)}: {Action}, {nameof(Data)}: {Data}, {nameof(CreatedAt)}: {CreatedAt}, {nameof(UpdatedAt)}: {UpdatedAt}";
        }
    }
}