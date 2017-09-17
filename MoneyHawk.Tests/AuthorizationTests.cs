using System;
using System.Configuration;
using System.Threading.Tasks;
using MoneyHawk.Core;
using MoneyHawk.Web.Controllers;
using NUnit.Framework;

namespace MoneyHawk.Tests
{
    [TestFixture]
    public class AuthorizationTests
    {
        MoneyBirdClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            var authorizationToken = ConfigurationManager.AppSettings["MoneyBirdAuthorizationToken"];
            var administrationId = ConfigurationManager.AppSettings["MoneyBirdAdministrationId"];

            if(authorizationToken==null)
                throw new Exception("Missing authorizationToken");

            if (administrationId == null)
                throw new Exception("Missing administrationId");

            client = new MoneyBirdClient(authorizationToken, administrationId);
        }

        [Test]
        public async Task GetContacts()

        {
            var contacts = await client.Contacts.GetAll();
            foreach (var contact in contacts)
                Console.WriteLine(contact);
        }

        [Test]
        public async Task TestReportSalesInvoices()
        {
            var controller = new ReportController(client);
            var invoiceReportLines = await controller.GetSalesInvoiceReportLines(DateTime.Today.AddYears(-1), DateTime.Today);
            foreach (var line in invoiceReportLines)
                Console.WriteLine(line);
        }

        [Test]
        public async Task TestReportExpenses()
        {
            var controller = new ReportController(client);
            var invoiceReportLines = await controller.GetExpenseReportLines(DateTime.Today.AddYears(-1), DateTime.Today);
            foreach (var line in invoiceReportLines)
                Console.WriteLine(line);
        }
    }
}
