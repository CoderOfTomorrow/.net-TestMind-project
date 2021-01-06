using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMind.Server.Models
{
    public class Subcategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
