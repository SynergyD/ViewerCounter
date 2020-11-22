using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewerCounter.DAL.Entities;
using ViewerCounter.Models;
using ViewerCounter.Services;

namespace ViewerCounter.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPageService _pageService;
        private readonly IWebHostEnvironment _environment;

        public HomeController(IWebHostEnvironment environment, ILogger<HomeController> logger, IPageService pageService)
        {
            _logger = logger;
            _pageService = pageService;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Test");
            await _pageService.RegisterView(new View() {UserId = UserId});

            var result = _pageService.GetInfo().Count;

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}