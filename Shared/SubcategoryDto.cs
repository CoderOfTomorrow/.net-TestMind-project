using System;
using System.Collections.Generic;
using System.Text;

namespace TestMind.Shared
{
    public class SubcategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
