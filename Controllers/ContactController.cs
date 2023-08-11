using cs_mpp.Models;
using Microsoft.AspNetCore.Mvc;

namespace cs_mpp.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Contact contact)
    {
        return Ok(contact);
    }
}