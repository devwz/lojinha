using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace lojinha.CartService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookiePolicyController : Controller
    {
        // GET api/cart/cookiePolicy
        [HttpGet]
        public ActionResult<bool> CookiePolicy()
        {
            var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
            var showAlert = !consentFeature?.CanTrack ?? false;

            return showAlert;
        }

        // POST api/cart/cookiePolicy
        [HttpPost]
        public ActionResult<string> CreateConsentCookie()
        {
            var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
            // var showAlert = !consentFeature?.CanTrack ?? false;
            var cookieString = consentFeature?.CreateConsentCookie();

            return new JsonResult(cookieString);
        }
    }
}
