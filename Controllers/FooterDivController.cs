#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Axon.Models;
namespace Axon.Controllers;

public class FooterDivController : Controller
{
    DashDivController dControl = new DashDivController();

    [HttpGet("/about")]
    public IActionResult About()
    {
        return View("About");
    }

    [HttpGet("/contact")]
    public IActionResult Contact()
    {
        return View("Contact");
    }
}