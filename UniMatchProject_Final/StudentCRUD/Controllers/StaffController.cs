using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCRUD.Data;
using StudentCRUD.Models;
using StudentCRUD.ViewModels;
using System.Linq;

namespace StudentCRUD.Controllers
{
    public class StaffController : Controller
    {
        private readonly AppDbContext _context;

        public StaffController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = (from s in _context.Staff
                        join g in _context.UserRole on s.UserRole equals g.RoleId
                        
                        select new StaffDetailsViewModel
                        {
                            Id = s.Id,
                            StaffId = s.StaffId,
                            Name = s.Name,
                            Email = s.Email,
                            UserRole = g.RoleName,
                            UserRoleId = g.RoleId,
                        }).ToList();

            return View(data);
          
        }

        public IActionResult Create()
        {
            ViewBag.UserRole = _context.UserRole
            .Select(s => new SelectListItem
            {
                Value = s.RoleId.ToString(),
                Text = $"{s.RoleName}"
            })
            .ToList();
            return View();
        }
        private string GenerateStrongPassword(int length = 12)
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string symbols = "!@#$%^&*()_+";

            var random = new Random();

            string allChars = lower + upper + numbers + symbols;

            return new string(Enumerable.Repeat(allChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPost]
        public IActionResult Create(Staff Staff)
        {
            StaffLogin staffLogin = new StaffLogin();
            staffLogin.StaffId = Staff.StaffId;
            staffLogin.Password = GenerateStrongPassword();
            _context.Staff.Add(Staff);
            _context.StaffLogin.Add(staffLogin);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var Staff = _context.Staff.Find(id);
            return View(Staff);
        }

        [HttpPost]
        public IActionResult Edit(Staff Staff)
        {
            _context.Staff.Update(Staff);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var Staff = _context.Staff.Find(id);
            _context.Staff.Remove(Staff);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
