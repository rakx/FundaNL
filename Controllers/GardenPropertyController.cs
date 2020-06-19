using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using FundaNLTask.Models;

namespace FundaNLTask.Controllers
{
    public class GardenPropertyController : HomeController
    {
        // GET: GardenProperty
        public ActionResult GardenProperties()
        {
            List<PropertyDetails> prop = new List<PropertyDetails>();
            try
            {
                if (ModelState.IsValid)
                {
                    string path = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/ac1b0b1572524640a0ecc54de453ea9f/?type=koop&zo=/amsterdam/tuin";

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
            
            
            return View("/Views/Home/Index.cshtml", prop);
        }
    }
}