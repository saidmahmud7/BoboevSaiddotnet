using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor2.Pages;

public class IndexModel : PageModel
{ [BindProperty]
    public string UserName { get; set; }

    public string GreetingMessage { get; private set; }

    public void OnGet()
    {
        SetGreeting();
    }

    public void OnPost()
    {
        SetGreeting();
    }

    private void SetGreeting()
    {
        var currentHour = DateTime.Now.Hour;

        if (currentHour >= 6 && currentHour < 12)
        {
            GreetingMessage = "Доброе утро";
        }
        else if (currentHour >= 12 && currentHour < 18)
        {
            GreetingMessage = "Добрый день";
        }
        else
        {
            GreetingMessage = "Добрый вечер";
        }

        if (!string.IsNullOrEmpty(UserName))
        {
            GreetingMessage += $", {UserName}!";
        }
    }
}
