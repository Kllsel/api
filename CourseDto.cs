using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Complexity { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int NumOfLessons { get; set; }

        public decimal PricePerLesson { get; set; }
        public decimal PricePerCourse { get; set; }
        public decimal Discount? { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
}
}