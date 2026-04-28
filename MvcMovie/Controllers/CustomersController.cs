using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Services;

namespace MvcMovie.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ExcelService _excelService;

        public CustomersController(ApplicationDbContext context, ExcelService excelService)
        {
            _context = context;
            _excelService = excelService;
        }

        // GET: Import
        public IActionResult Import()
        {
            return View();
        }

        // POST: Import
        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Vui lòng chọn file!";
                return View();
            }

            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/files",
                file.FileName
            );

            var folder = Path.GetDirectoryName(path);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var customers = _excelService.ReadCustomers(path);

            _context.Customers.AddRange(customers);
            await _context.SaveChangesAsync();

            ViewBag.Message = "Import thành công!";
            return View();
        }
    }
}