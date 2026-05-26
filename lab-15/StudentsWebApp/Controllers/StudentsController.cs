using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsWebApp.Data;
using StudentsWebApp.Models;

namespace StudentsWebApp.Controllers;

public class StudentsController : Controller
{
    private readonly StudentsDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public StudentsController(StudentsDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    // GET: Students
    public async Task<IActionResult> Index(string searchString)
    {
        ViewData["CurrentFilter"] = searchString;
        var students = from s in _context.Students select s;

        if (!string.IsNullOrEmpty(searchString)) students = students.Where(s => s.Name.Contains(searchString));
        return View(await students.ToListAsync());
    }

    // GET: Students/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
        if (student == null) return NotFound();

        return View(student);
    }

    // GET: Students/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Birthdate,Phone")] Student student, IFormFile? photoFile)
    {
        if (student.Birthdate > DateTime.Now)
            ModelState.AddModelError("Birthdate", "Дата рождения не может быть в будущем.");

        if (ModelState.IsValid)
        {
            if (photoFile != null && photoFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueName = $"{Guid.NewGuid()}{Path.GetExtension(photoFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photoFile.CopyToAsync(stream);
                }

                student.PhotoPath = $"/uploads/{uniqueName}";
            }

            _context.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    // GET: Students/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Birthdate,Phone,PhotoPath")] Student student,
        IFormFile? photoFile)
    {
        if (id != student.Id) return NotFound();

        if (student.Birthdate > DateTime.Now)
            ModelState.AddModelError("Birthdate", "Дата рождения не может быть в будущем.");

        if (ModelState.IsValid)
        {
            try
            {
                if (photoFile != null && photoFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    var uniqueName = $"{Guid.NewGuid()}{Path.GetExtension(photoFile.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, uniqueName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await photoFile.CopyToAsync(stream);
                    }

                    if (!string.IsNullOrEmpty(student.PhotoPath))
                    {
                        var oldPath = Path.Combine(_environment.WebRootPath, student.PhotoPath.TrimStart('/'));
                        if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                    }

                    student.PhotoPath = $"/uploads/{uniqueName}";
                }

                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.Id)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    // GET: Students/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
        if (student == null) return NotFound();

        return View(student);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            if (!string.IsNullOrEmpty(student.PhotoPath))
            {
                var filePath = Path.Combine(_environment.WebRootPath, student.PhotoPath.TrimStart('/'));
                if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
            }

            _context.Students.Remove(student);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentExists(int id)
    {
        return _context.Students.Any(e => e.Id == id);
    }
}