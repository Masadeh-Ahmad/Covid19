using Covid.Data;

using Covid.Models;
using Covid.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Controllers
{
    public class AllCountries : Controller
    {
        private readonly IWebApiClient webApiClient;
        private readonly CovidDbContext context;
        private const string Endpoint = "summary";
        private static Summary data;

        public AllCountries(IWebApiClient webApiClient, CovidDbContext context)
        {
            this.webApiClient = webApiClient;
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                data = await webApiClient.GetAsync<Summary>(Endpoint, null);
                return View(data.Countries.ToList<Country>());
            }
            catch {
                return RedirectToAction("Index","Home");
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddOne(string id)
        {
            Country country = data.Countries.ToList<Country>().Where(x => x.ID == id).FirstOrDefault();
            if(country != null)
            {
                try
                {
                    await context.records.AddAsync(new Models.Records()
                    {
                        CountryId = id,
                        Name = country.CountryName,
                        Date = country.Date
                    });
                    context.SaveChanges();
                }
                catch 
                { }
                
            }

            return RedirectToAction("Index");
        }
    }
}
