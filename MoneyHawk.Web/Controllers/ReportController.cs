using System;
using System.Linq;
using System.Web.Mvc;

namespace MoneyHawk.Web.Controllers
{
    using System.Collections.Generic;
    using System.Runtime.Caching;

    using MoneyHawk.Core;

    public class ReportController : Controller
    {
        private IMoneyBirdApi api;

        public ReportController()
        {
            this.api = MoneyBirdFactory.GetInstance();

        }

        public ActionResult Index()
        {
            var incomingInvoices = api.IncomingInvoices.GetAll();

            var invoiceLines = incomingInvoices
                .SelectMany(incomingInvoice => incomingInvoice.Details.Select(x => new { Expense = incomingInvoice, Detail = x }))
                .Where(e => e.Expense.ContactId.HasValue && e.Detail.LedgerAccountId.HasValue);

            var contacts = this.GetContacts();
            var ledgerAccounts = api.LedgerAccounts.GetAll();

            var lines = from expense in invoiceLines
                    join contact in contacts on expense.Expense.ContactId.Value equals contact.Id
                    join ledger in ledgerAccounts on expense.Detail.LedgerAccountId.Value equals ledger.Id
                    select new ExpenseLine { Expense = expense.Expense, Detail = expense.Detail, Contact = contact, Ledger = ledger };

            var expenseLines = lines.Where(e=>!e.Detail.Description.ContainsIgnoreCase("Prive")).ToList();

            return View(expenseLines);
        }

        private IEnumerable<Contact> GetContacts()
        {
            var contacts = this.api.Contacts.GetAll();
            return contacts;
        }
    }

    public class ExpenseReport 
    { 
        
    }


    public class ExpenseLine
    {
        public IncomingInvoice Expense { get; set; }
        public Detail Detail { get; set; }
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
