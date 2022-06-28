#pragma warning disable
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Axon.Models;

public class HomeController : Controller
{
    // ------------------------ Routes: GET

    [HttpGet("/")]
    public IActionResult Home()
    {
        return View("Home");
    }

    [HttpGet("/register")]
    public IActionResult Register()
    {
        return View("Register");
    }

    [HttpGet("/login")]
    public IActionResult Login()
    {
        return View("Login");
    }




    // ------------------------ Routes: POST

    [HttpPost("/register")]
    public IActionResult Registering(Employee formData)
    {
        return RedirectToAction("Home");
    }

    [HttpPost("/login")]
    public IActionResult LoggingIn(EmployeeLogin formData)
    {
        return RedirectToAction("Home");
    }
}