using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestMind.Server.Data;
using TestMind.Server.Models;

namespace TestMind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public QuestionController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<List<Question>> GetQuestions(Guid Id)
        {
            var subcategory = await context.Subcategories.Include(e => e.Questions).ThenInclude(e => e.Answers).FirstOrDefaultAsync(e => e.Id == Id);
            return subcategory.Questions;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromQuery] Guid Id,[FromBody] Question question)
        {
            var subcategory = await context.Subcategories.Include(e => e.Questions).FirstOrDefaultAsync(e => e.Id == Id);
  
            subcategory.Questions.Add(question);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
