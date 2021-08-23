using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using SchoolApi.Models;
using SchoolApi.Services;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public SchoolController(SchoolDbContext schoolDbContext)
        {
            _context = schoolDbContext;         
        }

        private bool SchoolExists(Guid id){
            return _context.Schools.Any(s => s.Id == id);
        }

        [HttpGet]
        [Route("/school")]
        public async Task<ActionResult<School>> Get()
        {
            Guid id = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");

            if (SchoolExists(id)){
                var school = await _context.Schools.FindAsync(id);

                return StatusCode(200, new{
                    Id = school.Id,
                    CompanyName = school.CompanyName,
                    TradingName = school.TradingName,
                    WebSite= school.WebSite,
                    Phone  =school.Phone,
                    Addres = school.Address
                });
            }else{
                return StatusCode(401, "Schoool Not found");                
            }
        }
    }
}