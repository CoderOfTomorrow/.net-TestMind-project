using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMind.Server.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
