using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class CategoriesController : Controller
{
    // GET
    public IActionResult Index()
    {
        var categories = CategoriesRepo.GetCategories();
        return View(categories);
    }
    
    public IActionResult Edit(int? id)
    {
        ViewBag.Action = "Edit";
        
        var category = CategoriesRepo.GetCategoryById(id.HasValue?id.Value:0);
        
        return View(category);
    }
    
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            CategoriesRepo.UpdateCategory(category.CategoryId, category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }
    
    public IActionResult Add(int? id)
    {
        ViewBag.Action = "Add";
        
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(Category category)
    {
        if (ModelState.IsValid)
        {
            CategoriesRepo.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    public IActionResult Delete(int categoryId)
    {
        CategoriesRepo.DeleteCategory(categoryId);
        return RedirectToAction(nameof(Index));
    }
    
    
}