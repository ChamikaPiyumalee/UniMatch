using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCRUD.Data;
using System.Threading.Tasks;

public class LoginController : Controller
{
    private readonly AppDbContext _context;

    public LoginController(AppDbContext context)
    {
        _context = context;
    }
    // GET: Login Page
    public IActionResult Index()
    {
        return View("Login");
        //return View();
    }

    // POST: Login Function
    [HttpPost]
    public async Task<IActionResult> Index(int username, string password)
    {
        var user = await (
            from login in _context.StudentLogin
            join student in _context.Students
                on login.StudentId equals student.StudentId
            where student.StudentId == username && login.Password == password
            select new
            {
                login,
                student
            }
        ).FirstOrDefaultAsync();

        if (user != null)
        {
            //set session
            HttpContext.Session.SetInt32("UserId", user.student.StudentId);
            HttpContext.Session.SetInt32("IsStudent", 1);
            HttpContext.Session.SetInt32("IsStaff", 0);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid login attempt";
        return View("Login");
    } 

    // LOGOUT
    public async Task<IActionResult> Logout()
    {
        
        return RedirectToAction("Index");
    }
}