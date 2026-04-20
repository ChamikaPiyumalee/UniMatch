using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Data;
using StudentCRUD.Models;
using System.Linq;

namespace StudentCRUD.Controllers
{
    public class ModuleController : Controller
    {
        private readonly AppDbContext _context;

        public ModuleController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Module.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Module Module)
        {
            _context.Module.Add(Module);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var Module = _context.Module.Find(id);
            return View(Module);
        }

        [HttpPost]
        public IActionResult Edit(Module Module)
        {
            _context.Module.Update(Module);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var Module = _context.Module.Find(id);
            _context.Module.Remove(Module);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
