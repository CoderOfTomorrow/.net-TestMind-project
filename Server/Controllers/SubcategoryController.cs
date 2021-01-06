using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestMind.Server.Data;
using TestMind.Server.Models;

namespace TestMind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public SubcategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<List<Subcategory>> GetSubcategories(Guid Id) 
        {
            var category = await context.Categories.Include(e => e.Subcategories).FirstOrDefaultAsync(e => e.Id == Id);
            return category.Subcategories;
        }

        [HttpPost]
        public async Task<IActionResult> AddSubcategory([FromQuery] string Name,[FromQuery] Guid Id)
        {
            var category = await context.Categories.Include(e=> e.Subcategories).FirstOrDefaultAsync(e => e.Id == Id);

            var subcategory = new Subcategory
            {
                Name = Name,
                Questions = new List<Question>()
            };
            category.Subcategories.Add(subcategory);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
