using System.Collections.Generic;
using System;

namespace Businesslogic.DTOs
{
    public class OrderSummaryModel
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<CourseDto> Courses { get; set; }
    }
}