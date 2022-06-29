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
    private MyContext _context;

    public HomeController(MyContext context)
    {
        _context = context;
    }

    public bool Is18orOver(DateTime bday) {
        return bday.AddYears(18) < DateTime.Now ? true : false;
    }




    // ------------------------ Routes: GET

    [HttpGet("/")]
    public IActionResult Home()
    {
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
        Console.WriteLine(formData.Birthday.Year);
        Console.WriteLine(formData.Birthday.Year.ToString());
        if(!ModelState.IsValid) 
        {
            return View("Register"); 
        }
        if(formData.Birthday.Year.ToString() == "1") 
        {
            ModelState.AddModelError("Birthday", "Field can't be empty!");
            return View("Register");
        }
        PasswordHasher<Employee> Hasher = new PasswordHasher<Employee>();
        formData.Password = Hasher.HashPassword(formData, formData.Password);
        _context.Employees.Add(formData);
        _context.SaveChanges();
        string hashedSession = Hasher.HashPassword(formData, formData.EmployeeID.ToString());
        Console.WriteLine(hashedSession);
        return RedirectToAction("Home");
    }

    [HttpPost("/login")]
    public IActionResult LoggingIn(EmployeeLogin formData)
    {
        return RedirectToAction("Home");
    }
}