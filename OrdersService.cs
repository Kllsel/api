using AutoMapper;
using Businesslogic.DTOs;
using Businesslogic.Interfaces;
using Businesslogic.Specifications;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Businesslogic.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Order> orderR;
        private readonly IRepository<Course> productR;
        private readonly ICartService cartService;
        private readonly IEmailSender emailSender;
        //private readonly IViewRender viewRender;

        public OrdersService(IMapper mapper,
                            IRepository<Order> orderR,
                            IRepository<Course> courseR,
                            ICartService cartService,
                            //IViewRender viewRender,
                            IEmailSender emailSender)
        {
            this.mapper = mapper;
            this.orderR = orderR;
            this.courseR = courseR;
            this.cartService = cartService;
            this.emailSender = emailSender;
            //this.viewRender = viewRender;
        }

        public async Task Create(string userId)
        {
            var ids = cartService.GetCourseIds();
            var courses = await courseR.GetListBySpec(new CourseSpecs.ByIds(ids));

            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = userId,
                Courses = courses.ToList(),
                TotalPrice = courses.Sum(x => x.Price),
            };

            orderR.Insert(order);
            orderR.Save();

       
        }

        public async Task<IEnumerable<OrderDto>> GetAllByUser(string userId)
        {
            var items = await orderR.GetListBySpec(new OrderSpecs.ByUser(userId));
            return mapper.Map<IEnumerable<OrderDto>>(items);
        }
    }
}