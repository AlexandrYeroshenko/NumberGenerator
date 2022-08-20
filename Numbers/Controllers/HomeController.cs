using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Numbers.Hubs;
using Numbers.Interfaces;
using Numbers.Models;
using System.Diagnostics;

namespace Numbers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManagerAPI _apiManager;
        private readonly ISignalRManager _signalrManager;

        public HomeController(IManagerAPI apiManager, ISignalRManager signalrManager)
        {
            _apiManager = apiManager;
            _signalrManager = signalrManager;
        }

        public IActionResult Index()
        {
            _signalrManager.StartTimer();
            return View();
        }

        public Task<int> GetRandomNumber()
        {
            return _apiManager.GetRandomNumberAsync();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}