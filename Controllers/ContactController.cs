using Microsoft.AspNetCore.Mvc;

namespace cs_mpp.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}