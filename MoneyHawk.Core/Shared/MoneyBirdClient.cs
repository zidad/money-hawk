using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Net.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MoneyHawk.Core
{
    public class MoneyBirdClient : IMoneyBirdClient
    {
        public static readonly Regex matchLinkHeader = new Regex(@"\<(?<url>https://.*)\>;\s?rel=\""(?<rel>\w+)\""");

        public MoneyBirdClient(string authorizationToken, string administrationId)
            : this(CreateDefaultRestClient(authorizationToken, administrationId))
        {
            if (authorizationToken.HasNoValue()) throw new ArgumentNullException(nameof(authorizationToken));
            if (administrationId.HasNoValue()) throw new ArgumentNullException(nameof(administrationId));
        }

        public MoneyBirdClient(HttpClient client)
        {
            Client = client;
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public HttpClient Client { get; }

        public SalesInvoices SalesInvoices => new SalesInvoices(this);

        public LedgerAccounts LedgerAccounts => new LedgerAccounts(this);

        public Receipts Receipts => new Receipts(this);

        public Contacts Contacts => new Contacts(this);

        public TaxRates TaxRates => new TaxRates(this);

        public PurchaseInvoices PurchaseInvoices => new PurchaseInvoices(this);


        public static HttpClient CreateDefaultRestClient(string authorizationToken, string administrationid)
        {
            string version = "v2";
            var client = new HttpClient
            {
                BaseAddress = new Uri($"https://moneybird.com/api/{version}/{administrationid}/")
            };

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authorizationToken}");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            return client;
        }

        public async Task<Result<T>> GetAsync<T>(string url) where T : class
        {
            var result = await Client.GetAsync(url);

            result.EnsureSuccessStatusCode();

            var res = GetResultFromHeaders<T>(result);

            var content = await result.Content.ReadAsStringAsync();

            res.Body = JsonConvert.DeserializeObject<T>(content);

            return res;
        }

        static Result<T> GetResultFromHeaders<T>(HttpResponseMessage result) where T : class
        {
            var res = new Result<T>();

            if (!result.Headers.TryGetValues("Link", out var values))
                return res;

            foreach (var value in values)
            {
                var links = value.Split(',');

                foreach (var entry in links)
                {
                    var match = matchLinkHeader.Match(entry);
                    if (!match.Success) continue;
                    var matchedUrl = match.Groups["url"].Value;
                    var matchedRel = match.Groups["rel"].Value;
                    switch (matchedRel)
                    {
                        case "next":
                            res.Next = matchedUrl;
                            break;
                        case "prev":
                            res.Previous = matchedUrl;
                            break;
                        default:
                            Console.WriteLine($"Invalid rel: {matchedRel} ({matchedUrl})");
                            break;
                    }
                }
            }
            return res;
        }

        /*
        The Moneybird API will always respond with a HTTP status code.This code informs you about the outcome of the API call. The API can return the following HTTP status codes:
        200	OK Request was successful
        201	Created Entity creation was successful
        204	No Content  Entity deletion was successful
        400	Bad request Parameters for the request are missing or malformed. Body contains the errors.
        401	Authorization required  No authorization provided or invalid authorization information provided
        402	Payment Required    Account limit reached
        403	Forbidden IP is blacklisted for API usage, see Throttling information
        404	Not found   Entity not found
        406	Not accepted    The endpoint with this HTTP method is not available in the API
        422	Unprocessable entity    Saving the entity in the database failed due to validation errors.Body contains the errors.
        429	Too many requests See Throttling information
        500	Internal server error Something went wrong while processing the request.This is unexpected behaviour and requires Moneybird to fix the scenario.
        */


        /*
        public Task<T> PutAsync<T>(T data) where T : class
        {
            return Client.PutAsync<T>(data);
        }

        public Task<T> PostAsync<T>(T data) where T : class
        {
            return Client.PostAsync<T>(data);
        }

        public Task<T> DeleteAsync<T>(T data) where T : class
        {
            return Client.DeleteAsync<T>(data);
        }*/
    }

    public class Result<T>
    {
        public T Body { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
    }
}