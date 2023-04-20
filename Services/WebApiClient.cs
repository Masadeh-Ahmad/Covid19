
using Covid.Models;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Covid.Services
{
    public class WebApiClient : IWebApiClient
    {
        private readonly IConfiguration configuration;

        public WebApiClient(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<T> GetAsync<T>(string endpoint,object queryParams)
        {
            if (endpoint is null) { return default(T); }

            var baseUrl = configuration.GetValue<string>("baseURL");
            var s = baseUrl.AppendPathSegment(endpoint);
            return await baseUrl.AppendPathSegment(endpoint).SetQueryParams(queryParams).GetJsonAsync<T>().ConfigureAwait(false);
        }
      
    }
}
