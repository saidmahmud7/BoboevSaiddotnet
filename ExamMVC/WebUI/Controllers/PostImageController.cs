using Domain;
using Infrastructure.Service.PostImageService;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class PostImageController(IPostImage service) : Controller
{
    public async Task<IActionResult> Index()
    {
        var images = await service.GetAll();
        return View(images);
    }
    public IActionResult Create(int postId)
    {
        return View(new PostImage { PostId = postId });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int postId, IFormFile file, string description)
    {
        if (file != null && file.Length > 0)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var postImage = new PostImage
            {
                PostId = postId,
                ImagePath = "/images/" + file.FileName,
                Description = description,
                UploadDate = DateTime.UtcNow
            };

            var result = await service.Create(postImage);

            if (result == "Created Successfully")
                return RedirectToAction("Index");

            ModelState.AddModelError("", result);
        }

        ModelState.AddModelError("", "Please select a valid image.");
        return View(new PostImage { PostId = postId });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var image = await service.GetById(id);
        if (image == null)
        {
            return NotFound();
        }
        return View(image);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, string description)
    {
        var image = await service.GetById(id);
        if (image == null)
        {
            return NotFound();
        }

        image.Description = description;
        var result = await service.Update(image);

        if (result == "Updated Successfully")
            return RedirectToAction("Index");

        ModelState.AddModelError("", result);
        return View(image);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var image = await service.GetById(id);
        if (image == null)
        {
            return NotFound();
        }
        return View(image);
    }
    public async Task<IActionResult> Details(int id)
    {
        var image = await service.GetById(id);
        if (image == null)
        {
            return NotFound();
        }
        return View(image);
    }
}
