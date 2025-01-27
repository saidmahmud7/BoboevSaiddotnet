using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using MVC1.Models;

namespace MVC1.Controllers;

public class UserController(DataContext context) : Controller
{
    public List<UserModel> Users { get; set; } = new List<UserModel>();
    public async Task<IActionResult> Index()
    {
        Users = await context.Users.ToListAsync();
        return View(Users);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserModel user)
    {
        if (ModelState.IsValid)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View(user);
    }
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UserModel request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (user == null)
        {
            return NotFound();
        }
        user.FisrtName = request.FisrtName;
        user.LatName = request.LatName;
        user.Email = request.Email;
        user.Age = request.Age;

        await context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

   [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var u =await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (u == null)
        {
            return NotFound();
        }

        context.Users.Remove(u);
        await context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Details(int id)
    {
        var u = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (u == null)
        {
            return NotFound();
        }

        return View(u);
    }
}

