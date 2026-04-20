using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCRUD.Data;
using StudentCRUD.Models;
using StudentCRUD.ViewModels;
using System.Linq;

namespace StudentCRUD.Controllers
{
    public class GroupMembersController : Controller
    {
        private readonly AppDbContext _context;

        public GroupMembersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var isStaff = HttpContext.Session.GetInt32("IsStaff");
            var userId = HttpContext.Session.GetInt32("UserId");

            var query = from s in _context.GroupName
                        join g in _context.GroupMembers on s.Id equals g.GroupId
                        join st in _context.Students on g.StudentId equals st.StudentId
                        select new GroupMemberDeatails
                        {
                            Id = g.Id,
                            GroupId = s.Id,
                            GroupName = s.G_Name,
                            StudentId = g.StudentId,
                            StudentName = st.Name,
                            IsLeader = g.IsLeader,
                            ProjectName = s.ProjectName
                        };

            // Apply filter only if staff
            if (isStaff == 1 && userId.HasValue)
            {
                query = from q in query
                        join su in _context.Submit on q.GroupId equals su.GroupId
                        where su.SupervisorId == userId.Value
                        select q;
            }

            var data = query
                .OrderBy(x => x.GroupName)
                .ToList();

            return View(data);
        }

        public IActionResult Create()
        {
            // Load all students for the multi-select dropdown
            ViewBag.Students = _context.Students
                .Select(s => new SelectListItem
                {
                    Value = s.StudentId.ToString(),
                    Text = $"{s.Name} ({s.StudentId})"
                })
                .ToList();
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
        public IActionResult Create(GroupMembers GroupMembers)
        {
            _context.GroupMembers.Add(GroupMembers);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var GroupMembers = _context.GroupMembers.Find(id);
            return View(GroupMembers);
        }

        [HttpPost]
        public IActionResult Edit(GroupMembers GroupMembers)
        {
            _context.GroupMembers.Update(GroupMembers);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var GroupMembers = _context.GroupMembers.Find(id);
            _context.GroupMembers.Remove(GroupMembers);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
