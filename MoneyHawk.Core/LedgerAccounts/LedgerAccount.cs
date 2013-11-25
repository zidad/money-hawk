namespace MoneyHawk.Core
{
    using System;
    using System.Linq;

    [Serializable]
    public class LedgerAccount
    {
        public int Id { get; set; }
        public int AccountType { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string LedgerAccountId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}