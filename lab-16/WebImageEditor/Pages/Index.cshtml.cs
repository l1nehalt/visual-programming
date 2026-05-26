using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace WebImageEditor.Pages;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment _environment;

    public IndexModel(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [BindProperty(SupportsGet = true)] public string? ImageName { get; set; }

    public string? ImagePath => string.IsNullOrEmpty(ImageName) ? null : $"/uploads/{ImageName}";

    public async Task<IActionResult> OnPostUploadAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            ModelState.AddModelError(string.Empty, "Пожалуйста, выберите корректный файл.");
            return Page();
        }

        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadsFolder);

        var extension = Path.GetExtension(file.FileName);
        var uniqueName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(uploadsFolder, uniqueName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return RedirectToPage(new { imageName = uniqueName });
    }

    [ValidateAntiForgeryToken]
    public IActionResult OnPostFilter([FromBody] FilterRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.ImageName))
            return BadRequest("Нет данных об изображении");

        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        var sourcePath = Path.Combine(uploadsFolder, request.ImageName);

        if (!System.IO.File.Exists(sourcePath))
            return NotFound("Файл не найден на сервере");

        var extension = Path.GetExtension(request.ImageName);
        var filteredName = $"{Guid.NewGuid()}{extension}";
        var outputPath = Path.Combine(uploadsFolder, filteredName);

        try
        {
            using (var image = Image.Load(sourcePath))
            {
                switch (request.FilterType?.ToLower())
                {
                    case "sharpen":
                        image.Mutate(x => x.GaussianSharpen());
                        break;
                    case "blur":
                        image.Mutate(x => x.GaussianBlur(5f));
                        break;
                    case "edges":
                        image.Mutate(x => x.DetectEdges());
                        break;
                    default:
                        return BadRequest("Неизвестный фильтр");
                }

                image.Save(outputPath);
            }

            return JointJsonResult(filteredName);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ошибка обработки: {ex.Message}");
        }
    }

    private IActionResult JointJsonResult(string fileName)
    {
        return new JsonResult(new { success = true, newSrc = $"/uploads/{fileName}", fileName });
    }
}