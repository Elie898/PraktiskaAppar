using Microsoft.AspNetCore.Mvc;
using Northwind.EntityModels;
using NorthwindMvc.Models;

using System.Diagnostics;
namespace NorthwindMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindDatabaseContext db;

    public HomeController(ILogger<HomeController> logger,
         NorthwindDatabaseContext injectedContext)
    {
        _logger = logger;
        db = injectedContext;
    }

    public IActionResult Index()
    {

        HomeIndexViewModel model = new(

            VisitorCount: Random.Shared.Next(1, 1001),
            Categories: db.Categories.ToList(),
            Products: db.Products.ToList()

        );

        return View(model);


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
