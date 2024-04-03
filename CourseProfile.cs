using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile(IFileService fileService)
        {
            CreateMap<CourseDto, Course>()
                .ForMember(x => x.Category, opt => opt.Ignore());
            CreateMap<Course, CourseDto>();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<Order, OrderSummaryModel>()
                .ForMember(x => x.Number, opts => opts.MapFrom(src => src.Id))
                .ForMember(x => x.UserName, opts => opts.MapFrom(src => src.User.UserName));

            CreateMap<RegisterModel, User>()
                .ForMember(x => x.UserName, opts => opts.MapFrom(s => s.Email));
        }
    }
}