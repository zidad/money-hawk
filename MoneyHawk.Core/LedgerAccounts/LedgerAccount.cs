using System.Runtime.Serialization;

namespace MoneyHawk.Core
{
    using System;
    using System.Linq;

    [DataContract]
    public class LedgerAccountWrapper 
    {
        [DataMember(Name="ledger_account")]
        public LedgerAccount LedgerAccount { get; set; }
    }

    [DataContract]
    public class LedgerAccount
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "account_type")]
        public int AccountType { get; set; }
        [DataMember(Name = "active")]
        public bool Active { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "ledger_account_id")]
        public string LedgerAccountId { get; set; }
        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
    }
}