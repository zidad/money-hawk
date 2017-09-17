using System.Linq;
using System;

namespace MoneyHawk.Core
{
    [Serializable]
    public class InvoicePayment
    {
        ///   Read-only, the unique id of the invoice payment
        int? Id { get; set; }

        ///Read-only, for example: 2011-02-15T13:13:50+01:00
        DateTime? CreatedAt { get; set; }

        ///Read-only, if payment is credit-invoice, reference to credit-invoice
        int? CreditInvoiceId { get; set; }

        ///Read-only, the unique id of the invoice
        int? InvoiceId { get; set; }

        ///For example: 2011-02-27
        DateTime? PaymentDate { get; set; }

        ///Values can be: bank_transfer, creditcard, direct_debit, ideal, paypal, pin
        String PaymentMethod { get; set; }

        ///For example: 119.0
        Decimal? Price { get; set; }

        ///Read-only, for example: 2011-02-15T13:13:50+01:00
        DateTime UpdatedAt { get; set; }
    }
}