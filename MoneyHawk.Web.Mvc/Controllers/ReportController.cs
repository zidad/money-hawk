using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Mvc;
using MoneyHawk.Core;
using Net.Text;
using OfficeOpenXml;

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
            var incomingInvoices = api.IncomingInvoices.GetAll();

            var invoiceLines = incomingInvoices
                .SelectMany(incomingInvoice => incomingInvoice.Details.Select(x => new { Expense = incomingInvoice, Details = x }))
                .Where(e => e.Expense.ContactId.HasValue && e.Details.LedgerAccountId.HasValue);

            var contacts = GetContacts();
            var ledgerAccounts = api.LedgerAccounts.GetAll();

            var lines = from expense in invoiceLines
                    join contact in contacts on expense.Expense.ContactId.Value equals contact.Id
                    join ledger in ledgerAccounts on expense.Details.LedgerAccountId.Value equals ledger.Id
                    select new ExpenseLine { Expense = expense.Expense, Details = expense.Details, Contact = contact, Ledger = ledger };

            var expenseLines = lines.Where(e=>!e.Details.Description.ContainsIgnoreCase("Prive")).ToList();

            return View(expenseLines);
        }

        private IEnumerable<Contact> GetContacts()
        {
            var contacts = this.api.Contacts.GetAll();
            return contacts;
        }

        [HttpPost]
        public ActionResult Export(ReportOptions options)
        {
            using (var pck = new ExcelPackage())
            {
/*
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Demo");

                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                ws.Cells["A1"].LoadFromDataTable(tbl, true);

                //Format the header for column 1-3
                using (ExcelRange rng = ws.Cells["A1:C1"])
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

                //Write it back to the client
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=ExcelDemo.xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());

                return new FileStreamResult();
                //return new ExcelExportResult();
*/
                throw new NotImplementedException();
            }
        }
    }

    public class ExcelExportResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            
        }
    }

    public class ReportOptions
    {
    }

    public class ExpenseReport 
    { 
        
    }

    [DataContract]
    public class ExpenseLine
    {
        public IncomingInvoice Expense { get; set; }
        public Details Details { get; set; }
        public Contact Contact { get; set; }
        public LedgerAccount Ledger { get; set; }

        public string Type1
        {
            get
            {
                return Ledger.Name.Split('-').Skip(1).FirstOrDefault() ?? "";
            }
        }
        
        public string Type2
        {
            get
            {
                return Ledger.Name.Split('-').Skip(2).FirstOrDefault() ?? "";
            }
        }
    }
}
