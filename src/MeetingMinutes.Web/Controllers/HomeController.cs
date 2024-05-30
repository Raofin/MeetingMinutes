using MeetingMinutes.Application.Common;
using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace MeetingMinutes.Web.Controllers;

public class HomeController(ILogger logger, ICustomerService customerService) : Controller
{
    private readonly ILogger _logger = logger;
    private readonly ICustomerService _customerService = customerService;

    [HttpGet]
    public async Task<IActionResult> IndexAsync()
    {
        var landingData = new MeetingViewModel(
            CustomerDDL: await _customerService.GetCustomerAsync(CustomerType.Corporate),
            ProductServiceDDL: await _customerService.GetProductServiceAsync()
        );

        return View(landingData);
    }

    [HttpPost]
    public async Task<IActionResult> IndexAsync(MeetingViewModel model)
    {
        if (ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpGet("api/customers/{type}")]
    public async Task<IActionResult> GetCustomers(CustomerType type)
    {

        var customers = await _customerService.GetCustomerAsync(type);

        return Ok(customers);
    }


}
