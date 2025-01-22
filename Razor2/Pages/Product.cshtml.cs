using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor2.Model;
using Web.Models;

namespace Razor2.Pages;

public class ProductModel : PageModel
{

    public List<Product> Products { get; set; }
    public string SearchQuery { get; set; }
    public void OnGet(string searchQuery)
    {
        var allProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Ноутбук", Price = 1000 },
            new Product { Id = 2, Name = "Смартфон", Price = 800 },
            new Product { Id = 3, Name = "Планшет", Price = 500 }
        };

        SearchQuery = searchQuery;
        Products = string.IsNullOrEmpty(SearchQuery)
            ? allProducts
            : allProducts.Where(p => p.Name.Contains(SearchQuery)).ToList();
    }
}



