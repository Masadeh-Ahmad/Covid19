using Covid.Models;
using Covid.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covid.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly IWebApiClient webApiClient;
        private const string Endpoint = "world/total";
        private string SearchEndpoint;

        [BindProperty]
        public SearchForm SearchForm { get; set; }
        public TotalCases TotalCases { get; set; }
        public List<SearchedCountry> SearchedCountries { get; set; }

        public IndexModel(IWebApiClient webApiClient)
        {
            this.webApiClient = webApiClient;
        }
        public async Task<IActionResult> OnGetAsync(List<SearchedCountry> searchedCountries)
        {
            SearchedCountries = searchedCountries;
            try
            {
                TotalCases = await this.webApiClient.GetAsync<TotalCases>(Endpoint, null).ConfigureAwait(false);
            }
            catch { }
            
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string country = SearchForm.CountryName.Replace(" ", "-").ToLower();
            var queryParams = new
            {
                from = SearchForm.StartData.ToString("yyyy-MM-dd"),
                to = SearchForm.EndData.ToString("yyyy-MM-dd")
            };
            SearchEndpoint = "country/" + country + "/status/confirmed";
            try { 
                SearchedCountries = await this.webApiClient.GetAsync<List<SearchedCountry>>(SearchEndpoint, queryParams).ConfigureAwait(false);
            }catch { }
            
            return await OnGetAsync(SearchedCountries);
        }
    }
}
