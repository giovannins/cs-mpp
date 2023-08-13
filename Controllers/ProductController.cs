using cs_mpp.Data;
using cs_mpp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cs_mpp.Controllers;

public class ProductController : Controller
{

    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Product> products = await _context.Products.ToListAsync();
        products.ForEach(product => product.Image = GetOnlyTheFirstImage(product.Image));
        return View(products);
    }

    public async Task<IActionResult> View(long id)
    {
        Product product = await _context.Products.FirstOrDefaultAsync(predicate: predicate => predicate.Id == id);
        string[] imgList = product.Image.Split('|');
        ViewBag.imgList = imgList;
        return View(product);
    }


    // Funções de produtos

    private static string GetOnlyTheFirstImage(string Images)
    {
        string[] urls = Images.Split('|');
        if (urls.Length == 0)
        {
            return "";
        }
        return urls[0];
    }
}