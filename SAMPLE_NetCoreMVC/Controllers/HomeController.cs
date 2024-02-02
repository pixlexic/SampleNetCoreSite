using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_NetCoreMVC.Models;

namespace SAMPLE_NetCoreMVC.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        dynamic VWModel = new ExpandoObject();
        VWModel.BaseVM = this.BaseVM;
        return View(VWModel);
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

