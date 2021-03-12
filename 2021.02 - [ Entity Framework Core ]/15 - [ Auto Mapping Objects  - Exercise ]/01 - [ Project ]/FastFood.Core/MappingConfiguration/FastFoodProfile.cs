using System;
using System.Collections.Generic;
using System.Linq;
using FastFood.Core.Controllers;
using FastFood.Core.ViewModels.Employees;
using FastFood.Core.ViewModels.Items;
using FastFood.Core.ViewModels.Orders;

namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Models;
    using ViewModels.Categories;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>();

            this.CreateMap<Position, PositionsAllViewModel>();

            // Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            // Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));

            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>();

            // Orders
            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(x=>x.DateTime, y=>y.MapFrom(s=>DateTime.Now));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x=>x.DateTime, y=>y.MapFrom(s=>s.DateTime.ToString("U")))
                .ForMember(x=>x.OrderId, y=>y.MapFrom(s=>s.Id));

            this.CreateMap<CreateOrderInputModel, OrderItem>();

        }
    }
}