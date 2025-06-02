using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class TaiKhoanController : ControllerBase
{
    private readonly DbContextApp _context;

    public TaiKhoanController(DbContextApp context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaiKhoan>>> GetAll()
    {
        return await _context.TaiKhoans.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaiKhoan>> GetById(Guid id)
    {
        var tk = await _context.TaiKhoans.FindAsync(id);
        return tk is null ? NotFound() : Ok(tk);
    }

    [HttpPost]
    public async Task<ActionResult<TaiKhoan>> Create(TaiKhoan tk)
    {
        tk.TaikhoanId = Guid.NewGuid();
        tk.Ngaytaotaikhoan = DateTime.UtcNow;
        _context.TaiKhoans.Add(tk);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = tk.TaikhoanId }, tk);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, TaiKhoan tk)
    {
        if (id != tk.TaikhoanId) return BadRequest();
        var existing = await _context.TaiKhoans.FindAsync(id);
        if (existing is null) return NotFound();

        existing.Username = tk.Username;
        existing.Password = tk.Password;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var tk = await _context.TaiKhoans.FindAsync(id);
        if (tk is null) return NotFound();
        _context.TaiKhoans.Remove(tk);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

