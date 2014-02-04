using System.Linq;
using System;

namespace MoneyHawk.Core
{
    [Serializable]
    public class InvoicePayment
    {
        ///   Read-only, the unique id of the invoice payment
        private int? Id { get; set; }

        ///Read-only, for example: 2011-02-15T13:13:50+01:00
        private DateTime? CreatedAt { get; set; }

        ///Read-only, if payment is credit-invoice, reference to credit-invoice
        private int? CreditInvoiceId { get; set; }

        ///Read-only, the unique id of the invoice
        private int? InvoiceId { get; set; }

        ///For example: 2011-02-27
        private DateTime? PaymentDate { get; set; }

        ///Values can be: bank_transfer, creditcard, direct_debit, ideal, paypal, pin
        private String PaymentMethod { get; set; }

        ///For example: 119.0
        private Decimal? Price { get; set; }

        ///Read-only, for example: 2011-02-15T13:13:50+01:00
        private DateTime UpdatedAt { get; set; }
    }
}