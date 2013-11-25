using System.Linq;
using System;

namespace MoneyHawk.Core
{
    /// <summary>
    /// undocumented at the time of writing
    /// </summary>
    public class Attachment 
    {
        ///<created-at type="datetime">2011-12-06T15:26:17+01:00</created-at>
        public DateTime? CreatedAt { get; set; }
        ///<updated-at type="datetime">2011-12-06T15:26:17+01:00</updated-at>
        public DateTime? UpdatedAt { get; set; }
        ///<file-file-size type="integer">41052</file-file-size>
        public int? FileFileSize { get; set; }
        ///<file-content-type type="IncomingInvoiceAttachment">application/pdf</file-content-type>
        public string FileContentType { get; set; }
        ///<file-updated-at type="datetime">2011-12-06T15:26:17+01:00</file-updated-at>
        public DateTime? FileUpdatedAt { get; set; }
        ///<file-file-name type="IncomingInvoiceAttachment">868718.pdf</file-file-name>
        public string FileFileName { get; set; }
        ///<id type="integer">85212</id>
        public int? Id { get; set; }
        ///<incoming-invoice-id type="integer">126622</incoming-invoice-id>
        public int? IncomingInvoiceId { get; set; }
        ///<original-url type="IncomingInvoiceAttachment">https://net-industry.moneybird.nl/incoming_invoices/126622/incoming_invoice_attachments/85212/download</original-url>
        public string OriginalUrl { get; set; }
        ///<preview-url type="IncomingInvoiceAttachment">https://net-industry.moneybird.nl/incoming_invoices/126622/incoming_invoice_attachments/85212</preview-url>
        public string PreviewUrl { get; set; }
    }
}