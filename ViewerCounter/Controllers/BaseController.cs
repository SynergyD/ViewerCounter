using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ViewerCounter.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string UserId => HttpContext
            .User?
            .Claims?
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
            .Value ?? Guid.NewGuid().ToString();
    }
}