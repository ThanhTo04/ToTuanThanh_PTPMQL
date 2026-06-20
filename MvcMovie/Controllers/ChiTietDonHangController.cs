using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models.Entities;

namespace MvcMovie.Controllers
{
    public class ChiTietDonHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChiTietDonHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChiTietDonHang
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChiTietDonHang.ToListAsync());
        }

        // GET: ChiTietDonHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDonHang = await _context.ChiTietDonHang
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chiTietDonHang == null)
            {
                return NotFound();
            }

            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHang/Create
        public IActionResult Create()
        {
            ViewBag.TenKH = new SelectList(
            _context.KhachHang,
            "HoTen",
            "HoTen");
            ViewBag.MaSanPham = new SelectList(
            _context.SanPham,   
            "MaSanPham",
            "TenSanPham");

            return View();
        }

        // POST: ChiTietDonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,STT,TenKH,MaDonHang,MaSanPham")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietDonHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDonHang = await _context.ChiTietDonHang.FindAsync(id);
            if (chiTietDonHang == null)
            {
                return NotFound();
            }
            return View(chiTietDonHang);
        }

        // POST: ChiTietDonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,STT,TenKH,MaDonHang,MaSanPham")] ChiTietDonHang chiTietDonHang)
        {
            if (id != chiTietDonHang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietDonHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietDonHangExists(chiTietDonHang.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDonHang = await _context.ChiTietDonHang
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chiTietDonHang == null)
            {
                return NotFound();
            }

            return View(chiTietDonHang);
        }

        // POST: ChiTietDonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietDonHang = await _context.ChiTietDonHang.FindAsync(id);
            if (chiTietDonHang != null)
            {
                _context.ChiTietDonHang.Remove(chiTietDonHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietDonHangExists(int id)
        {
            return _context.ChiTietDonHang.Any(e => e.Id == id);
        }
    }
}
