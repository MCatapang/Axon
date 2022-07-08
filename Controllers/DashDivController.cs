#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Axon.Models;
namespace Axon.Controllers;

public class DashDivController : Controller
{
    private MyContext _context;

    public DashDivController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        int? employeeID = HttpContext.Session.GetInt32("EmployeeID");
        HttpContext.Session.SetString("ActiveLink", "Dashboard");
        Employee? employee = _context.Employees
            .FirstOrDefault(e => e.EmployeeID == employeeID);

        if(employee == null) 
        {
            return RedirectToAction("Home", "HomeController");
        }

        ViewBag.AllPatients = _context.Patients
            .Where(p => p.Facility == employee.Facility)
            .ToList();
        ViewBag.Shift = _context.Employees
            .Where(e => e.Facility == employee.Facility)
            .ToList();
        return View("/Views/DashDiv/Dashboard.cshtml", employee);
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Home", "Home");
    }
}