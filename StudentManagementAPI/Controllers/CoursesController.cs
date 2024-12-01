using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Controllers
{
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        private readonly StudentManagementContext _context;

        public CoursesController(StudentManagementContext context)
        {
            _context = context;
        }

        // GET: Subjects
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var subjects = await _context.Courses.ToListAsync();
            return View(subjects); // Returns the list view of subjects
        }

        // GET: Subjects/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var subject = await _context.Courses.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject); // Returns the details view of a specific subject
        }

        // GET: Subjects/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new subject
        }

        // POST: Subjects/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the subject list
            }
            return View(subject);
        }

        // GET: Subjects/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var subject = await _context.Courses.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject); // Returns the edit view for a specific subject
        }

        // POST: Subjects/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course subject)
        {
            if (id != subject.CourseID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the subject list
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await _context.Courses.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject); // Returns the delete confirmation view
        }

        // POST: Subjects/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Courses.FindAsync(id);
            if (subject != null)
            {
                _context.Courses.Remove(subject);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the subject list
        }

        private bool SubjectExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }

        [HttpGet("GetCourses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return Json(courses);
        }



    }
}