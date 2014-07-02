using System.IO;
using System.Linq;
using System;
using System.Net;
using System.Threading.Tasks;
using ServiceStack;

namespace MoneyHawk.Web.Controllers
{
    using MoneyHawk.Core;

    public class CachedMoneyBirdApi : IMoneyBirdApi
    {
        private readonly IServiceClient cachedClient;

        public CachedMoneyBirdApi(IServiceClient cachedClient)
        {
            this.cachedClient = new CachedServiceClient(cachedClient);
        }

        public InvoiceDataSource Invoices
        {
            get
            {
                return new InvoiceDataSource(cachedClient);
            }
        }

        public LedgerAccountDataSource LedgerAccounts
        {
            get
            {
                return new LedgerAccountDataSource(cachedClient);
            }
        }

        public IncomingInvoicesDataSource IncomingInvoices
        {
            get
            {
                return new IncomingInvoicesDataSource(cachedClient);
            }
        }

        public ContactDataSource Contacts
        {
            get
            {
                return new ContactDataSource(cachedClient);
            }
        }
    }

    public class CachedServiceClient : IServiceClient
    {
        private readonly IServiceClient cachedClient;
        private readonly Cache cache;

        public CachedServiceClient(IServiceClient cachedClient)
        {
            this.cachedClient = cachedClient;
            this.cache = new Cache();
        }

        public void Dispose()
        {
            cachedClient.Dispose();
        }

        public void SetCredentials(string userName, string password)
        {
            cachedClient.SetCredentials(userName, password);
        }

        public Task<TResponse> GetAsync<TResponse>(IReturn<TResponse> requestDto)
        {
            return cachedClient.GetAsync(requestDto);
        }

        public Task<TResponse> GetAsync<TResponse>(object requestDto)
        {
            return cachedClient.GetAsync<TResponse>(requestDto);
        }

        public Task<TResponse> GetAsync<TResponse>(string relativeOrAbsoluteUrl)
        {
            return cachedClient.GetAsync<TResponse>(relativeOrAbsoluteUrl);
        }

        public Task<HttpWebResponse> GetAsync(IReturnVoid requestDto)
        {
            return cachedClient.GetAsync(requestDto);
        }

        public Task<TResponse> DeleteAsync<TResponse>(IReturn<TResponse> requestDto)
        {
            return cachedClient.DeleteAsync(requestDto);
        }

        public Task<TResponse> DeleteAsync<TResponse>(object requestDto)
        {
            return cachedClient.DeleteAsync<TResponse>(requestDto);
        }

        public Task<TResponse> DeleteAsync<TResponse>(string relativeOrAbsoluteUrl)
        {
            return cachedClient.DeleteAsync<TResponse>(relativeOrAbsoluteUrl);
        }

        public Task<HttpWebResponse> DeleteAsync(IReturnVoid requestDto)
        {
            return cachedClient.DeleteAsync(requestDto);
        }

        public Task<TResponse> PostAsync<TResponse>(IReturn<TResponse> requestDto)
        {
            return cachedClient.PostAsync(requestDto);
        }

        public Task<TResponse> PostAsync<TResponse>(object requestDto)
        {
            return cachedClient.PostAsync<TResponse>(requestDto);
        }

        public Task<TResponse> PostAsync<TResponse>(string relativeOrAbsoluteUrl, object request)
        {
            return cachedClient.PostAsync<TResponse>(relativeOrAbsoluteUrl, request);
        }

        public Task<HttpWebResponse> PostAsync(IReturnVoid requestDto)
        {
            return cachedClient.PostAsync(requestDto);
        }

        public Task<TResponse> PutAsync<TResponse>(IReturn<TResponse> requestDto)
        {
            return cachedClient.PutAsync(requestDto);
        }

        public Task<TResponse> PutAsync<TResponse>(object requestDto)
        {
            return cachedClient.PutAsync<TResponse>(requestDto);
        }

