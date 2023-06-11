using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcUzmovi.Models;

namespace MvcUzmovi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        
    }

    public IActionResult Index()
    {
        string user_agent = HttpContext.Request.Headers.UserAgent.ToString();
        string ip = HttpContext.Connection.RemoteIpAddress.ToString();
        ViewData["info"]=user_agent+ip;
        return View();
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
