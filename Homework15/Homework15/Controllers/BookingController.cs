using System.Text.Json;
using Homework15.Models;
using Microsoft.AspNetCore.Mvc;
using IOFile = System.IO.File;

namespace Homework15.Controllers;

public class BookingController : Controller
{
    private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "appointments.json");

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Appointment model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        List<Appointment> appointments = new();

        if (IOFile.Exists(_filePath))
        {
            string existingJson = IOFile.ReadAllText(_filePath);

            if (!string.IsNullOrWhiteSpace(existingJson))
            {
                appointments = JsonSerializer.Deserialize<List<Appointment>>(existingJson) ?? new List<Appointment>();
            }
        }
    
    
    appointments.Add(model);
    
    string updatedJson = JsonSerializer.Serialize(appointments, new JsonSerializerOptions{WriteIndented = true});
        IOFile.WriteAllText(_filePath, updatedJson);
        
    return RedirectToAction("List");
}

[HttpGet]
public IActionResult List()
{
    List<Appointment> appointments = new();

    if (IOFile.Exists(_filePath))
    {
        string json = IOFile.ReadAllText(_filePath);
        if (!string.IsNullOrWhiteSpace(json))
        {
            appointments = JsonSerializer.Deserialize<List<Appointment>>(json) ?? new List<Appointment>();
        }
    }

    return View(appointments);
}}