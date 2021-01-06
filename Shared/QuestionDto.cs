using System;
using System.Collections.Generic;

namespace TestMind.Shared
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
