using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace lojinha.CartService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookiePolicyController : Controller
    {
        // POST api/cookiePolicy
        [HttpPost]
        public ActionResult CreateConsentCookie()
        {
            var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
            return Json(consentFeature?.CreateConsentCookie());
        }
    }
}
