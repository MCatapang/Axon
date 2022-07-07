#pragma warning disable CS8618
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using SendGrid;
using Axon.Models;
namespace Axon.Controllers;

public class FooterDivController : Controller
{
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

    [HttpPost("/contact")]
    public async Task<IActionResult> Contacting(Contact formData)
    {
        if(!ModelState.IsValid)
        {
            return View("Contact");
        }
        var apiKey = Environment.GetEnvironmentVariable("SendGridKey");
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("maocataptest@gmail.com", "Axon"),
            Subject = "Contact Form",
            PlainTextContent = $"Sender: {formData.FullName} \nSender Email: {formData.EmailAddress} \nMessage: {formData.Message}"
        };
        msg.AddTo(new EmailAddress("maocataptest@gmail.com", "TEST Michael Catapang"));
        var response = await client.SendEmailAsync(msg);
        if(!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("Message", "There was trouble sending your message");
            return View("Contact");
        }
        return RedirectToAction("Home", "Home");
    }
}