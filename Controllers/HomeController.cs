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
        int? employeeID = HttpContext.Session.GetInt32("EmployeeID");
        if(employeeID != null)
        {
            return RedirectToAction("Dashboard", "DashDiv");
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
        if(!ModelState.IsValid)
        {
            ViewBag.AllRoles = _context.Roles.ToList();
            ViewBag.AllFacilities = _context.Facilities.ToList();
            return View("Register");
        }

        DateTime bDayConvert = (DateTime)formData.Birthday;

        bool emptyBDay = ModelState["Birthday"].AttemptedValue == "";
        bool under18 = bDayConvert.AddYears(18) > DateTime.Now;
        bool emailInDB = null != _context.Employees
            .FirstOrDefault(e => e.EmailAddress == formData.EmailAddress);

        if(emptyBDay)
        {
            ModelState["Birthday"].Errors.Clear();
            ModelState["Birthday"].Errors.Add("Field can't be empty!");
        }
        if(under18) 
        {
            ModelState.AddModelError("Birthday", "Must be at least 18 years old!");
        }
        if(emailInDB)
        {
            ModelState.AddModelError("EmailAddress", "Email is already in use!");
        }
        if(emptyBDay || under18 || emailInDB) 
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

        PasswordHasher<Employee> Hasher = new PasswordHasher<Employee>();
        PasswordVerificationResult result = Hasher
            .VerifyHashedPassword(retrieved, retrieved.Password, formData.PasswordLogin);
        if(result == 0)
        {
            ModelState.AddModelError("EmailLogin", "Invalid Email/Password");
            ModelState.AddModelError("PasswordLogin", "Invalid Email/Password");
            return View("Login");
        }

        HttpContext.Session.SetInt32("EmployeeID", retrieved.EmployeeID);
        return RedirectToAction("Home");
    }
}