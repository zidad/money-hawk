using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;
using MoneyHawk.Core;
using MoneyHawk.Core.Invoices;
using Net.Text;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;

namespace MoneyHawk.Web.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IMoneyBirdApi api;

        public ReportController()
        {
            api = MoneyBirdFactory.GetInstance();
        }

        public ActionResult Index()
        {
            var expenseLines = GetExpenseLinesWithContact();

            return View(expenseLines);
        }

        private List<ExpenseLineWithRelations> GetExpenseLinesWithContact()
        {
            var incomingInvoices = api.IncomingInvoices.GetAll();

            var invoiceLines = incomingInvoices
                .SelectMany(
                    incomingInvoice =>
                        incomingInvoice.Details.Select(details => new {Expense = incomingInvoice, Details = details}))
                .Where(e => e.Expense.ContactId.HasValue && e.Details.LedgerAccountId.HasValue);

            var contacts = GetContacts();
            var ledgerAccounts = api.LedgerAccounts.GetAll();

            var lines = from expense in invoiceLines
                join contact in contacts on expense.Expense.ContactId.Value equals contact.Id
                join ledger in ledgerAccounts on expense.Details.LedgerAccountId.Value equals ledger.Id
                select
                    new ExpenseLineWithRelations
                    {
                        Expense = expense.Expense,
                        Details = expense.Details,
                        Contact = contact,
                        Ledger = ledger
                    };

            var expenseLines = lines.Where(e => !e.Details.Description.ContainsIgnoreCase("Prive")).ToList();
            return expenseLines;
        }

        private IEnumerable<Contact> GetContacts()
        {
            var contacts = api.Contacts.GetAll();
            return contacts;
        }

        private IEnumerable<Invoice> GetInvoices()
        {
            return api.Invoices.GetAll().Where(c => c.ContactId.HasValue);
        }

        private IEnumerable<InvoiceReportModel> GetInvoiceReportLines()
        {
            return InvoiceLinesWithContacts().Select(i => new InvoiceReportModel
            {
                InvoiceNumber = i.Invoice.InvoiceId,
                InvoiceDate = i.Invoice.InvoiceDate,
                CustomerName = i.Contact.Name,
                TotalPriceExclTax = i.Details.TotalPriceExclTax,
                TaxPercentage = i.Details.Tax,
                TotalPriceInclTax = i.Details.TotalPriceInclTax,
                TotalTax = i.Details.TotalPriceInclTax - i.Details.TotalPriceExclTax,
                Paid = i.Invoice.State
            });
        }

        private IEnumerable<ExpenseReportModel> GetExpenseReportLines()
        {
            return GetExpenseLinesWithContact().Select(line => new ExpenseReportModel
            {
                InvoiceDate = line.Expense.InvoiceDate, //.To<String>("d")),
                Description = line.Details.Description,
                TotalPriceIncTax = line.Details.TotalPriceInclTax, //.To<String>("0.00")),
                Tax = line.Details.Tax, //.To<String>("0 %")),
                TotalPriceExclTax = line.Details.TotalPriceExclTax, //.To<String>("0.00")),
                TotalPriceInclTax = line.Details.TotalPriceInclTax, // - line.Details.TotalPriceExclTax)
                Kind1 = line.Type1,
                Kind2 = line.Type2,
                Invoice = line.Expense.InvoiceId,
                ContactId = line.Contact.Id,
                Contact = line.Contact.Name,
                LedgerId = line.Ledger.LedgerAccountId,
                Ledger = line.Ledger.Name,
                Price = line.Details.Price //.To<String>("0.00"))
            });
        }

        private IEnumerable<InvoiceLineWithRelations> InvoiceLinesWithContacts()
        {
            var contacts = GetContacts();

            var invoiceLines = GetInvoices()
                .SelectMany(invoice => invoice.Details.Select(details =>
                    new
                    {
                        Invoice = invoice,
                        Details = details
                    }));

            var invoiceLinesWithContacts = from invoice in invoiceLines
                join contact in contacts on invoice.Invoice.ContactId equals contact.Id
                select new InvoiceLineWithRelations {Invoice = invoice.Invoice, Details = invoice.Details, Contact = contact};

            return invoiceLinesWithContacts;
        }

        [HttpGet]
        public ActionResult Export(ReportOptions options)
        {
            using (var excelPackage = new ExcelPackage())
            {
                //Create the worksheet
                var expenses = excelPackage.Workbook.Worksheets.Add("Uitgaven");

                //Load the collection into the sheet, starting from cell A1. Print the column names on row 1
                expenses.Cells["A1"].LoadFromCollection(GetExpenseReportLines(), true, TableStyles.Light1);


                var income = excelPackage.Workbook.Worksheets.Add("Inkomsten");

                //Load the collection into the sheet, starting from cell A1. Print the column names on row 1
                income.Cells["A1"].LoadFromCollection(GetInvoiceReportLines(), true, TableStyles.Light1);


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

                return File(excelPackage.GetAsByteArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Export.xlsx");
            }
        }
    }

    public class ReportOptions
    {
    }
}