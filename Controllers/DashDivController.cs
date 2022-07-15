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




    // ------------------------ Routes: GET

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        int? employeeID = HttpContext.Session.GetInt32("EmployeeID");
        Employee? employee = _context.Employees
            .FirstOrDefault(e => e.EmployeeID == employeeID);
        if(employee == null)
        {
            return RedirectToAction("Home", "Home");
        }

        HttpContext.Session.SetString("ActiveLink", "Dashboard");
        ViewBag.AllPatients = _context.Patients
            .Where(p => p.Facility == employee.Facility)
            .ToList();
        ViewBag.Shift = _context.Employees
            .Where(e => e.Facility == employee.Facility)
            .ToList();
        return View("/Views/DashDiv/Dashboard.cshtml", employee);
    }

    [HttpGet("/patients")]
    public IActionResult AllPatients()
    {
        int? employeeID = HttpContext.Session.GetInt32("EmployeeID");
        Employee? employee = _context.Employees
            .FirstOrDefault(e => e.EmployeeID == employeeID);
        if(employee == null)
        {
            return RedirectToAction("Home", "HomeController");
        }

        HttpContext.Session.SetString("ActiveLink", "All Patients");
        ViewBag.AllPatients = _context.Patients
            .Where(p => p.Facility == employee.Facility)
            .ToList();

        return View("/Views/DashDiv/AllPatients.cshtml", employee);
    }

    [HttpGet("/patients/{ptID}")]
    public IActionResult OnePatient(int ptID)
    {
        HttpContext.Session.SetString("ActiveLink", "None");
        Patient? patient = _context.Patients
            .FirstOrDefault(p => p.PatientID == ptID);
        return View("/Views/DashDiv/OnePatient.cshtml", patient);
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Home", "Home");
    }
}