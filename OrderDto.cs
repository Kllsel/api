﻿using System.Collections.Generic;
using System;

namespace Businesslogic.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<CourseDto> Courses { get; set; }
    }
}