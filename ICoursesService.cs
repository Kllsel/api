using Businesslogic.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Businesslogic.Interfaces
{
    public interface ICoursesService
    {
        Task<IEnumerable<CourseDto>> GetAll();
        Task<IEnumerable<CourseDto>> Get(IEnumerable<int> ids);
        Task<CourseDto?> Get(int id);
        IEnumerable<CategoryDto> GetAllCategories();
        void Create(CreateCourseModel course);
        void Edit(CourseDto course);
        void Delete(int id);
    }
}