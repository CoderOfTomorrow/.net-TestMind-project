﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestMind.Shared
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SubcategoryDto> Subcategories { get; set; }
    }
}
