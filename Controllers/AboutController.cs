using Microsoft.AspNetCore.Mvc;

namespace cs_mpp.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}