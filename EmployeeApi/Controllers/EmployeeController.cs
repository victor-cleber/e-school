using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.Models;
using EmployeeApi.Services;

namespace EmployeeApi.Controllers
{
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public ProfessorController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: /professor
        [HttpGet]
        [Route("/professor")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Professors.ToListAsync());
        }

        // GET: /professor/5
        [HttpGet]
        [Route("/professor/{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return StatusCode(200, professor);
        }

        // POST: /professor
        [HttpPost]
        [Route("/professor")]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,Address,ProfessorId,IsStaff")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return StatusCode(201, professor);
        }

        // PUT: /professor/5
        [HttpPut]
        [Route("/professor/{id}")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,Phone,Address,ProfessorId,IsStaff")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    professor.Id = id;
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, professor);
            }
            return StatusCode(200, professor);
        }

        // DELETE: /professors/5
        [HttpDelete]
        [Route("/professors/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professors.FindAsync(id);
            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool ProfessorExists(Guid? id)
        {
            return _context.Professors.Any(e => e.Id == id);
        }
    }
}
