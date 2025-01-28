using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor2.Pages;

public class FeedbackModel : PageModel
{
    [BindProperty]
    public Feedback Feedback { get; set; }
    public List<Feedback> Request = new();

    public void OnGet()
    {
      
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        Request.Add(Feedback);
        return Page();
    }
}


public class Feedback
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email is required!")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Message is required!")]
    public string FeedbackMessage { get; set; }
}
