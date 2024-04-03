using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Entities
{
    public class Course
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


        public ICollection<Order>? Orders { get; set; }
    }
}