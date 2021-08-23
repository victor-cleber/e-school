using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentApi.Models;
using StudentApi.Services;

namespace StudentApi.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DbStudentContext _context;

        public StudentController(DbStudentContext context)
        {
            _context = context;
        }

        // GET: /students
        [HttpGet]
        [Route("/students")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Students.ToListAsync());
        }

        // GET: /students/5
        [HttpGet]
        [Route("/students/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return StatusCode(200, student);
        }

        // POST: /students
        [HttpPost]
        [Route("/students")]
        public async Task<IActionResult> Create([Bind("Id,Name,StudentId,Grades")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return StatusCode(201, student);
        }

        // PUT: /students/5
        [HttpPut]
        [Route("/students/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StudentId,Grades")] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    student.Id = id;
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, student);
            }
            return StatusCode(200, student);
        }

        // DELETE: /students/5
        [HttpDelete]
        [Route("/students/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
