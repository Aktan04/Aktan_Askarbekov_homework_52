using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PhoneProject.Models;

namespace PhoneProject.Controllers;

public class PhoneController : Controller
{
    private MobileContext _db;
    private readonly IWebHostEnvironment _env; 

    public PhoneController(MobileContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }
    
    // GET
    public IActionResult Index()
    {
        List<Phone> phones = _db.Phones.ToList();
        return View(phones);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Phone phone)
    {
        if (phone != null)
        {
            _db.Phones.Add(phone);
            _db.SaveChanges();
        }
        
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int phoneId)
    {
        if (phoneId != null)
        {
            Phone phone = _db.Phones.FirstOrDefault(p => p.Id == phoneId);
            if (phone != null)
            {
                return View(phone);
            }
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Edit(Phone phone)
    {
        if (phone != null)
        {
            _db.Phones.Update(phone);
            _db.SaveChanges();
        }
        
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int phoneId)
    {
        if (phoneId != null)
        {
            Phone phone = _db.Phones.FirstOrDefault(p => p.Id == phoneId);
            if (phone != null)
            {
                return View(phone);
            }
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult ConfirmDelete(int phoneId)
    {
        if (phoneId != null)
        {
            Phone phone = _db.Phones.FirstOrDefault(p => p.Id == phoneId);
            if (phone != null)
            {
                _db.Phones.Remove(phone);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        return NotFound();
    }
    
    public IActionResult Details(int id)
    {
        
        var product = _db.Phones.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        List<Currency> currencies;

        string jsonFilePath = Path.Combine(_env.WebRootPath, "currencies.json");

        currencies = JsonSerializer.Deserialize<List<Currency>>(System.IO.File.ReadAllText(jsonFilePath));

        ViewBag.Currencies = currencies;
        
        return View(product);

    }
}