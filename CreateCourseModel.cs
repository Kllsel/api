using Microsoft.AspNetCore.Http;
using System;

namespace Businesslogic.DTOs
{
    public class CreateCourseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Complexity { get; set; }
        public int CategoryId { get; set; }
        public int NumOfLessons { get; set; }

        public decimal PricePerLesson { get; set; }
        public decimal PricePerCourse { get; set; }
        public decimal Discount? { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
}
}