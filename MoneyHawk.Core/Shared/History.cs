using System.Linq;
using System;

namespace MoneyHawk.Core
{
    public class History
    {
        public int? InvoiceId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public String Action { get; set; }
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public String Description { get; set; }
    }
}