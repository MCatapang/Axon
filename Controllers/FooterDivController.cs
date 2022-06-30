#pragma warning disable CS8618
using Microsoft.AspNetCore.Mvc;
// Below added using these instructions:
// https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-6.0&tabs=netcore-cli
using Microsoft.AspNetCore.Identity.UI.Services;
using Axon.Models;
namespace Axon.Controllers;

public class FooterDivController : Controller
{
    private readonly IEmailSender _emailSender;

    public FooterDivController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpGet("/about")]
    public IActionResult About()
    {
        HttpContext.Session.SetString("ActiveLink", "About");
        return View("About");
    }

    [HttpGet("/contact")]
    public IActionResult Contact()
    {
        HttpContext.Session.SetString("ActiveLink", "Contact");
        return View("Contact");
    }

    // [HttpPost("/contact")]
    // public Task<IActionResult> Contacting(Contact formData)
    // {
    //     return;
    // }
}