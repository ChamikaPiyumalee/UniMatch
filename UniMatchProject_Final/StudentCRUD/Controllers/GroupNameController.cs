using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCRUD.Data;
using StudentCRUD.Models;
using System.Linq;

namespace StudentCRUD.Controllers
{
    public class GroupNameController : Controller
    {
        private readonly AppDbContext _context;

        public GroupNameController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GroupName.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Modules = _context.Module
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.ModuleName} ({s.ModuleCode})"
            })
            .ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(GroupName GroupName)
        {
            _context.GroupName.Add(GroupName);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var GroupName = _context.GroupName.Find(id);
            return View(GroupName);
        }

        [HttpPost]
        public IActionResult Edit(GroupName GroupName)
        {
            _context.GroupName.Update(GroupName);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var GroupName = _context.GroupName.Find(id);
            _context.GroupName.Remove(GroupName);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

