using System;
using ServiceStack;
using ServiceStack.Common;

namespace MoneyHawk.Core
{
    public class MoneyBirdApi : IMoneyBirdApi
    {
        private readonly ServiceClientBase client;

        public MoneyBirdApi(string subDomain, string username, string password)
            : this(CreateDefaultRestClient(subDomain, username, password))
        {
        }

        /*
                public MoneyBirdApi(string subDomain, string accessToken)
                    : this(CreateAuthRestClient(subDomain, accessToken))
                {
                }
*/
        public MoneyBirdApi(ServiceClientBase client)
        {
            this.client = client;
        }

        private static ServiceClientBase CreateDefaultRestClient(string subDomain, string username, string password)
        {
            var client = new JsonServiceClient(string.Format("https://{0}.moneybird.nl/api/v1.0", subDomain))
            {
                AlwaysSendBasicAuthHeader = true,
            };

            client.SetCredentials(username, password);

            return client;
        }

        /*private static RestClient CreateAuthRestClient(string subDomain, string accessToken)
        {
            //return new RestClient { BaseUrl = "https://" + subDomain + ".moneybird.nl/api/v1.0", Authenticator = new OAuth1Authenticator(){} };
            return new RestClient { BaseUrl = "https://" + subDomain + ".moneybird.nl/api/v1.0", Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken) };
        }

        private static RestClient CreateAuthRestClient(string subDomain, string accessToken)
        {
            //return new RestClient { BaseUrl = "https://" + subDomain + ".moneybird.nl/api/v1.0", Authenticator = new OAuth1Authenticator(){} };
            return new RestClient { BaseUrl = "https://" + subDomain + ".moneybird.nl/api/v1.0", Authenticator = new OAuth2UriQueryParameterAuthenticator(accessToken) };
        }
*/

        public InvoiceDataSource Invoices 
        {
            get 
            {
                return new InvoiceDataSource(this);
            }
        }

        public LedgerAccountDataSource LedgerAccounts 
        {
            get 
            {
                return new LedgerAccountDataSource(this);
            }
        }

        public IncomingInvoicesDataSource IncomingInvoices
        {
            get 
            {
                return new IncomingInvoicesDataSource(this);
            }
        }

        public ContactDataSource Contacts
        {
            get
            {
                return new ContactDataSource(this);
            }
        }

        public T Get<T>(string url) where T : class
        {
            return client.Get<T>(url);
        }

        public T Put<T>(string url, T data) where T : class
        {
            return client.Put<T>(data);
        }

        public T Post<T>(string url, T data) where T : class
        {
            return client.Post<T>(data);
        }

        public T Delete<T>(string url, T data) where T : class
        {
            return client.Delete<T>(url);
        }

        //TODO: response handling, copied directly from the MoneyBirdPHP API, however, most of these status codes are already handled in the .NET/REST stack:
        //https://github.com/bluetools/moneybird_php_api/blob/master/Api.php
        /*switch ($httpresponse) {
            case 100: // Continue
            case 200: // OK		 Request was successful
            case 201: // Created 	Entity was created successful
                break;

            case 401: // Authorization required	 No authorization information provided with request
                $error = new MoneybirdAuthorizationRequiredException('No authorization information provided with request');
                break;

            case 403: // Forbidden request
                $error = new MoneybirdForbiddenException('Forbidden request');
                break;

            case 404: // The entity or action is not found in the API
                $error = new MoneybirdItemNotFoundException('The entity or action is not found in the API');
                break;

            case 406: // Not accepted			   The action you are trying to perform is not available in the API
                $error = new MoneybirdNotAcceptedException('The action you are trying to perform is not available in the API');
                break;

            case 422: // Unprocessable entity	   Entity was not created because of errors in parameters. Errors are included in XML response.
                $error = new MoneybirdUnprocessableEntityException('Entity was not created or deleted because of errors in parameters. Errors are included in XML response.');
                break;

            case 500: // Internal server error	  Something went wrong while processing the request. MoneyBird is notified of the error.
                $error = new MoneybirdInternalServerErrorException('Something went wrong while processing the request. MoneyBird is notified of the error.');
                break;

            default:
                $error = new MoneybirdUnknownResponseException('Unknown response from Moneybird: ' . $httpresponse);
                break;
        }
*/
    }
}