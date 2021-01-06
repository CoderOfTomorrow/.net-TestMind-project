using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMind.Server.Data;
using TestMind.Server.Models;

namespace TestMind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Category>> GetCategories()
        {
            var categoryList = await context.Categories.ToListAsync();
            return categoryList;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromQuery] string name)
        {
            var category = new Category
            {
                Name = name,
                Subcategories = new List<Subcategory>()
            };
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
