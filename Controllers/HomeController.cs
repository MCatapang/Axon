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

    public bool Is18orOver(DateTime bday) {
        return bday.AddYears(18) < DateTime.Now ? true : false;
    }




    // ------------------------ Routes: GET

    [HttpGet("/")]
    public IActionResult Home()
    {
        HttpContext.Session.SetObjectAsJson("NavLinks", navLinks);
        HttpContext.Session.SetString("ActiveLink", "Home");
        return View("Home");
    }

    [HttpGet("/register")]
    public IActionResult Register()
    {
        HttpContext.Session.SetString("ActiveLink", "Register");
        return View("Register");
    }

    [HttpGet("/login")]
    public IActionResult Login()
    {
        HttpContext.Session.SetString("ActiveLink", "Login");
        return View("Login");
    }




    // ------------------------ Routes: POST

    [HttpPost("/register")]
    public IActionResult Registering(Employee formData)
    {
        if(!ModelState.IsValid) 
        {
            if(formData.Birthday.ToString() == "1/1/0001") {
                ModelState.AddModelError("Birthday", "Field can't be empty!");
            }
            return View("Register"); 
        }
        return RedirectToAction("Home");
    }

    [HttpPost("/login")]
    public IActionResult LoggingIn(EmployeeLogin formData)
    {
        return RedirectToAction("Home");
    }
}