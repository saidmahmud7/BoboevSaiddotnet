using Domain.Entities;
using Infrastructure.Service.GroupService;
using Microsoft.AspNetCore.Mvc;
[Area("Admin")]
public class GroupController : Controller
{
    private readonly IGroupService _service;

    public GroupController(IGroupService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var groups = await _service.GetGroups();
        return View(groups);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Group group)
    {
        if (!ModelState.IsValid)
        {
            return View(group);
        }

        var result = await _service.CreateGroup(group);
        if (result == "Created Successfully")
        {
            return RedirectToAction("Index");
        }

        ModelState.AddModelError(string.Empty, result);
        return View(group);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var group = await _service.GetGroupById(id);
        if (group == null)
        {
            return NotFound();
        }

        return View(group);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Group group)
    {
        if (!ModelState.IsValid)
        {
            return View(group);
        }

        var result = await _service.UpdateGroup(group);
        if (result == "Updated Successfully")
        {
            return RedirectToAction("Index");
        }

        ModelState.AddModelError(string.Empty, result);
        return View(group);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteGroup(id);
        if (result == "Deleted Successfully")
        {
            return RedirectToAction("Index");
        }

        ModelState.AddModelError(string.Empty, result);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var group = await _service.GetGroupById(id);
        if (group == null)
        {
            return NotFound();
        }

        return View(group);
    }
}
