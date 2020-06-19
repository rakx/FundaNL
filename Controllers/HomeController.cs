using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using ComposableAsync;
using FundaNLTask.Models;
using Newtonsoft.Json;

namespace FundaNLTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<PropertyDetails> prop = new List<PropertyDetails>();
            try
            {
                if (ModelState.IsValid)
                {

                    string path = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/ac1b0b1572524640a0ecc54de453ea9f/?type=koop&zo=/amsterdam";

                    var result = APICall(path);

                    if (result.IsSuccessStatusCode)
                    {
                        prop = GetResults(result);
                    }
                    else
                    {
                        prop = null;

                        ModelState.AddModelError(string.Empty, "Server throws error " + result.StatusCode + "");

                    }
                }
            }
            catch(HttpRequestException e)
            {
                ModelState.AddModelError(string.Empty, e.InnerException + e.Message);
            }

        return View(prop);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [NonAction]
        protected HttpResponseMessage APICall(string path)
        {
            Throttle();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(path);

                var responseTask = client.GetAsync(path);

                responseTask.Wait();
                return responseTask.Result;
            }                            

        }

        public List<PropertyDetails> GetResults(HttpResponseMessage responseData)
        {
            RootObject rootObj = new RootObject();
            List<PropertyDetails> prop = new List<PropertyDetails>();

            var readTask = responseData.Content.ReadAsStringAsync().Result;

            rootObj = JsonConvert.DeserializeObject<RootObject>(readTask);

            //Get the top 10 records
            var res = rootObj.objects.GroupBy(x => x.MakelaarId).Select(s => s.ToList()).OrderByDescending(s => s.Count()).ToList().Take(10);

            foreach (var p in res)
            {
                prop.Add(new PropertyDetails { RealEstateAgentName = p[0].MakelaarNaam, PropertyCount = p.Count });
            }
            
            return prop;
        }
        private void Throttle()
        {
            var maxPerPeriod = 100;
            var key = "API request cache";
            var intervalPeriod = 60000;//1 minute
            var sleepInterval = 5000;//period to "sleep" before trying again (if the limits have been reached)
            var recentTransactions = MemoryCache.Default.Count();
            while (recentTransactions >= maxPerPeriod)
            {
                System.Threading.Thread.Sleep(sleepInterval);
                recentTransactions = MemoryCache.Default.Count();
            }
            
            var existing = MemoryCache.Default;
            if (existing != null && existing.Any())
            {
                var counter = 2;
                var last = existing.OrderBy(x => x.Key).Last();
                var pieces = last.Key.Split('_');
                if (pieces.Count() > 2)
                {
                    var lastCount = 0;
                    if (int.TryParse(pieces[2], out lastCount))
                    {
                        counter = lastCount + 1;
                    }
                }               
            }
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMilliseconds(intervalPeriod)
            };
            MemoryCache.Default.Set(key,1, policy);
        }
    }
}