using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using Shop_Api_PV221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Course> coursesR;
        private readonly IRepository<Category> categoriesR;
        //private readonly ShopDbContext context;

        public CoursesService(IMapper mapper,
                                IRepository<Course> coursesR,
                                IRepository<Category> categoriesR)
        {
            this.mapper = mapper;
            this.coursesR = coursesR;
            this.categoriesR = categoriesR;
        }

        public void Create(CreateCourseModel course)
        {
            coursesR.Insert(mapper.Map<Course>(course));
            coursesR.Save();
        }

        public void Delete(int id)
        {
            if (id < 0) throw new HttpException(Errors.IdMustPositive, HttpStatusCode.BadRequest);

            // delete product by id
            var course = coursesR.GetById(id);

            if (course == null) throw new HttpException(Errors.CourseNotFound, HttpStatusCode.NotFound);

            coursesR.Delete(course);
            coursesR.Save();
        }

        public void Edit(CourseDto course)
        {
            coursesR.Update(mapper.Map<Course>(course));
            coursesR.Save();
        }

        public async Task<CourseDto?> Get(int id)
        {
            if (id < 0) throw new HttpException(Errors.IdMustPositive, HttpStatusCode.BadRequest);

            var item = await coursesR.GetItemBySpec(new CourseSpecs.ById(id));
            if (item == null) throw new HttpException(Errors.CourseNotFound, HttpStatusCode.NotFound);

            var dto = mapper.Map<CourseDto>(item);

            return dto;
        }

        public async Task<IEnumerable<CourseDto>> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<CourseDto>>(await coursesR.GetListBySpec(new CourseSpecs.ByIds(ids)));
        }

        public async Task<IEnumerable<CourseDto>> GetAll()
        {
            return mapper.Map<List<CourseDto>>(await coursesR.GetListBySpec(new CourseSpecs.All()));
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return mapper.Map<List<CategoryDto>>(categoriesR.GetAll());
        }
    }
}