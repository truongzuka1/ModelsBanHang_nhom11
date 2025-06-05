using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace API.Controllers
{
    public class GioHangsController : Controller
    {
        private readonly DbContextApp _context;

        public GioHangsController(DbContextApp context)
        {
            _context = context;
        }

        // GET: GioHangs
        public async Task<IActionResult> Index()
        {
            var dbContextApp = _context.GioHangs.Include(g => g.KhachHang);
            return View(await dbContextApp.ToListAsync());
        }

        // GET: GioHangs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gioHang = await _context.GioHangs
                .Include(g => g.KhachHang)
                .FirstOrDefaultAsync(m => m.GioHangId == id);
            if (gioHang == null)
            {
                return NotFound();
            }

            return View(gioHang);
        }

        // GET: GioHangs/Create
        public IActionResult Create()
        {
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "KhachHangId", "Email");
            return View();
        }

        // POST: GioHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GioHangId,NgayTaoGioHang,NgayCapNhatCuoiCung,TrangThai,KhachHangId")] GioHang gioHang)
        {
            if (ModelState.IsValid)
            {
                gioHang.GioHangId = Guid.NewGuid();
                _context.Add(gioHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "KhachHangId", "Email", gioHang.KhachHangId);
            return View(gioHang);
        }

        // GET: GioHangs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gioHang = await _context.GioHangs.FindAsync(id);
            if (gioHang == null)
            {
                return NotFound();
            }
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "KhachHangId", "Email", gioHang.KhachHangId);
            return View(gioHang);
        }

        // POST: GioHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GioHangId,NgayTaoGioHang,NgayCapNhatCuoiCung,TrangThai,KhachHangId")] GioHang gioHang)
        {
            if (id != gioHang.GioHangId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gioHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GioHangExists(gioHang.GioHangId))
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
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "KhachHangId", "Email", gioHang.KhachHangId);
            return View(gioHang);
        }

        // GET: GioHangs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gioHang = await _context.GioHangs
                .Include(g => g.KhachHang)
                .FirstOrDefaultAsync(m => m.GioHangId == id);
            if (gioHang == null)
            {
                return NotFound();
            }

            return View(gioHang);
        }

        // POST: GioHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var gioHang = await _context.GioHangs.FindAsync(id);
            if (gioHang != null)
            {
                _context.GioHangs.Remove(gioHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GioHangExists(Guid id)
        {
            return _context.GioHangs.Any(e => e.GioHangId == id);
        }
    }
}
