using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCRUD.Data;

namespace StudentCRUD.Controllers
{
    public class StaffLoginController : Controller
    {
        private readonly AppDbContext _context;

        public StaffLoginController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Login Page
        public IActionResult Index()
        {
            //return View();
            return View("StaffLogin");
        
        }

        // POST: Login Function
        [HttpPost]
        public async Task<IActionResult> Index(int Username, string password)
        {
            var user = await (
                from login in _context.StaffLogin
                join staff in _context.Staff
                    on login.StaffId equals staff.StaffId
                where staff.StaffId == Username && login.Password == password
                select new
                {
                    login.StaffId,
                    staff
                }
            ).FirstOrDefaultAsync();

            if (user != null)
            {
                //set session
                HttpContext.Session.SetInt32("UserId", user.StaffId);
                HttpContext.Session.SetInt32("UserRole", user.staff.UserRole);
                HttpContext.Session.SetInt32("IsStudent", 0);
                HttpContext.Session.SetInt32("IsStaff", 1);


                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid login attempt";
            return View("StaffLogin");
        }

        // LOGOUT
        public async Task<IActionResult> Logout()
        {

            return RedirectToAction("Index");
        }
    }
}
