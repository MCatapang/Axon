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
    Dictionary<string, string> navLinks = new Dictionary<string, string>()
    {
        {"Home", "/"},
        {"Register", "/register"},
        {"Login", "/login"}
    };
    // ------------------------ Routes: GET

    [HttpGet("/")]
    public IActionResult Home()
    {
        ViewBag.NavLinks = navLinks;
        ViewBag.ActivePage = "Home";
        return View("Home");
    }

    [HttpGet("/register")]
    public IActionResult Register()
    {
        ViewBag.NavLinks = navLinks;
        ViewBag.ActivePage = "Register";
        return View("Register");
    }

    [HttpGet("/login")]
    public IActionResult Login()
    {
        ViewBag.NavLinks = navLinks;
        ViewBag.ActivePage = "Login";
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