        public Task<TResponse> PutAsync<TResponse>(string relativeOrAbsoluteUrl, object request)
        {
            return cachedClient.PutAsync<TResponse>(relativeOrAbsoluteUrl, request);
        }

        public Task<HttpWebResponse> PutAsync(IReturnVoid requestDto)
        {
            return cachedClient.PutAsync(requestDto);
        }

        public Task<TResponse> CustomMethodAsync<TResponse>(string httpVerb, IReturn<TResponse> requestDto)
        {
            return cachedClient.CustomMethodAsync(httpVerb, requestDto);
        }

        public Task<TResponse> CustomMethodAsync<TResponse>(string httpVerb, object requestDto)
        {
            return cachedClient.CustomMethodAsync<TResponse>(httpVerb, requestDto);
        }

        public Task<HttpWebResponse> CustomMethodAsync(string httpVerb, IReturnVoid requestDto)
        {
            return cachedClient.CustomMethodAsync(httpVerb, requestDto);
        }

        public void CancelAsync()
        {
            cachedClient.CancelAsync(); 
        }

        public Task<TResponse> SendAsync<TResponse>(object requestDto)
        {
            return cachedClient.SendAsync<TResponse>(requestDto);
        }

        public void SendOneWay(object requestDto)
        {
            cachedClient.SendOneWay(requestDto);
        }

        public void SendOneWay(string relativeOrAbsoluteUrl, object request)
        {
            cachedClient.SendOneWay(relativeOrAbsoluteUrl, request);
        }

        public HttpWebResponse Get(IReturnVoid request)
        {
            return cachedClient.Get(request);
        }

        public HttpWebResponse Get(object request)
        {
            return cachedClient.Get(request);
        }

        public TResponse Get<TResponse>(IReturn<TResponse> requestDto)
        {
            return cachedClient.Get(requestDto);
        }

        public TResponse Get<TResponse>(object requestDto)
        {
            return cachedClient.Get<TResponse>(requestDto);
        }

        public TResponse Get<TResponse>(string relativeOrAbsoluteUrl)
        {
            return cache.GetOrAdd(relativeOrAbsoluteUrl, () => cachedClient.Get<TResponse>(relativeOrAbsoluteUrl));
        }

        public HttpWebResponse Delete(IReturnVoid requestDto)
        {
            return cachedClient.Delete(requestDto);
        }

        public HttpWebResponse Delete(object requestDto)
        {
            return cachedClient.Delete(requestDto);
        }

        public TResponse Delete<TResponse>(IReturn<TResponse> request)
        {
            return cachedClient.Delete(request);
        }

        public TResponse Delete<TResponse>(object request)
        {
            return cachedClient.Delete<TResponse>(request);
        }

        public TResponse Delete<TResponse>(string relativeOrAbsoluteUrl)
        {
            return cachedClient.Delete<TResponse>(relativeOrAbsoluteUrl);
        }

        public HttpWebResponse Post(IReturnVoid requestDto)
        {
            return cachedClient.Post(requestDto);
        }

        public HttpWebResponse Post(object requestDto)
        {
            return cachedClient.Post(requestDto);
        }

        public TResponse Post<TResponse>(IReturn<TResponse> requestDto)
        {
            return cachedClient.Post(requestDto);
        }

        public TResponse Post<TResponse>(object requestDto)
        {
            return cachedClient.Post<TResponse>(requestDto);
        }

        public TResponse Post<TResponse>(string relativeOrAbsoluteUrl, object request)
        {
            return cachedClient.Post<TResponse>(relativeOrAbsoluteUrl, request);
        }

        public HttpWebResponse Put(IReturnVoid requestDto)
        {
            return cachedClient.Put(requestDto);
        }

        public HttpWebResponse Put(object requestDto)
        {
            return cachedClient.Put(requestDto);
        }

        public TResponse Put<TResponse>(IReturn<TResponse> requestDto)
        {
            return cachedClient.Put(requestDto);
        }

