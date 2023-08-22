using cs_mpp.Data;
using cs_mpp.Models;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> List()
    {
        List<Product> products = await _context.Products.ToListAsync();
        products.ForEach(product => product.Image = GetOnlyTheFirstImage(product.Image));
        return View(products);
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(long id)
    {
        Product product = await _context.Products.FirstOrDefaultAsync(predicate: predicate => predicate.Id == id);
        string[] imgList = product.Image.Split('|');
        ViewBag.imgList = imgList;
        return View(product);
    }

    [HttpPost]
    public IActionResult Upload(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imgs", "upload");
            string filePath = Path.Combine(uploadPath, file.FileName);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Content("Arquivo carregado e salvo com sucesso.");
        }
        else
        {
            return Content("Nenhum arquivo foi carregado.");
        }
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