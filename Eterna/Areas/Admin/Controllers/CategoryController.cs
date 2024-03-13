﻿using Eterna.DataAccessLayer;
using Eterna.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Eterna.Areas.Admin.Controllers;

[Area("admin")]
public class CategoryController : Controller
{
    private readonly EternaDbContext _context;

    public CategoryController(EternaDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Categories.ToListAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if(!ModelState.IsValid) return View();

        if (await _context.Categories.AnyAsync(x=> x.Name.ToLower() == category.Name.ToLower()))
        {
            ModelState.AddModelError("Name", "Category already exists!");
            return View();
        }

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id) 
    {
        var data = await _context.Categories.FindAsync(id);
        if (data == null) throw new NullReferenceException();

        return View(data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(Category category)
    {
        if (!ModelState.IsValid) return View();

        var existData = await _context.Categories.FindAsync(category.Id);
        if (existData == null) throw new NullReferenceException();

        if (await _context.Categories.AnyAsync(x => x.Name.ToLower() == category.Name.ToLower() && existData.Name.ToLower() != category.Name.ToLower()))
        {
            ModelState.AddModelError("Name", "Category already exists!");
            return View();
        }
        existData.Name = category.Name;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null) return NotFound(); //404

        _context.Categories.Remove(data);
        await _context.SaveChangesAsync();
        return Ok(); //200
    }
}
