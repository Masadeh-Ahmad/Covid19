using Covid.Models;
using System.Threading.Tasks;

namespace Covid.Services
{
    public interface IWebApiClient
    {
        Task<T> GetAsync<T>(string endpoint,object queryParams);
    }
}