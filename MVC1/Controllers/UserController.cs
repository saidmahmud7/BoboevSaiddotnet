using Microsoft.AspNetCore.Mvc;
using MVC1.Models;

namespace MVC1.Controllers;

public class UserController : Controller
{
    public static List<UserModel> Users { get; set; } = new List<UserModel>();
    public IActionResult Index()
    {
        return View(Users);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(UserModel user)
    {
        if (ModelState.IsValid)
        {
            user.Id = Users.Count > 0 ? Users.Max(u => u.Id) + 1 : 1;
            Users.Add(user);

            return RedirectToAction("Index");
        }

        return View(user);
    }
    [HttpGet]
    public IActionResult Update(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
    [HttpPost]
    public IActionResult Update(UserModel user)
    {
        if (ModelState.IsValid)
        {
            var existing = Users.FirstOrDefault(u => u.Id == user.Id);
            if (existing == null)
            {
                return NotFound();
            }
            existing.FisrtName = user.FisrtName;
            existing.LatName = user.LatName;
            existing.Email = user.Email;
            existing.Age = user.Age;
            return RedirectToAction("Index");
        }

        return View(user);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        Users.Remove(user);

        return RedirectToAction("Index");
    }
    public IActionResult Details(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
}

