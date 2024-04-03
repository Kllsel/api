using System.Collections.Generic;

namespace DataAccess.Data.Entities
{
    public enum Categories
    {
        Programming = 1,
        Design,
        Marketing,
        Management,
        Languages,
        MusicalInstruments,
        Art,
        Other
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubtypeName { get; set; }

        public ICollection<Course>? Courses { get; set; }
    }
}