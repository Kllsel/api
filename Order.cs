﻿using System.Collections.Generic;
using System;

namespace DataAccess.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}