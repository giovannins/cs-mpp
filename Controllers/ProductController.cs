using Microsoft.AspNetCore.Mvc;

namespace cs_mpp.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}