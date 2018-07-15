using System;
using System.Configuration;
using System.Threading.Tasks;
using MoneyHawk.Core;
using NUnit.Framework;

namespace MoneyHawk.Tests
{
    [TestFixture]
    public class ReceiptTests
    {
        readonly MoneyBirdClient client;

        public ReceiptTests()
        {
            var authorizationToken = ConfigurationManager.AppSettings["MoneyBirdAuthorizationToken"];
            var administrationId = ConfigurationManager.AppSettings["MoneyBirdAdministrationId"];

            client = new MoneyBirdClient(authorizationToken, administrationId);
        }

        [Test]
        public async Task GetPurchaseInvoicesFiltered()
        {
            var purchaseInvoices = await client.Receipts.Filter(new DateTime(2015,1,1), new DateTime(2015,12,31));
            foreach (var purchaseInvoice in purchaseInvoices)
                Console.WriteLine(purchaseInvoice);
        }
    }
}
