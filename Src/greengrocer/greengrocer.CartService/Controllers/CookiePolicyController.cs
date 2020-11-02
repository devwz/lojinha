using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace greengrocer.CartService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookiePolicyController : Controller
    {
        // POST api/cookiePolicy
        [HttpPost]
        public string CreateCookie()
        {
            // var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
            // return Json(consentFeature?.CreateConsentCookie());
            return ".AspNet.Consent=yes; expires=Fri, 06 Aug 2021 03:47:31 GMT; path=/; SameSite=None; Secure";
        }
    }
}
