using System.Linq;
using System;

namespace MoneyHawk.Core
{
    public enum InvoiceSelection
    {
        //GET /api/v1.0/invoices/filter/all.xml
        All,
        //GET /api/v1.0/invoices/filter/draft.xml
        Draft,
        //GET /api/v1.0/invoices/filter/last_month.xml
        LastMonth,        
        //GET /api/v1.0/invoices/filter/last_quarter.xml
        LastQuarter,
        //GET /api/v1.0/invoices/filter/open.xml
        Open,
        //GET /api/v1.0/invoices/filter/sent.xml
        Sent,
        //GET /api/v1.0/invoices/filter/this_month.xml
        ThisMonth,
        //GET /api/v1.0/invoices/filter/this_quarter.xml
        ThisQuarter,
        //GET /api/v1.0/invoices/filter/this_year.xml
        ThisYear
    }
}