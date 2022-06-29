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
        if(ModelState["Birthday"].AttemptedValue == "")
        {
            ModelState["Birthday"].Errors.Clear();
            ModelState["Birthday"].Errors.Add("Field can't be empty!");
            return View("Register");
        }
        if(formData.Birthday.AddYears(18) > DateTime.Now) 
        {
            ModelState.AddModelError("Birthday", "Must be at least 18 years old!");
            return View("Register");
        }
        if(!ModelState.IsValid) 
        {
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