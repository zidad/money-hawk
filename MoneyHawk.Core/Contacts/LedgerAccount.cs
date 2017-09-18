using System;
using Newtonsoft.Json;

namespace MoneyHawk.Core
{
    /// <summary>
    /// https://developer.moneybird.com/api/ledger_accounts/
    /// /ledger_accounts	GET	List all ledger accounts of an administration
    /// /ledger_accounts/:id	GET	Returns information about a ledger account
    /// /ledger_accounts	POST	Creates a new ledger account
    /// /ledger_accounts/:id	PATCH	Updates a ledger account
    /// /ledger_accounts/:id	DELETE	Deletes a ledger account
    /// </summary>
    public class LedgerAccount
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("administration_id")]
        public long AdministrationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}