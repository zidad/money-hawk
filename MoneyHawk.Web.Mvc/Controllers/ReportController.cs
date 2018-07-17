using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using MoneyHawk.Core;
using MoneyHawk.Web.Models;
using Net.System;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace MoneyHawk.Web.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        readonly IMoneyBirdClient client;

        public ReportController(IMoneyBirdClient client)
        {
            this.client = client;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Expenses(DateTime? start = null, DateTime? end = null)
        {
            var expenseLines = await GetExpenseLinesWithRelations(start ?? DateTime.Now.AddYears(-1), DateTime.Now);

            return View(expenseLines);
        }

        async Task<List<ExpenseLineWithRelations>> GetExpenseLinesWithRelations(DateTime start, DateTime end)
        {
            var purchaseInvoices = await client.PurchaseInvoices.Filter(start, end);
            var receipts = await client.Receipts.Filter(start, end);

            var invoiceLines = purchaseInvoices
                .OfType<Purchase>()
                .Concat(receipts)
                .SelectMany(
                    purchaseInvoice =>
                        purchaseInvoice.Details.Select(details => new {
                            Expense = purchaseInvoice,
                            Details = details
                        }))
                .Where(e => e.Expense.ContactId.HasValue && e.Details.LedgerAccountId.HasValue)
                .OrderBy(e=>e.Expense.Date);

            //var contacts = await GetContacts();
            var ledgerAccounts = await client.LedgerAccounts.GetAll();
            var taxes = (await GetTaxRates()).ToArray();

            var lines = from expense in invoiceLines
                //join contact in contacts on expense.Expense.ContactId equals contact.Id
                join ledger in ledgerAccounts on expense.Details.LedgerAccountId equals ledger.Id
                select
                    new ExpenseLineWithRelations
                    {
                        Expense = expense.Expense,
                        Line = expense.Details,
                        Tax = expense.Details.TaxRateId.SelectValue(a=>taxes.FirstOrDefault(t=>t.Id==a)),
                        //Contact = contact,
                        Ledger = ledger
                    };

            var expenseLines = lines.ToList();
            return expenseLines;
        }

        async Task<IEnumerable<Contact>> GetContacts()
        {
            var contacts = await client.Contacts.GetAll();
            return contacts;
        }

        async Task<IEnumerable<SalesInvoice>> GetInvoices(DateTime start, DateTime end)
        {
            return (await client.SalesInvoices.Filter(start, end)).Where(c => c.ContactId.HasValue);
        }

        async Task<IEnumerable<TaxRate>> GetTaxRates()
        {
            return (await client.TaxRates.GetAll());
        }

        public async Task <IEnumerable<InvoiceReportLine>> GetSalesInvoiceReportLines(DateTime start, DateTime end)
        {
            return (await InvoiceLinesWithRelations(start, end))
                .Select(i => new InvoiceReportLine
                    {
                        InvoiceNumber = i.Invoice.InvoiceId,
                        InvoiceDate = i.Invoice.InvoiceDate,
                        CustomerName = i.Invoice.Contact.CompanyName,
                        TotalPriceExclTax = i.Line.TotalPriceExclTaxWithDiscount,
                        TaxPercentage = i.Tax.Percentage,
                        TotalPriceInclTax = i.Line.TotalPriceExclTaxWithDiscount + (i.Tax.Percentage * i.Line.TotalPriceExclTaxWithDiscount)*0.01m,
                        TotalTax = i.Tax.Percentage * i.Line.TotalPriceExclTaxWithDiscount * 0.01m,
                        Paid = i.Invoice.State
                    });
        }

        public async Task<IEnumerable<ExpenseReportLine>> GetExpenseReportLines(DateTime start, DateTime end)
        {
            return (await GetExpenseLinesWithRelations(start, end)).Select(i => new ExpenseReportLine
            {
                Contact = i.Expense.Contact.CompanyName,
                ContactId = i.Expense.Contact.Id,
                Ledger = i.Ledger.Name,
                LedgerId = i.Ledger.AccountId,
                InvoiceDate = i.Expense.Date, //.To<String>("d")),
                Description = i.Line.Description,
                Tax = i.Line.TotalPriceExclTaxWithDiscount * (i.Tax.Percentage * 0.01m), //.To<String>("0 %")),
                TaxPercentage = i.Tax.Percentage, //.To<String>("0 %")),
                TotalPriceExclTax = i.Line.TotalPriceExclTaxWithDiscount, //.To<String>("0.00")),
                Kind1 = i.Ledger.Name.Split('-').Skip(1).FirstOrDefault() ?? "",
                Kind2 = i.Ledger.Name.Split('-').Skip(2).FirstOrDefault() ?? "",
                Invoice = i.Expense.Reference,
                TotalPriceInclTax = i.Line.TotalPriceExclTaxWithDiscount + ((i.Line.TotalPriceExclTaxWithDiscount * i.Tax.Percentage) * 0.01m) //.To<String>("0.00"))
            });
        }

        async Task<IEnumerable<InvoiceLineWithRelations>> InvoiceLinesWithRelations(DateTime start, DateTime end)
        {
            //var contacts = await GetContacts();
            var invoices = await GetInvoices(start, end);
            var taxRates = await GetTaxRates();

            var invoiceLines = invoices
                .SelectMany(invoice => invoice.Details.Select(details =>
                    new InvoiceLineWithRelations
                    {
                        Invoice = invoice,
                        Line = details,
                        Tax = details.TaxRateId.SelectValue(a=>taxRates.FirstOrDefault(tr=>tr.Id==a))
                    }));


            return invoiceLines;
        }

        [HttpGet]
        public async Task<ActionResult> Export(DateTime start, DateTime end, string name = "Export")
        {
            using (var excelPackage = new ExcelPackage())
            {
                //Create the worksheet
                var expenseWorksheet = excelPackage.Workbook.Worksheets.Add("Uitgaven");

                //Load the collection into the sheet, starting from cell A1. Print the column names on row 1
                var reportLines = await GetExpenseReportLines(start, end);

                var expenseReportLines = reportLines
                    .Where(e=>e.InvoiceDate.Between(start, end))
                    .ToArray();

                var expenseTable = expenseWorksheet.Cells["A1"].LoadFromCollection(expenseReportLines, true, TableStyles.Light1);
                //expenseTable.Table.Name = "Expenses";
                UpdateFormattingFromCollection(expenseReportLines, expenseWorksheet);

                var incomeWorksheet = excelPackage.Workbook.Worksheets.Add("Inkomsten");

                //Load the collection into the sheet, starting from cell A1. Print the column names on row 1
                var invoiceReportLines = (await GetSalesInvoiceReportLines(start, end))
                    .Where(e => e.InvoiceDate.Between(start, end))
                    .ToArray();

                var invoicesTable = incomeWorksheet.Cells["A1"].LoadFromCollection(invoiceReportLines, true, TableStyles.Light1);
                //invoicesTable.Table.Name = "Invoices";

                UpdateFormattingFromCollection(invoiceReportLines, incomeWorksheet);

/*
                //Format the header for column 1-3
                using (var rng = ws.Cells["A1:C1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    rng.Style.Font.Color.SetColor(Color.White);
                }

                //Example how to Format Column 1 as numeric 
                using (ExcelRange col = ws.Cells[2, 1, 2 + tbl.Rows.Count, 1])
                {
                    col.Style.Numberformat.Format = "#,##0.00";
                    col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
*/

                return File(excelPackage.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{name}.xlsx");
            }
        }

        static void UpdateFormattingFromCollection<T>(ICollection<T> expenseReportLines, ExcelWorksheet expenseWorksheet)
        {
            var type = typeof(T);
            var propertyInfos = type.GetProperties();
            for (var index = 0; index < propertyInfos.Length; index++)
            {
                var property = propertyInfos[index];
                var col = (char) ('A' + index);
                var address = $"{col}1:{col}{expenseReportLines.Count + 1}";

                if (property.PropertyType == typeof (DateTime) || property.PropertyType == typeof (DateTime?))
                    expenseWorksheet.Cells[address].Style.Numberformat.Format =
                        Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                else if (property.PropertyType == typeof (decimal) || property.PropertyType == typeof (decimal?))
                    expenseWorksheet.Cells[address].Style.Numberformat.Format = "#,##0.00";
                else if (property.PropertyType == typeof (long) || property.PropertyType == typeof (long?))
                    expenseWorksheet.Cells[address].Style.Numberformat.Format = "00000000000";
            }
        }
    }

    public class ReportOptions
    {
    }
}