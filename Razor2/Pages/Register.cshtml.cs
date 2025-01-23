using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor2.Model;

namespace Razor2.Pages;

public class RegisterModel : PageModel
{

    public string Message { get; set; }

    public void OnGet()
    {
        Message = "Please register.";
    }

    public void OnPost(string userName, string password, string confirmPassword)
    {
        if (password != confirmPassword)
        {
            Message = "Passwords do not match.";
            return;
        }

        Users.users.Add(new User { UserName = userName, Password = password });
        Message = "Successful!";
    }
}
