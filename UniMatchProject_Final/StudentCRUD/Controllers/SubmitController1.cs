using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCRUD.Data;
using StudentCRUD.Models;
using StudentCRUD.ViewModels;
using System.Linq;

namespace StudentCRUD.Controllers
{
    public class SubmitController : Controller
    {
        private readonly AppDbContext _context;

        public SubmitController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = (from s in _context.Submit
                        join g in _context.GroupName on s.GroupId equals g.Id
                        join sup in _context.Staff on s.SupervisorId equals sup.StaffId into supGroup
                        from sup in supGroup.DefaultIfEmpty()
                        select new SubmitDetailsViewModel
                        {
                            GroupId = s.GroupId,
                            SubmittedTime = s.SubmittedTime,
                            SupervisorId = sup != null ? sup.StaffId : 0,
                            SupervisorName = sup != null ? sup.Name : "No Supervisor Assigned",
                            Count = g.NumOfMembers,
                            ProjectDescription = g.ProjectDescription,
                            ProjectName = g.ProjectName,
                            SubmitId = s.Id,
                            GroupName = g.G_Name,
                        }).ToList();

            return View(data);

           
        }

        public IActionResult Create()
        {
            ViewBag.groupName = _context.GroupName
    .Select(s => new SelectListItem
    {
        Value = s.Id.ToString(),
        Text = $"{s.G_Name} ({s.ProjectDescription})"
    })
    .ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Submit Submit)
        {
            _context.Submit.Add(Submit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var Submit = _context.Submit.Find(id);
            return View(Submit);
        }

        [HttpPost]
        public IActionResult Edit(Submit Submit)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            DateTime currentDate = DateTime.Now.AddDays(2);
            if (Submit.SubmittedTime > currentDate)
            {
                TempData["Error"] = "Submission date must be at least 2 days from today.";
                return View(Submit);
            }
            Submit.SupervisorId = userId.HasValue ? userId.Value : 0; // Set SupervisorId to the logged-in user's ID
            _context.Submit.Update(Submit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var Submit = _context.Submit.Find(id);
            _context.Submit.Remove(Submit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
