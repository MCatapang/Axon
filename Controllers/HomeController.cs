#pragma warning disable
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Axon.Models;
namespace Axon.Controllers;

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
        if(HttpContext.Session.GetInt32("EmployeeID") != null)
        {
            HttpContext.Session.SetString("ActiveLink", "Dashboard");
            return View("Dashboard");
        }
        HttpContext.Session.SetString("ActiveLink", "Home");
        return View("Home");
    }

    [HttpGet("/register")]
    public IActionResult Register()
    {
        ViewBag.AllRoles = _context.Roles.ToList();
        ViewBag.AllFacilities = _context.Facilities.ToList();

        if(HttpContext.Session.GetInt32("EmployeeID") != null) 
        {
            Console.WriteLine("hitting the conditional");
            return RedirectToAction("Home");
        }
        HttpContext.Session.SetString("ActiveLink", "Register");


        return View("Register");
    }

    [HttpGet("/login")]
    public IActionResult Login()
    {
        if(HttpContext.Session.GetInt32("EmployeeID") != null) 
        {
            return RedirectToAction("Home");
        }
        HttpContext.Session.SetString("ActiveLink", "Login");
        return View("Login");
    }




    // ------------------------ Routes: POST

    [HttpPost("/register")]
    public IActionResult Registering(Employee formData)
    {
        bool emptyBDay = ModelState["Birthday"].AttemptedValue == "";
        bool under18 = formData.Birthday.AddYears(18) > DateTime.Now;

        if(emptyBDay)
        {
            ModelState["Birthday"].Errors.Clear();
            ModelState["Birthday"].Errors.Add("Field can't be empty!");
        }
        if(under18) 
        {
            ModelState.AddModelError("Birthday", "Must be at least 18 years old!");
        }
        if(!ModelState.IsValid || emptyBDay || under18) 
        {
            ViewBag.AllRoles = _context.Roles.ToList();
            ViewBag.AllFacilities = _context.Facilities.ToList();
            return View("Register"); 
        }

        PasswordHasher<Employee> Hasher = new PasswordHasher<Employee>();
        formData.Password = Hasher.HashPassword(formData, formData.Password);
        _context.Employees.Add(formData);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("EmployeeID", formData.EmployeeID);

        return RedirectToAction("Home");
    }

    [HttpPost("/login")]
    public IActionResult LoggingIn(EmployeeLogin formData)
    {
        Employee retrieved = _context.Employees
            .FirstOrDefault(e => e.EmailAddress == formData.EmailLogin);
        if(retrieved == null)
        {
            ModelState.AddModelError("EmailLogin", "Invalid Email/Password");
            ModelState.AddModelError("PasswordLogin", "Invalid Email/Password");
            return View("Login");
        }
        HttpContext.Session.SetInt32("EmployeeID", retrieved.EmployeeID);
        return RedirectToAction("Home");
    }
}