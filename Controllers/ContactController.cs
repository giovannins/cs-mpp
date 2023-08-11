using cs_mpp.Data;
using cs_mpp.Models;
using Microsoft.AspNetCore.Mvc;

namespace cs_mpp.Controllers;

public class ContactController : Controller
{

    private readonly ApplicationDbContext _context;

    public ContactController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Contact contact)
    {
        if (!ModelState.IsValid)
        {
            return View(contact);
        }

        DateTime dateTime = DateTime.Now;
        contact.Create_at = dateTime;

        try
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Os dados de contato foram enviados com sucesso!";
        }
        catch (Exception)
        {
            TempData["FailMessage"] = "Ocorreu um erro ao enviar, tente novamente mais tarde.";
        }

        return RedirectToAction("Index");
    }
}