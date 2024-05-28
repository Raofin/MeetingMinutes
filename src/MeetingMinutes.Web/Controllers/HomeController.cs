using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace MeetingMinutes.Web.Controllers;

public class HomeController(ILogger logger) : Controller
{
    private readonly ILogger _logger = logger;

    public IActionResult Index()
    {
        return View();
    }
}
