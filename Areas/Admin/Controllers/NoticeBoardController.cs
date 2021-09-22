using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class NoticeBoardController : Controller
    {
        private readonly AppDbContext _context;

        public NoticeBoardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<NoticeBoardItem> NoticeBoardItems =  _context.NoticeBoardItems.Where(n => n.IsDeleted==false).ToList();
            return View(NoticeBoardItems);
        }

        public IActionResult CreateNoticeBoardItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNoticeBoardItem(NoticeBoardItemVM noticeBoardItemVM)
        {
            if (!ModelState.IsValid) return NotFound();
            NoticeBoardItem noticeBoardItem = new NoticeBoardItem
            {
                Message = noticeBoardItemVM.Message,
                Date = noticeBoardItemVM.Date,
                IsDeleted = false
            };
            _context.NoticeBoardItems.Add(noticeBoardItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditNoticeBoardItem(int id)
        {
            var existingNoticeBoardItem = await _context.NoticeBoardItems.Where(nb => nb.IsDeleted == false).FirstOrDefaultAsync(nb => nb.Id == id);
            if (existingNoticeBoardItem == null) return NotFound();
            NoticeBoardItemVM noticeBoardItemVM = new NoticeBoardItemVM
            {
                Message = existingNoticeBoardItem.Message,
                Date = existingNoticeBoardItem.Date,
                NoticeBoardItemId = existingNoticeBoardItem.Id
            };
            return View(noticeBoardItemVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditNoticeBoardItem(NoticeBoardItemVM noticeBoardItemVM)
        {
            var existingNoticeBoardItem = await _context.NoticeBoardItems.Where(nb => nb.IsDeleted == false).FirstOrDefaultAsync(nb => nb.Id == noticeBoardItemVM.NoticeBoardItemId);
            if (existingNoticeBoardItem == null) return NotFound();           
            if (!ModelState.IsValid) return View(noticeBoardItemVM);
            existingNoticeBoardItem.Message = noticeBoardItemVM.Message;
            existingNoticeBoardItem.Date = noticeBoardItemVM.Date;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteNoticeBoardItem(int id)
        {
            var existingNoticeBoardItem = await _context.NoticeBoardItems.Where(nb => nb.IsDeleted == false).FirstOrDefaultAsync(nb => nb.Id == id);
            if (existingNoticeBoardItem == null) return NotFound();
            existingNoticeBoardItem.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
