using Covid.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Controllers
{
    public class Records : Controller
    {
        private readonly CovidDbContext context;

        public Records(CovidDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Models.Records> records = await context.records.ToListAsync();
            return View(records);
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            try
            {
                var record =  context.records.SingleOrDefault(c => c.Id == id);

                if (record != null)
                {
                    context.records.Remove(record);

                    context.SaveChanges();
                }
            }
            catch { }
            return RedirectToAction("Index");
        }
    }
}
