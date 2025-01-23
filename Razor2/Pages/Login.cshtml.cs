using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor2.Model;

namespace Razor2.Pages;

public class LoginModel : PageModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Message { get; set; }

    public void OnGet()
    {

    }
    public void OnPost(string userName, string password)
    {
        var users = Users.users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        if (users != null)
        {
            Message = $"Добро пожаловать, {UserName}!";

        }
         else
        {
            Message = "Неверное имя пользователя или пароль!";
        }
    }
}