        public TResponse Put<TResponse>(object requestDto)
        {
            return cachedClient.Put<TResponse>(requestDto);
        }

        public TResponse Put<TResponse>(string relativeOrAbsoluteUrl, object requestDto)
        {
            return cachedClient.Put<TResponse>(relativeOrAbsoluteUrl, requestDto);
        }

        public HttpWebResponse Patch(IReturnVoid requestDto)
        {
            return cachedClient.Patch(requestDto);
        }

        public HttpWebResponse Patch(object requestDto)
        {
            return cachedClient.Patch(requestDto);
        }

        public TResponse Patch<TResponse>(IReturn<TResponse> requestDto)
        {
            return cachedClient.Patch(requestDto);
        }

        public TResponse Patch<TResponse>(object requestDto)
        {
            return cachedClient.Patch<TResponse>(requestDto);
        }

        public TResponse Patch<TResponse>(string relativeOrAbsoluteUrl, object requestDto)
        {
            return cachedClient.Patch<TResponse>(relativeOrAbsoluteUrl, requestDto);
        }

        public HttpWebResponse CustomMethod(string httpVerb, IReturnVoid requestDto)
        {
            return cachedClient.CustomMethod(httpVerb, requestDto);
        }

        public HttpWebResponse CustomMethod(string httpVerb, object requestDto)
        {
            return cachedClient.CustomMethod(httpVerb, requestDto);
        }

        public TResponse CustomMethod<TResponse>(string httpVerb, IReturn<TResponse> requestDto)
        {
            return cachedClient.CustomMethod(httpVerb, requestDto);
        }

        public TResponse CustomMethod<TResponse>(string httpVerb, object requestDto)
        {
            return cachedClient.CustomMethod<TResponse>(httpVerb, requestDto);
        }

        public HttpWebResponse Head(IReturn requestDto)
        {
            return cachedClient.Head(requestDto);
        }

        public HttpWebResponse Head(object requestDto)
        {
            return cachedClient.Head(requestDto);
        }

        public HttpWebResponse Head(string relativeOrAbsoluteUrl)
        {
            return cachedClient.Head(relativeOrAbsoluteUrl);
        }

        public TResponse PostFile<TResponse>(string relativeOrAbsoluteUrl, FileInfo fileToUpload, string mimeType)
        {
            return cachedClient.PostFile<TResponse>(relativeOrAbsoluteUrl, fileToUpload, mimeType);
        }

        public TResponse PostFile<TResponse>(string relativeOrAbsoluteUrl, Stream fileToUpload, string fileName, string mimeType)
        {
            return cachedClient.PostFile<TResponse>(relativeOrAbsoluteUrl, fileToUpload, fileName, mimeType);
        }

        public TResponse PostFileWithRequest<TResponse>(Stream fileToUpload, string fileName, object request,
            string fieldName = "upload")
        {
            return cachedClient.PostFileWithRequest<TResponse>(fileToUpload, fileName, request, fieldName);
        }

        public TResponse PostFileWithRequest<TResponse>(string relativeOrAbsoluteUrl, FileInfo fileToUpload, object request,
            string fieldName = "upload")
        {
            return cachedClient.PostFileWithRequest<TResponse>(relativeOrAbsoluteUrl, fileToUpload, request, fieldName);
        }

        public TResponse PostFileWithRequest<TResponse>(string relativeOrAbsoluteUrl, Stream fileToUpload, string fileName,
            object request, string fieldName = "upload")
        {
            return cachedClient.PostFileWithRequest<TResponse>(relativeOrAbsoluteUrl, fileToUpload, fileName, request, fieldName);
        }

        public TResponse Send<TResponse>(object request)
        {
            return cachedClient.Send<TResponse>(request);
        }

        public TResponse Send<TResponse>(IReturn<TResponse> request)
        {
            return cachedClient.Send(request);
        }

        public void Send(IReturnVoid request)
        {
            cachedClient.Send(request);
        }
    }
}