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
            return RedirectToAction("Home", "Home");
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
        int? employeeID = HttpContext.Session.GetInt32("EmployeeID");
        Employee? employee = _context.Employees
            .FirstOrDefault(e => e.EmployeeID == employeeID);
        if(employee == null)
        {
            return RedirectToAction("Home", "Home");
        }

        HttpContext.Session.SetString("ActiveLink", "None");
        Patient? patient = _context.Patients
            .FirstOrDefault(p => p.PatientID == ptID);
        ViewBag.ChartEntries = _context.Charts
            .Where(c => c.PatientID == ptID)
            .Include("Employee")
            .ToList();

        return View("/Views/DashDiv/OnePatient.cshtml", patient);
    }

    [HttpGet("/patients/add")]
    public IActionResult AddPatient()
    {
        int? employeeID = HttpContext.Session.GetInt32("EmployeeID");
        Employee? loggedInUser = _context.Employees
            .FirstOrDefault(e => e.EmployeeID == employeeID);
        if(loggedInUser == null)
        {
            return RedirectToAction("Home", "Home");
        }
        ViewBag.Facility = loggedInUser.Facility;

        HttpContext.Session.SetString("ActiveLink", "Add Patient");

        return View("/Views/DashDiv/AddPatient.cshtml");
    }

    [HttpGet("/patients/chart")]
    public IActionResult AddChart(int? ptID)
    {
        int? employeeID = HttpContext.Session.GetInt32("EmployeeID");
        Employee? employee = _context.Employees
            .FirstOrDefault(e => e.EmployeeID == employeeID);
        if(employee == null)
        {
            return RedirectToAction("Home", "Home");
        }

        ViewBag.employeeID = employeeID;
        if(ptID == null)
        {
            ViewBag.PatientOptions = _context.Patients.ToList();
        }
        else
        {
            ViewBag.PatientOptions = _context.Patients
                .Where( p => p.PatientID == ptID)
                .ToList();
        }

        HttpContext.Session.SetString("ActiveLink", "Add Chart");

        return View("/Views/DashDiv/Chart.cshtml");
    }

    [HttpGet("/settings")]
    public IActionResult Settings()
    {
        int? employeeID = HttpContext.Session.GetInt32("EmployeeID");
        Employee? employee = _context.Employees
            .FirstOrDefault(e => e.EmployeeID == employeeID);
        if(employee == null)
        {
            return RedirectToAction("Home", "Home");
        }
        return View("/Views/DashDiv/Settings.cshtml");
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        int? employeeID = HttpContext.Session.GetInt32("EmployeeID");
        Employee? employee = _context.Employees
            .FirstOrDefault(e => e.EmployeeID == employeeID);
        if(employee == null)
        {
            return RedirectToAction("Home", "Home");
        }
        HttpContext.Session.Clear();
        return RedirectToAction("Home", "Home");
    }




    // ------------------------ Routes: POST

    [HttpPost("/patients/{ptID}")]
    public IActionResult Editing(int ptID, Patient formData)
    {
        Patient? ptInDB = _context.Patients
            .FirstOrDefault(p => p.PatientID == ptID);

        if(ptInDB == null || !ModelState.IsValid)
        {
            HttpContext.Session.SetString("anyUpdateError", "yes");
            return View("/Views/DashDiv/OnePatient.cshtml", ptInDB);
        }

        HttpContext.Session.SetString("anyUpdateError", "no");

        ptInDB.FirstName = formData.FirstName;
        ptInDB.LastName = formData.LastName;
        ptInDB.Complaint = formData.Complaint;
        ptInDB.Birthday = formData.Birthday;
        ptInDB.Address = formData.Address;
        ptInDB.EmailAddress = formData.EmailAddress;
        ptInDB.UpdatedAt = DateTime.Now;

        _context.Patients.Update(ptInDB);
        _context.SaveChanges();

        return View("OnePatient", ptInDB);
    }

    [HttpPost("/patients/add")]
    public IActionResult Adding(Patient formData)
    {
        int? employeeID = HttpContext.Session.GetInt32("EmployeeID");

        Patient? ptInDB = _context.Patients
            .FirstOrDefault(p => 
            (
                p.FirstName == formData.FirstName &&
                p.LastName == formData.LastName &&
                p.Birthday == formData.Birthday
            ));
        Employee? loggedInUser = _context.Employees
            .FirstOrDefault(e => e.EmployeeID == employeeID);

        if(ptInDB != null) 
        {
            ModelState.AddModelError("FirstName", "Form entry is a duplicate");
        }
        if(!ModelState.IsValid && loggedInUser != null)
        {
            ViewBag.Facility = loggedInUser.Facility;
            return View("AddPatient");
        }

        _context.Patients.Add(formData);
        _context.SaveChanges();

        Patient? newPt = _context.Patients
            .FirstOrDefault(p => 
            (
                p.FirstName == formData.FirstName &&
                p.LastName == formData.LastName &&
                p.Birthday == formData.Birthday
            ));
        if(newPt == null)
        {
            ModelState.AddModelError("FirstName", "An error was encountered");
            return View("AddPatient");
        }
        return RedirectToAction("OnePatient", new {ptID = newPt.PatientID});
    }

    [HttpPost("/patients/chart")]
    public IActionResult Charting(Chart formData)
    {
        if(!ModelState.IsValid)
        {
            int? employeeID = HttpContext.Session.GetInt32("EmployeeID");
            ViewBag.employeeID = employeeID;
            ViewBag.PatientOptions = _context.Patients
                .Where( p => p.PatientID == formData.PatientID)
                .ToList();
            return View("/Views/DashDiv/Chart.cshtml");
        }

        _context.Charts.Add(formData);
        _context.SaveChanges();

        return RedirectToAction("OnePatient", new {ptID = formData.PatientID});
    }
}