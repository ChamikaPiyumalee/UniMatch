using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Data;
using StudentCRUD.Models;
using System.Linq;

namespace StudentCRUD.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly AppDbContext _context;

        public UserRoleController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.UserRole.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserRole UserRole)
        {
            _context.UserRole.Add(UserRole);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var UserRole = _context.UserRole.Find(id);
            return View(UserRole);
        }

        [HttpPost]
        public IActionResult Edit(UserRole UserRole)
        {
            _context.UserRole.Update(UserRole);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var UserRole = _context.UserRole.Find(id);
            _context.UserRole.Remove(UserRole);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
